namespace FileMe.DAL.Classes
{
    public class DctVersion
    {
        public virtual int Id { get; set; }

        public virtual Folder Document { get; set; }
    }
}
