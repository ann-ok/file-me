using System;

namespace FileMe.Models
{
    public class Folder
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreationDate { get; set; }

        public Folder ParentFolder { get; set; }

        public Folder() { }

        public Folder(int id, string title, DateTime date, Folder parentFolder)
        {
            Id = id;
            Title = title;
            CreationDate = date;
            ParentFolder = parentFolder;
        }
    }
}
