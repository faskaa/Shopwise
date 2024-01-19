using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class CreateCategoryVM
    {
        
        public string Name { get; set; }
        public string Image { get; set; }
        public bool IsTop { get; set; }


    }
}
