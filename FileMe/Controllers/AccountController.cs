using FileMe.Authorization;
using FileMe.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Web;
using System.Web.Mvc;

namespace FileMe.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<SignInManager>(); }
        }

        //перенаправляем, когда нет авторизации
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

        //проверка пользователя на существование (через SignInManager)
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = SignInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Result == SignInStatus.Success)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            SignInManager.SignOut();

            return RedirectToAction("Login");
        }
    }
}