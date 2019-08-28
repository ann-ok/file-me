namespace FileMe.DAL.Classes
{
    public class DctVersion
    {
        public virtual long Id { get; set; }

        public virtual Folder Document { get; set; }
    }
}
