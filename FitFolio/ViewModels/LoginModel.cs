using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FitFolio.ViewModels
{
    public class LoginModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Введите логин")]

        public string Login { get; set; }

        [Required(ErrorMessage = "Введите пароль")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }

        public string? ReturnUrl { get; set; }
    }
}
