using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System.Net;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    [Authorize]
    public class GroupController: Controller
    {
        private GroupRepository groupRepository;

        public GroupController(GroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
        }

        public ActionResult Index(GroupFilter filter, FetchOptoins fetchOptoins)
        {
            var model = new GroupListModel
            {
                Items = groupRepository.Find(filter, fetchOptoins)
            };

            return View(model);
        }

        public ActionResult Create()
        {
            var model = new GroupModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(GroupModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var group = new Group
            {
                Name = model.Name
            };

            groupRepository.Save(group);

            return RedirectToAction("SortLink");
        }

        public ActionResult SortLink()
        {
            var model = new SortLinkModel();

            return View(model);
        }

        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = GetModelById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GroupModel model, long? id)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var group = groupRepository.Load(id);

            group.Name = model.Name;

            try
            {
                groupRepository.Update(group);
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

            var model = GetModelById(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(GroupModel model, long? id)
        {
            var group = groupRepository.Load(id);

            try
            {
                groupRepository.Delete(group);
                return RedirectToAction("Index");
            }
            catch
            {
                return HttpNotFound();
            }
        }

        private GroupModel GetModelById(long? id)
        {
            var group = groupRepository.Load(id);

            if (group == null)
            {
                return null;
            }

            return new GroupModel() { Name = group.Name, People = group.People };
        }
    }
}