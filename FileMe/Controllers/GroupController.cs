using FileMe.DAL.Classes;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class GroupController: Controller
    {
        private GroupRepository groupRepository;

        public GroupController(GroupRepository groupRepository)
        {
            this.groupRepository = groupRepository;
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
                Title = model.Title
            };

            groupRepository.Save(group);

            return RedirectToAction("Index", "Home");
        }
    }
}