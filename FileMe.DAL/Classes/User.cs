namespace FileMe.DAL.Classes
{
    public class User
    {
        public virtual long Id { get; set; }

        public virtual string FIO { get; set; }

        public virtual string Password { get; set; }
    }
}
