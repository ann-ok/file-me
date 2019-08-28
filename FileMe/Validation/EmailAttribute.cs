using FileMe.DAL.Repositories;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace FileMe.Validation
{
    public class EmailAttribute: ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                var email = value.ToString();
                var personRepository = DependencyResolver.Current.GetService<PersonRepository>();

                return !personRepository.Exists(email, "Email");
            }

            return false;
        }
    }
}