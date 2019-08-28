using System;
using System.ComponentModel;

namespace FileMe.Models
{
    public class HomeModel
    {
        public static string ApplicationName = "FileMe";

        [DisplayName("Изменить название страницы")]
        public string Title { get; set; }

        public DateTime Time { get; set; }
    }
}