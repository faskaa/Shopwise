using BackEndProject.DAL;
using BackEndProject.Entities;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ShopwiseDbContext _context;

        public HomeController(ShopwiseDbContext context)
        {
            _context =  context;
        }

        public IActionResult Index()
        {
            HomeVM model = new HomeVM
            {
                Sliders = _context.Sliders.ToList(),
                Ads = _context.Ads.ToList(),
                Categories = _context.Category.ToList(),
                Products = _context.Products.Include(p=>p.Rating).Include(p=>p.ProductImage).ToList(),
                addOffers = _context.AddOffer.ToList(),
                
            };

            
            return View(model);
        }

        public IActionResult Contact()
        {
            List<Setting> setting = _context.Settings.ToList();
             return View(setting);
        }
    }
}
