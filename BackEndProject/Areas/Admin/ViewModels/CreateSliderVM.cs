using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class CreateSliderVM
    {
        [Display(Prompt = "Please fill this input")]
        public string Title { get; set; } = null!;

        [Display(Prompt = "Please fill this input")]
        public string Description { get; set; } = null!;

        [Display(Prompt = "Please fill this input")]
        
        public string URL { get; set; } = null!;

        [ValidateNever]
        [Display(Prompt = "Please fill this input")]
        public string BgImage { get; set; } = null!;

        public IFormFile BgPhoto { get; set; }
    }
}
