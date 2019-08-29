namespace FileMe.DAL.Filters
{
    public class FetchOptoins
    {
        public string SortExpression { get; set; }

        public SortDirection SortDirection { get; set; }

        public int? First { get; set; }

        public int? Count { get; set; }
    }

    public enum SortDirection
    {
        Asc,
        Desc
    }
}
