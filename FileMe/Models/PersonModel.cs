using FileMe.DAL.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileMe.Models
{
    public class PersonModel: EntityModel<Person>
    {
        [Required]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
    }
}