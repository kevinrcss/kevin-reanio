using System.ComponentModel.DataAnnotations;

namespace DelfostiChallenge.DTO.Validations
{
    public class NullablePositiveInteger : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return ValidationResult.Success;
            }

            if (value is int intValue)
            {
                if (intValue > 0)
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult(ErrorMessage ?? "El valor no es válido.");
        }
    }
}
