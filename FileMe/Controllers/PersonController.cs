using FileMe.DAL.Classes;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class PersonController : Controller
    {
        private PersonRepository personRepository;

        public PersonController() { }

        public PersonController(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        // GET: Person
        public ActionResult Index()
        {
            return View();
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            var model = new PersonModel();
            return View(model);
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var person = new Person
                {
                    Login = model.Login,
                    Password = model.Password,
                    Group = new Group { Title = "Человек"}
                };

                personRepository.Save(person);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View(model);
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
