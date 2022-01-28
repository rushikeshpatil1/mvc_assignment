using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Validations.Models
    {
        public class HobbiesAttribute : ValidationAttribute

        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                user user = (user)value;
                List<bool> allHobbies = new List<bool>() { user.Dance, user.Gardening, user.Hiking, user.Painting, user.Photography };
                List<bool> selectedHobbies = allHobbies.FindAll(hobby => hobby);
                if (selectedHobbies.Count >= 1 && selectedHobbies.Count <= 4)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult(this.ErrorMessage);
                }
            }
        }
    }
