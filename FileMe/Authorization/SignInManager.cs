using FileMe.DAL.Classes;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace FileMe.Authorization
{
    public class SignInManager : SignInManager<Person, long>
    {
        public SignInManager(UserManager<Person, long> userManager, 
            IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public void SignOut()
        {
            //используем авторизацию через куки
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }
}