using System.ComponentModel.DataAnnotations;

namespace MeFerstWebAplication.Models.UserModel
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Login")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Не указан Login")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Не указан Age")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Не указан ImageUser")]
        public string? ImageUser { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль введен неверно")]
        public string? ConfirmPassword { get; set; }
    }
}
