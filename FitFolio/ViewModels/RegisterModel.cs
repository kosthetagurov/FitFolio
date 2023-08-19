using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

namespace FitFolio.ViewModels
{
    public class RegisterModel
    {
        [Required]
        [EmailAddress]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required]
        [MinLength(7)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
        [Required]
        [MinLength(7)]
        [DisplayName("Пароль повторно")]
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
