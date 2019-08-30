namespace FileMe.DAL.Classes
{
    public class Dct : Folder
    {
        public virtual string Type { get; set; }

        public override bool IsFile => true;
    }
}
