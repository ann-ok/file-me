using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    [Authorize]
    public class FolderController : Controller
    {
        private FolderRepository folderRepository;

        public FolderController(FolderRepository folderRepository)
        {
            this.folderRepository = folderRepository;
        }

        public ActionResult Index(long? parent, FetchOptoins fetchOptions)
        {
            Folder parentFolder = null;

            if (parent.HasValue)
            {
                parentFolder = folderRepository.Load(parent.Value);
            }

            var model = new FolderListModel
            {
                Items = folderRepository.Find(new FolderFilter { Parent = parentFolder }, fetchOptions),
                CurrentFolder = parentFolder,
                Parent = parentFolder != null ? parentFolder.Parent : null,
            };

            model.IsRootFolder = parent == null && model.Parent == null;
            return View("Index", model);
        }

        public ActionResult Create(long? parent)
        {
            var model = new FolderModel
            {
                ParentId = parent
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FolderModel model)
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

            var folder = new Folder
            {
                Name = model.Name,
                CreationDate = DateTime.Now,
                Parent = parent
            };

            folderRepository.Save(folder);

            return RedirectToAction("Index", new { parent = model.ParentId });
        }

        /*
        public ActionResult CreateDct(long? parent)
        {
            var model = new FolderModel
            {
                ParentId = parent,
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateDct(FolderModel model)
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

            var dct = new Dct()
            {
                Name = model.Name,
                CreationDate = DateTime.Now,
                Parent = parent,
                //дописать присвоение документа
            };

            dctRepository.Save(dct);

            return RedirectToAction("Index", new { parent = model.ParentId });
        }
        */
    }
}