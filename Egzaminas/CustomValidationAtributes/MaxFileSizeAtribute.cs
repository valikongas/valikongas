using System.ComponentModel.DataAnnotations;

namespace Egzaminas.CustomValidationAtributes
{
    public class MaxFileSizeAtribute: ValidationAttribute
    {
        private readonly int _maxFileSize;

        public MaxFileSizeAtribute(int maxFileSize)
        {
            _maxFileSize = maxFileSize;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSize)
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        public string GetErrorMessage()
        {
            return $"Maximum allowed file size is {_maxFileSize} bytes.";
        }
    }
}
