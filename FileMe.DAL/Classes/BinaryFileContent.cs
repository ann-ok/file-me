namespace FileMe.DAL.Classes
{
    public class BinaryFileContent
    {
        public virtual long Id { get; set; }

        public virtual BinaryFile BinaryFile { get; set; }

        public virtual byte[] Content { get; set; }
    }
}
