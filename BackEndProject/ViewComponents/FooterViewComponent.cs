using BackEndProject.DAL;
using BackEndProject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly ShopwiseDbContext _context;

        public FooterViewComponent(ShopwiseDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Setting> settings =  await _context.Settings.ToListAsync();
            return View(settings);
        }
    }
}
