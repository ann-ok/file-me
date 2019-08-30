using FileMe.DAL.Classes;
using FileMe.DAL.Filters;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    [Authorize]
    public class FolderController : Controller
    {
        private FolderRepository folderRepository;
        //private DctRepository dctRepository;

        public FolderController(FolderRepository folderRepository)//, DctRepository dctRepository)
        {
            this.folderRepository = folderRepository;
            //this.dctRepository = dctRepository;
        }

        public ActionResult Index(long? parent, FetchOptoins fetchOptions)//, FolderFilter folderFilter, DctFilter dctFilter)
        {
            Folder parentFolder = null;
            if (parent.HasValue)
            {
                parentFolder = folderRepository.Load(parent.Value);
            }
            var model = new FolderListModel
            {
                Items = folderRepository.Find(new FolderFilter { Parent = parentFolder }),//, fetchOptions),
                CurrentFolder = parentFolder,
                Parent = parentFolder != null ? parentFolder.Parent : null
            };
            model.IsRootFolder = parent == null && model.Parent == null;
            return View("Index", model);
            /*
            Folder parentFolder = null;

            if (parent.HasValue)
            {
                parentFolder = folderRepository.Load(parent.Value);
            }

            folderFilter.Parent = parentFolder;

            List<Folder> listFolder = (List<Folder>)folderRepository.Find(folderFilter, fetchOptoins);
            listFolder.AddRange((List<Folder>)dctRepository.Find(dctFilter, fetchOptoins));

            var model = new FolderListModel
            {
                Items = listFolder,
                CurrentFolder = parentFolder,
                Parent = parentFolder != null ? parentFolder.Parent : null,
            };

            model.IsRootFolder = (parent == null && model.Parent == null);

            return View(model);
            */
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