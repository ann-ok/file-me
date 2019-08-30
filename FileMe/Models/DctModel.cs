using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileMe.Models
{
    public class DctModel: FolderModel
    {
        [Required]
        [DisplayName("Расширение")]
        public string Type { get; set; }
    }
}