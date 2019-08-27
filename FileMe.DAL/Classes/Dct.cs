namespace FileMe.DAL.Classes
{
    public class Dct : Folder
    {
        //public virtual string FilePath { get; set; }

        //public virtual string Type => FilePath.Substring(FilePath.LastIndexOf('.') + 1);
        public virtual string Type { get; set; }
    }
}
