using FileMe.Authorization;
using FileMe.Binders;
using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using FileMe.DAL.Repositories;
using FileMe.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class PersonController : BaseController
    {
        private PersonRepository personRepository;
        private GroupRepository groupRepository;

        //работа с пользователем идёт через менеджера
        public UserManager UserManager
        {
            get { return HttpContext.GetOwinContext().GetUserManager<UserManager>(); }
        }

        public PersonController(PersonRepository personRepository, GroupRepository groupRepository)
        {
            this.personRepository = personRepository;
            this.groupRepository = groupRepository;
        }

        public ActionResult Index(PersonFilter filter, FetchOptoins fetchOptoins, int page = 1)
        {
            int pageSize = 5;

            if (page != 1)
            {
                fetchOptoins.First = (page - 1) * pageSize + 1;
            }

            fetchOptoins.Count = pageSize;

            var model = new PersonListModel
            {
                Items = personRepository.Find(filter, fetchOptoins),
                CurrentPage = page,
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
                UserName = model.UserName,
                Email = model.Email,
                CreationDate = DateTime.Now,
                AvatarFile = model.AvatarFile != null ? model.AvatarFile.BinaryFile : null,
            };

            var res = UserManager.CreateAsync(person, model.Password);

            if (res.Result == IdentityResult.Success)
            {
                if (model.AvatarFile != null)
                {
                    GetFileProvider().Save(model.AvatarFile.BinaryFile, model.AvatarFile.PostedFile.InputStream);
                }

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public ActionResult Info(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = personRepository.Load(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            var model = new PersonModel()
            {
                FIO = person.FIO,
                UserName = person.UserName,
                Email = person.Email,
                GroupName = person.Group.Name,
                CreationDate = person.CreationDate,
                AvatarFile = new BinaryFileWrapper{ BinaryFile = person.AvatarFile },
            };

            return View(model);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var person = personRepository.Load(id);

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
                GroupName = person.Group.Name,
                CreationDate = person.CreationDate,
                AvatarFile = new BinaryFileWrapper { BinaryFile = person.AvatarFile },
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

            var person = personRepository.Load(id);

            Group group = groupRepository.Get(model.GroupName, "Name");

            person.FIO = model.FIO;
            person.UserName = model.UserName;
            person.Email = model.Email;
            person.Password = model.Password;
            person.CreationDate = DateTime.Now;
            person.Group = group;
            person.AvatarFile = model.AvatarFile != null ? model.AvatarFile.BinaryFile : null;

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

            var person = personRepository.Load(id);

            if (person == null)
            {
                return HttpNotFound();
            }

            var model = new PersonModel()
            {
                FIO = person.FIO,
                UserName = person.UserName,
                Email = person.Email,
                GroupName = person.Group.Name,
                CreationDate = person.CreationDate,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(PersonModel model, long? id)
        {
            var person = personRepository.Load(id);

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