using BackEndProject.DAL;
using BackEndProject.Entities;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<Slider> model = _context.Sliders;
            return View(model);
        }
    }
}
