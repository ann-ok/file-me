using FileMe.DAL.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FileMe.Models
{
    public class PersonModel: EntityModel<Person>
    {
        [Required]
        [DisplayName("Название группы")]
        public string Login { get; set; }

        [Required]
        public string Password { get; set; }

        //public Group Group { get; set; }
    }
}