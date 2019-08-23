using FileMe.DAL.Classes;
using FileMe.DAL.Repositories;
using FileMe.Models;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class UserController : Controller
    {
        private UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public ActionResult Create()
        {
            var model = new UserModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User
            {
                FIO = model.FIO,
                Password = model.Password
            };
            userRepository.Save(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
    
