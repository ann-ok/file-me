using System;

namespace FileMe.DAL.Classes
{
    public class Person
    {
        public Person() { }

        public Person(Group group)
        {
            if (group == null)
                throw new ArgumentNullException("У пользователя не задана группа");

            group.People.Add(this);
            Group = group;
        }

        public virtual long Id { get; protected set; }

        [FastSearch(FiledType = FiledType.ComplexEntity)]
        public virtual Group Group { get; set; }

        [FastSearch]
        public virtual string FIO { get; set; }

        [FastSearch]
        public virtual string Login { get; set; }

        [FastSearch]
        public virtual string Email { get; set; }

        public virtual string Password { get; set; }

        public virtual DateTime CreationDate { get; set; }

        //public virtual Person CreationAuthor { get; set; }

    }
}
