using FileMe.DAL.Classes;

namespace FileMe.DAL.Filters
{
    public class FolderFilter: BaseFilter
    {
        public Folder Parent { get; set; }
    }
}
