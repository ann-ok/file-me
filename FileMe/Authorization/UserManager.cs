using FileMe.DAL.Classes;
using Microsoft.AspNet.Identity;

namespace FileMe.Authorization
{
    public class UserManager : UserManager<Person, long>
    {
        public UserManager(IUserStore<Person, long> store) : base(store)
        {
            UserValidator = new UserValidator<Person, long>(this);
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 5
            };
        }
    }
}