using FileMe.DAL.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FileMe.Validation
{
    public class LoginAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var login = value.ToString();
                var personRepository = DependencyResolver.Current.GetService<PersonRepository>();

                return !personRepository.Exists(login, "UserName");
            }

            return false;
        }
    }
}