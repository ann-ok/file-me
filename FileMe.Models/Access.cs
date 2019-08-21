namespace FileMe.Models
{
    public class Access
    {
        public Folder Folder { get; set; }

        public AccessLevels AccessLevel { get; set; }

        public Group Group { get; set; }

        public Access() { }

        public Access(Folder folder, AccessLevels accessLevel, Group group)
        {
            Folder = folder;
            AccessLevel = accessLevel;
            Group = group;
        }
    }

    public enum AccessLevels
    {
        Reading,
        Writing,
        Full
    }
}
