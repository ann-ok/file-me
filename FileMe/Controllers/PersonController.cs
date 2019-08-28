using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class PersonController : Controller
    {
        private PersonRepository personRepository;
        private GroupRepository groupRepository;

        public PersonController(PersonRepository personRepository, GroupRepository groupRepository)
        {
            this.personRepository = personRepository;
            this.groupRepository = groupRepository;
        }

        public ActionResult Index(PersonFilter filter)
        {
            var model = new PersonListModel
            {
                Items = personRepository.Find(filter)
            };

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new PersonModel();

            ViewBag.Groups = new List<SelectListItem>();

            foreach (var group in groupRepository.GetAll())
            {
                ViewBag.Groups.Add(new SelectListItem() { Value = group.Name, Text = group.Name });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = new List<SelectListItem>();

                foreach (var g in groupRepository.GetAll())
                {
                    ViewBag.Groups.Add(new SelectListItem() { Value = g.Name, Text = g.Name });
                }

                return View(model);
            }

            Group group = groupRepository.Get(model.GroupName, "Name");
            var person = new Person(group)
            {
                FIO = model.FIO,
                Login = model.Login,
                Email = model.Email,
                Password = model.Password,
                CreationDate = DateTime.Now,
            };

            personRepository.Save(person);

            return RedirectToAction("Index");
        }

        public ActionResult Info(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = personRepository.Get(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            var model = new PersonModel()
            {
                FIO = person.FIO,
                Login = person.Login,
                Email = person.Email,
                GroupName = person.Group.Name,
                CreationDate = person.CreationDate,
            };

            return View(model);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = personRepository.Get(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            ViewBag.Groups = new List<SelectListItem>();

            foreach (var g in groupRepository.GetAll())
            {
                ViewBag.Groups.Add(new SelectListItem() { Value = g.Name, Text = g.Name });
            }

            var model = new PersonModel()
            {
                FIO = person.FIO,
                Login = person.Login,
                Email = person.Email,
                GroupName = person.Group.Name,
                CreationDate = person.CreationDate,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(PersonModel model, long? id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Groups = new List<SelectListItem>();

                foreach (var g in groupRepository.GetAll())
                {
                    ViewBag.Groups.Add(new SelectListItem() { Value = g.Name, Text = g.Name });
                }

                return View(model);
            }

            var person = personRepository.Get(id);

            Group group = groupRepository.Get(model.GroupName, "Name");

            person.FIO = model.FIO;
            person.Login = model.Login;
            person.Email = model.Email;
            person.Password = model.Password;
            person.CreationDate = DateTime.Now;
            person.Group = group;

            try
            {
                personRepository.Update(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return HttpNotFound();
            }
        }

        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = personRepository.Get(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            var model = new PersonModel()
            {
                FIO = person.FIO,
                Login = person.Login,
                Email = person.Email,
                GroupName = person.Group.Name,
                CreationDate = person.CreationDate,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(PersonModel model, long? id)
        {
            var person = personRepository.Get(id);

            try
            {
                personRepository.Delete(person);
                return RedirectToAction("Index");
            }
            catch
            {
                return HttpNotFound();
            }
        }
    }
}