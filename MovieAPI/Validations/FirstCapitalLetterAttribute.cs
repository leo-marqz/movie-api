using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Validations
{
    public class FirstCapitalLetterAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
           if(value is null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string firstLetter = value.ToString()![0].ToString();

            if(firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("La primer letra debe ser mayuscula!");
            }
            return ValidationResult.Success;
        }
    }
}
