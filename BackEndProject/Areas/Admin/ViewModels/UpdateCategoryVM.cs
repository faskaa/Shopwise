using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class UpdateCategoryVM
    {
        [Display(Prompt = "Please fill this input")]
        public string Name { get; set; }

        [Display(Prompt = "Please fill this input")]
        public string Image { get; set; }

        [Display(Prompt = "Please fill this input")]
        public bool IsTop { get; set; }
    }
}
