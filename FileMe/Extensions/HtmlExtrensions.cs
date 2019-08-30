using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using FileMe.DAL.Repositories;
using FileMe.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Web;
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

            var model = new SortLinkModel
            {
                Action = action,
                Controller = controller,
                SortDirection = sort,
                RouteValues = routeValues,
                LinkText = linkText
            };

            return html.Partial("SortLink", model);
        }

        public static Person CurrentPerson(this HtmlHelper html)
        {
            //достаем пользователя из контекста
            var principal = HttpContext.Current.User;

            //если нет пользователя -> нет авторизации
            if (principal == null)
            {
                return null;
            }

            //если есть лучаем его id
            var currentPersonId = principal.Identity.GetUserId<long>();
            var personRepository = DependencyResolver.Current.GetService<PersonRepository>();
            return personRepository.Load(currentPersonId);
        }

        //для отображения логина пользователя
        public static MvcHtmlString DisplayCurrentPerson(this HtmlHelper html)
        {
            var user = CurrentPerson(html);
            if (user == null)
            {
                return MvcHtmlString.Empty;
            }
            return MvcHtmlString.Create(user.UserName);
        }

        public static string DisplayLogOutString(this HtmlHelper html)
        {
            var user = CurrentPerson(html);
            if (user == null)
            {
                return "Войти";
            }
            return "Выйти";
        }
    }
}