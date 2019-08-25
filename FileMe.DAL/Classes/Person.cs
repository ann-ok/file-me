namespace FileMe.DAL.Classes
{
    public class Person
    {
        public virtual long Id { get; set; }

        public virtual string Login { get; set; }

        public virtual string Password { get; set; }

        //public virtual Group Group { get; set; }
    }
}
