using FileMe.DAL.Classes;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class DctController : Controller
    {
        private DctRepository dctRepository;
        private FolderRepository folderRepository;

        public DctController(DctRepository dctRepository, FolderRepository folderRepository)
        {
            this.dctRepository = dctRepository;
            this.folderRepository = folderRepository;
        }

        public ActionResult Create(long? parent)
        {
            var model = new DctModel
            {
                ParentId = parent
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DctModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Folder parent = null;

            if (model.ParentId.HasValue)
            {
                parent = folderRepository.Load(model.ParentId.Value);
            }

            var folder = new Dct
            {
                Name = $"{model.Name}.{model.Type}",
                CreationDate = DateTime.Now,
                Parent = parent,
                Type = model.Type
            };

            dctRepository.Save(folder);

            return RedirectToAction("Index", "Folder", new { parent = model.ParentId });
        }
    }
}