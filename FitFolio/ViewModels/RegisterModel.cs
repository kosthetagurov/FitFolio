using System.ComponentModel.DataAnnotations;

namespace FitFolio.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(7)] 
        public string Password { get; set; }
    }
}
