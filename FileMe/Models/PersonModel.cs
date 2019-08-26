using FileMe.DAL.Classes;
using FileMe.Validation;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FileMe.Models
{
    public class PersonModel: EntityModel<Person>
    {
        [DisplayName("ФИО")]
        [Required]
        public string FIO { get; set; }

        [Required]
        [Login]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Password")]
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Подтверждение")]
        public string ConfirmPassword { get; set; }

        [Required]
        [DisplayName("Группа")]
        public string GroupName { get; set; }

        public List<SelectListItem> Groups { get; set; }
    }
}