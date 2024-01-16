using BackEndProject.Entities;

namespace BackEndProject.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; } = null!;
        public IEnumerable<Ad> Ads { get; set; } = null!;   
        public ICollection<Category> Categories { get; set;} = null!;
        public ICollection<Product> Products { get; set; } = null!;




    }

}
