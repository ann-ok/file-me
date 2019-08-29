using FileMe.DAL.Filters;
using System.Web.Routing;

namespace FileMe.Models
{
    public class SortLinkModel
    {
        public string Action { get; set; }

        public string Controller { get; set; }

        public SortDirection? SortDirection { get; set; }

        public RouteValueDictionary RouteValues { get; set; }

        public string LinkText { get; set; }
    }
}