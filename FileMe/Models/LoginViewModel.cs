using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileMe.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}