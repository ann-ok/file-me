using FileMe.DAL.Classes;
using FileMe.Validation;
using System;
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
        [Login(ErrorMessage = "Пользователь с таким логином уже существует")]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Required]
        [Email(ErrorMessage = "Пользователь с таким адресом уже существует")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Password(8, ErrorMessage = "Пароль должен иметь больше 8 символов")]
        [DataType(DataType.Password)]
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

        public DateTime CreationDate { get; set; }
    }
}