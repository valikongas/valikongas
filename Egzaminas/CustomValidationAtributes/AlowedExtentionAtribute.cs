﻿using System.ComponentModel.DataAnnotations;

namespace Egzaminas.CustomValidationAtributes
{

    public class AlowedExtentionAtribute : ValidationAttribute
    {
        private readonly string[] _extensions;

        public AlowedExtentionAtribute(string[] extensions)
        {
            _extensions = extensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);

                if (!_extensions.Contains(extension.ToLower()))
                {
                    return new ValidationResult(GetErrorMessage());
                }
            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return $"This photo extension is not allowed!";
        }

    }

}
