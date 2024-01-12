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
        public DbSet<Product> Products { get; set; }
        public DbSet<Rating> Ratings { get; set; }



    }
}
