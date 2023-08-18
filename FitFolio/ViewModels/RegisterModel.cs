using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

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
        [Required]
        [MinLength(7)]
        public string RePassword { get; set; }

        public bool IsPasswordsSame()
        {
            bool result = true;

            if (Password != RePassword)
            {
                result = false;
            }

            return result;
        }
    }
}
