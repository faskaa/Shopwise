using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
using BackEndProject.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    public class SliderController : Controller
    {
        private readonly ShopwiseDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(ShopwiseDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult Index()
        {
            List<Slider> slider = _context.Sliders.ToList();
            return View(slider);
        }

        public IActionResult Details()
        {//uncomplated
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateSliderVM slider)
        {
            if(!ModelState.IsValid) return View();
            //2097152==2mb
            if (slider.BgPhoto.Length > 2097152)
            {
                ModelState.AddModelError(string.Empty, "Choose photo wich size less than 2mb");
                return View();
            }

            string webpath = _env.WebRootPath;
            string folderPath = Path.Combine(webpath, "assets", "images");


            string filePath = Guid.NewGuid() + slider.BgPhoto.FileName;
            string fullPath = Path.Combine(folderPath, filePath);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                slider.BgPhoto.CopyTo(stream);
            }

            Slider newSlider = new Slider
            {
                Title = slider.Title,
                Description = slider.Description,
                URL = slider.URL,
                BgImage = filePath,
            };

            _context.Sliders.Add(newSlider); 
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
