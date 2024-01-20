using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BackEndProject.Areas.Admin.ViewModels
{
    public class CreateCategoryVM
    {
        [Display(Prompt = "Please fill this input")]
        public string Name { get; set; }

        [ValidateNever]
        [Display(Prompt = "Please fill this input")]
        public string Image { get; set; }


        public bool IsTop { get; set; }
         

        public IFormFile Photo { get; set; }


    }
}
