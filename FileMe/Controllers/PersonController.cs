using FileMe.DAL.Classes;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class PersonController : Controller
    {
        private PersonRepository personRepository;

        public PersonController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public ActionResult Create()
        {
            var model = new PersonModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var person = new Person
            {
                Login = model.Login,
                Password = model.Password,
                //Group = model.Group,
            };

            personRepository.Save(person);

            return RedirectToAction("Index", "Home");
        }
    }
}