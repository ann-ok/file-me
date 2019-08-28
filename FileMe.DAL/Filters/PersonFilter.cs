using FileMe.DAL.Classes;
using System;
using System.Collections.Generic;

namespace FileMe.DAL.Filters
{
    public class PersonFilter: BaseFilter
    {
        public IList<Group> Group { get; set; }

        public string FIO { get; set; }

        public string Login { get; set; }

        public string Email { get; set; }

        public Range<DateTime> CreationDate { get; set; }
    }
}
