namespace FileMe.DAL.Classes
{
    public class AccessRight
    {
        public virtual long Id { get; set; }

        public virtual Folder Folder { get; set; }

        public virtual AccessLevels AccessLevel { get; set; }

        public virtual Group Group { get; set; }
    }

    public enum AccessLevels
    {
        Reading,
        Writing,
        Full
    }
}
