using FileMe.DAL.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileMe.Models
{
    public class FolderModel: EntityModel<Folder>
    {
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }

        public long? ParentId { get; set; }
    }
}