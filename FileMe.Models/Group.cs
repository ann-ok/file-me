namespace FileMe.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Group() { }

        public Group(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
