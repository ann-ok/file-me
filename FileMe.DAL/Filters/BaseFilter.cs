namespace FileMe.DAL.Filters
{
    public abstract class BaseFilter
    {
        public long? Id { get; set; }

        public string SearchString { get; set; }
    }
}
