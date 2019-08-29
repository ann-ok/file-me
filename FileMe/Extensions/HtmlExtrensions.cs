using FileMe.DAL.Filters;
using FileMe.Models;
using System;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace FileMe.Extensions
{
    public static class HtmlExtensions
    {
        //возращается разметка
        public static MvcHtmlString SortLink(this HtmlHelper html,
            string linkText,
            string sortExpression,
            string action,
            string controller,
            RouteValueDictionary routeValues)
        {
            routeValues = routeValues ?? new RouteValueDictionary();

            SortDirection? sort = null;

            var sortDirectionStr = html.ViewContext.HttpContext.Request["SortDirection"];

            if (!string.IsNullOrEmpty(sortDirectionStr) &&
                html.ViewContext.HttpContext.Request["SortExpression"] == sortExpression)
            {
                SortDirection s;
                if (Enum.TryParse(sortDirectionStr, out s))
                {
                    sort = s;
                }
            }

            routeValues["SortExpression"] = sortExpression;

            routeValues["SortDirection"] = sort.HasValue && sort.Value == SortDirection.Asc ?
                SortDirection.Desc :
                SortDirection.Asc;

            var model = new SortLinkModel();

            if (routeValues.ContainsKey("ParentId"))
            {
                SortLinkFolderModel folderModel = new SortLinkFolderModel
                {
                    ParentId = (long?)routeValues["ParentId"]
                };
                model = folderModel;
            }

            model.Action = action;
            model.Controller = controller;
            model.SortDirection = sort;
            model.RouteValues = routeValues;
            model.LinkText = linkText;

            return html.Partial("SortLink", model);
        }
    }
}