using BackEndProject.Entities;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.DAL
{
    public class ShopwiseDbContext:DbContext
    {
        public ShopwiseDbContext(DbContextOptions<ShopwiseDbContext> options):base(options)
        {
            
        }

        public DbSet<Slider> Sliders { get; set; }
    }
}
