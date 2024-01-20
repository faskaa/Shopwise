using System.ComponentModel.DataAnnotations;

namespace BackEndProject.ViewModels
{
    public class RegisterVM
    {
        [Display(Prompt ="Name")]
        [StringLength(maximumLength:15,MinimumLength =5 )]
        public string Name { get; set; }

        [Display(Prompt = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(maximumLength: 16, MinimumLength = 8)]
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name= "Confirm Password" ,Prompt = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }


        public bool IsTermsAccept { get; set; }

    }
}
