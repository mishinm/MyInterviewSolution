using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Helper
{
    public class CustomRequired : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string errorType;
            if (value == null || string.IsNullOrEmpty(value.ToString()) )
            {
                errorType = "обязательное";
            }
            else
            {
                return ValidationResult.Success;
            }
            ErrorMessage = $"Поле {validationContext.DisplayName} {errorType}.";
            return new ValidationResult(ErrorMessage);
        }
       
    }
}
