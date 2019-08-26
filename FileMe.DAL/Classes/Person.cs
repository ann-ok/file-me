using System;

namespace FileMe.DAL.Classes
{
    public class Person
    {
        public Person() { }

        public Person(Group group)
        {
            if (group == null)
                throw new ArgumentNullException("group");

            group.People.Add(this);
            Group = group;
        }

        public virtual long Id { get; protected set; }

        public virtual Group Group { get; protected set; }

        public virtual string FIO { get; set; }

        public virtual string Login { get; set; }

        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        //public virtual Person CreationAuthor { get; set; }

    }
}
