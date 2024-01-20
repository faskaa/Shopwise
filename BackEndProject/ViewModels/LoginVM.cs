using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace BackEndProject.ViewModels
{
    public class LoginVM
    {
        [ValidateNever]
        [Display(Prompt ="User Name")]
        public string Username { get; set; }

        [ValidateNever]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
