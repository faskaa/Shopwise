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
        public DbSet<Ad> Ads { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Information> Informations { get; set; }
        public DbSet<ProductInformation> ProductInformations { get; set; }







        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
