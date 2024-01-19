using BackEndProject.Areas.Admin.ViewModels;
using BackEndProject.DAL;
using BackEndProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.Areas.Admin.Controllers
{
    [Area(areaName:"Admin")]
    public class CategoryController : Controller
    {
        private readonly ShopwiseDbContext _context;
        public CategoryController(ShopwiseDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            List<Category> category = _context.Category.ToList();
            return View(category);
        }

        public IActionResult Detail(int id)
        {
            //if (id == 0) return BadRequest();
            Category category = _context.Category.FirstOrDefault(c=>c.Id == id)!;
            //if (category == null) return NotFound();
            return View(category);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryVM category)
        {
            if (!ModelState.IsValid) return View();

            bool NotUnique = _context.Category.Any(c => c.Name == category.Name);
            if (NotUnique)
            {
                return View();
            }

            Category newCategory = new Category
            {
                Name = category.Name,
                Image = category.Image,
                IsTop = category.IsTop,
            };

            _context.Category.Add(newCategory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            if (id == 0) return BadRequest();
            Category category = _context.Category.FirstOrDefault(c => c.Id == id)!;
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        public IActionResult Update(int id, UpdateCategoryVM category)
        {
            if (id == 0) return BadRequest();
            if(!ModelState.IsValid) return View();

            Category updatedCategory = _context.Category.FirstOrDefault(c => c.Id == id)!;
            if (updatedCategory is  null) return NotFound();

            bool notUnique = _context.Category.Any(c=>c.Name == category.Name); 
            if (notUnique)
            {
                ModelState.AddModelError(string.Empty, "Dont repeat data");
                return View();
            }

            updatedCategory.Name = category.Name;
            updatedCategory.Image = category.Image;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest();
            Category category = _context.Category.FirstOrDefault(c => c.Id == id)!;
            if (category == null) return NotFound();
            _context.Category.Remove(category);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
