using FileMe.Models;
using System;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new HomeModel
            {
                Title = "Крутое приложение",
                Time = DateTime.Now
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeModel model, string inputTitle)
        {
            model.Time = DateTime.Now;
            model.Title = inputTitle;

            return View(model);
        }
    }
}