using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using MVC6WebApi.Models;

namespace MVC6WebApi.CustomValidation
{
    public class Min18Years : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var student = (Student)validationContext.ObjectInstance;
            if (student.DOB == null)
            {
                return new ValidationResult("Date of Birth is required");
            }

            var age = DateTime.Today.Year - student.DOB.Year;

            return (age >= 18) ?
                ValidationResult.Success
                : new ValidationResult("Student should ne atleast 18 years old");
        }
    }
}
