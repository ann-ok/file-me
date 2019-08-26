using FileMe.DAL.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FileMe.Models
{
    public class GroupModel: EntityModel<Group>
    {
        [Required]
        [DisplayName("Название группы")]
        public string Name { get; set; }
    }
}