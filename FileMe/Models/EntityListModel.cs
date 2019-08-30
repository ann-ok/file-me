using System.Collections.Generic;

namespace FileMe.Models
{
    public class EntityListModel<T>
    {
        public IList<T> Items { get; set; }

        public int CurrentPage { get; set; }
    }
}