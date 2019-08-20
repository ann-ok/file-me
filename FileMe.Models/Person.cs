using System;

namespace FileMe.Models
{
    public class Person
    {
        private Groups group;

        private int Id { get; set; }

        private string login;

        private string Login
        {
            get { return login; }
            set
            {
                if (value == "") throw new Exception();
                login = value;
            }
        }

        private string password;

        private string Password
        {
            get { return password; }
            set
            {
                if (value == "") throw new Exception();
                password = value;
            }
        }

        public Person(string login, string password, Groups group)
        {
            Id = GetId();
            Login = login;
            Password = password;
            this.group = group;
        }

        private int GetId()
        {
            return 1;
        }

        public string GetLogin() => Login;

        public static implicit operator string(Person person) => person.GetLogin();
    }

    //Сделаны пока перечислением, а не отдельным классом, так как пока не вижу необходимости в классе.
    public enum Groups
    {
        User,
        Admin
    }
}
