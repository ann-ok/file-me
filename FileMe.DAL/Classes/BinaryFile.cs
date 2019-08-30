namespace FileMe.DAL.Classes
{
    public class BinaryFile
    {
        public virtual long Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string ContentType { get; set; }

        public virtual long Length { get; set; }
    }
}
