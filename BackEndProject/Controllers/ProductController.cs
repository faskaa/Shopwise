using BackEndProject.DAL;
using BackEndProject.Entities;
using BackEndProject.Helpers;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace BackEndProject.Controllers
{
    public class ProductController : Controller
    {
        private readonly ShopwiseDbContext _context;

        public ProductController(ShopwiseDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Product> product = _context.Products.Include(p=>p.Rating).ToList();
            return View(product);
        }

        public IActionResult Details(int id)
        {
            if (id == 0) return BadRequest();
            IQueryable <Product> queryable= _context.Products.AsQueryable(); 
            Product product = _context.Products
                .Include(p=>p.ProductInformation).ThenInclude(p=>p.Information)
                .Include(p => p.ProductCategories)
                .ThenInclude(p=>p.Category)
                .Include(t => (t as Product).Rating)
                .FirstOrDefault(p => p.Id == id)!;

            if (product == null) return NotFound();
            ProductDetailsVM model = new ProductDetailsVM
            {
                Product = product,
                Relateds = RelatedProducts(queryable, product)

            };
            
            return View(model);
        }

        private ICollection<Product> RelatedProducts(IQueryable<Product> products, Product product)
        {
            ICollection<ProductCategory> categories = product.ProductCategories;
            List <Product> relateds = new List<Product>();
            foreach (ProductCategory category in categories)
            {
                List<Product> founds = products.Include(p=>p.ProductCategories).AsEnumerable()
                                                  .Where(p => p.ProductCategories
                                                   .Any(pc => pc.CategoryId == category.CategoryId)
                                                   && p.Id != product.Id
                                                   && !relateds.Contains(p , new ProductComparer()))
                                                  .ToList();
                relateds.AddRange(founds);
            }
            return relateds; 
        }
    }
}
