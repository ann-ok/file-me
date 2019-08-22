using System;
using System.ComponentModel;

namespace FileMe.Models
{
    public class HomeModel
    {
        [DisplayName("Название страницы")]
        public string Title { get; set; }

        public DateTime Time { get; set; }
    }
}