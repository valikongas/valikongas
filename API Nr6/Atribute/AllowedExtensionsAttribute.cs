using System.ComponentModel.DataAnnotations;

namespace API_Nr6.Atribute
{

    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;

        public AllowedExtensionsAttribute(params string[] allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!_allowedExtensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult($"This file extension is not allowed.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
