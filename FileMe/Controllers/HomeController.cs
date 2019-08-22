using FileMe.Models;
using FileMe.Models.Repositories;
using System;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class HomeController : Controller
    {
        private PersonRepository personRepository;

        public HomeController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        // GET: Home
        //метод который возвращает представление. Модель он будет искать в папке views.
        public ActionResult Index()
        {
            var model = new HomeModel
            {
                Title = "Крутое приложение",
                Time = DateTime.Now
            };

            return View(model);
        }

        //пост запрос
        [HttpPost]
        public ActionResult Index(HomeModel model)
        {
            //связывание параметра метода с данными связывает данные с сервера с моделью
            //model.Time = DateTime.Now;
            return View(model);

        }
    }
}