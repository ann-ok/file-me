namespace FileMe.Models
{
    public class DctVersion
    {
        public int Id { get; set; }

        public Folder Document { get; set; }

        DctVersion() { }

        public DctVersion(int id, Folder document)
        {
            Id = id;
            Document = document;
        }
    }
}
