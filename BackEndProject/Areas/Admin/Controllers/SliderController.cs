using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
using BackEndProject.Entities;
using BackEndProject.Helpers;
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


        public IActionResult Detail(int id)
        {
            if (id==0) return BadRequest();
            Slider slider = _context.Sliders.FirstOrDefault(s => s.Id == id)!;
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSliderVM slider)
        {
            if(!ModelState.IsValid) return View();
            //2097152==2mb
            if (slider.BgPhoto.IsValidPhotoSize(2097152))
            {
                ModelState.AddModelError(string.Empty, "Choose photo wich size less than 2mb");
                return View();
            }

            string webpath = _env.WebRootPath;
            Slider newSlider = new Slider
            {
                Title = slider.Title,
                Description = slider.Description,
                URL = slider.Description,
                BgImage = await slider.BgPhoto.GeneratePhoto(webpath , "assets", "images")
            };

            _context.Sliders.Add(newSlider); 
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            if(id== 0) return BadRequest();
            UpdateSliderVM slider = _context.Sliders.Select(s=>new UpdateSliderVM
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                URL = s.Description,
                BgImage = s.BgImage,

            }).FirstOrDefault(p=>p.Id == id)!;
            if (slider == null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int id , UpdateSliderVM updatedSlider )
        {
            if (id == 0) return BadRequest();
            Slider slider = _context.Sliders.FirstOrDefault(p => p.Id == id)!;
            if (slider == null) return NotFound();

            UpdateSliderVM model = new UpdateSliderVM()
            {
                Id = slider.Id,
                Title = slider.Title,
                Description = slider.Description,
                URL = slider.Description,
                BgImage = slider.BgImage,
            };
            if (!ModelState.IsValid) return View(slider);

            //if (updatedSlider.BgPhoto.IsValidPhotoSize(2097152))
            //{
            //    ModelState.AddModelError(string.Empty, "Choose photo wich size less than 2mb");
            //    return View();
            //}
            string webpath = _env.WebRootPath;


            slider.Title = updatedSlider.Title;
            slider.Description = updatedSlider.Description;
            slider.URL = updatedSlider.URL;
            slider.BgImage = updatedSlider.BgPhoto is null ? slider.BgImage : await updatedSlider.BgPhoto.GeneratePhoto(webpath, "assets", "images");



            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
            return Json(updatedSlider);
        }

       
    }
}
