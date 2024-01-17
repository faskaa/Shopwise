using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Controllers
{
    public class WishlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
