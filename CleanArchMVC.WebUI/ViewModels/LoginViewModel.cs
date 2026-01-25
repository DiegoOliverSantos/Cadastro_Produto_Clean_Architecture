using System.ComponentModel.DataAnnotations;

namespace CleanArchMVC.WebUI.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress(ErrorMessage ="Email is Invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [StringLength(20, ErrorMessage = "the {0} must be at least {2} and ate max" +
            "{1} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}
