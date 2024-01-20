using BackEndProject.Entities;
using Microsoft.EntityFrameworkCore;
using BackEndProject.Areas.Admin.ViewModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BackEndProject.DAL
{
    public class ShopwiseDbContext:IdentityDbContext<CustomUser>
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
        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<CustomUser> CustomUsers { get; set; }
        public DbSet<Info> Info { get; set; }
        public DbSet<AddOffer> AddOffer { get; set; }











        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }









    }
}
