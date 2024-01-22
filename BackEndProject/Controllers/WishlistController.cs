using BackEndProject.DAL;
using BackEndProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Controllers
{
    public class WishlistController : Controller
    {
        private readonly ShopwiseDbContext _context;

        public WishlistController(ShopwiseDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Wishlist> wishlist = _context.Wishlist.ToList();
            return View(wishlist);
        }



       


        public IActionResult Add(int Id , Wishlist wishlist)
        {  
            if (Id == 0) return BadRequest();
            Product product = _context.Products.Include(p=>p.ProductImage).FirstOrDefault(p => p.Id == Id)!;
            if (product == null) return NotFound();

            Wishlist newWishlist = new Wishlist()
            {
                Id = product.Id,
                Name = product.Title,
                Price = product.Price,
            };

            _context.Wishlist.Add(newWishlist);
            _context.SaveChanges();
            //return Json(newWishlist);
            return NoContent();
        }
    }
}
