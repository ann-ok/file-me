using FileMe.DAL.Classes;

namespace FileMe.Models
{
    public class FolderListModel: EntityListModel<Folder>
    {
        public Folder Parent { get; set; }

        public Folder CurrentFolder { get; set; }

        public bool IsRootFolder { get; set; }
    }
}