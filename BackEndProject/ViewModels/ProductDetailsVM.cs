using BackEndProject.Entities;

namespace BackEndProject.ViewModels
{
    public class ProductDetailsVM
    {
        public Product Product { get; set; } = null!;
        public ICollection<Product> Relateds  { get; set; } = null!;
    }
}
