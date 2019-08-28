using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FileMe.Validation
{
    public class PasswordAttribute: ValidationAttribute
    {
        public PasswordAttribute(int minLenght)
        {
            MinLenght = minLenght;
        }
        public int MinLenght { get; private set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var password = value.ToString();

                if (password.Length < MinLenght)
                {
                    return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                }
                else
                {
                    return null;
                }
            }

            return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
        }
    }
}