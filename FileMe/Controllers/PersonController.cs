using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System;
using System.Collections.Generic;
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
            var model = new PersonModel
            {
                Groups = new List<SelectListItem>(),
            };

            foreach (var group in groupRepository.GetAll())
            {
                model.Groups.Add(new SelectListItem() { Value = group.Name, Text = group.Name });
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(PersonModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Group group = groupRepository.GetGroup(model.GroupName);
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
    }
}