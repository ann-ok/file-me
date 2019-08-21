namespace FileMe.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public Group Group { get; set; }

        public Person() { }

        public Person(int id, string login, string password, Group group)
        {
            Id = id;
            Login = login;
            Password = password;
            Group = group;
        }
    }
}
