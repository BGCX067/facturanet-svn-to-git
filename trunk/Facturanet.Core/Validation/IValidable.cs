using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Validation
{
    public interface IValidable
    {
        ValidationResult GetValidationResult(Validation.Level exceptionOverLevel);
    }

    public static class IValidableExtensions
    {
        /// <summary>
        /// Gets the complete validation result of the object.
        /// </summary>
        public static ValidationResultBase GetValidationResult(this IValidable validable)
        {
            return validable.GetValidationResult(Level.Max);
        }

        /// <summary>
        /// If there are any error in the object it returns false;
        /// </summary>
        public static bool IsValid(this IValidable validable)
        {
            bool isValid = true;
            try
            {
                validable.GetValidationResult(Level.Empty);
            }
            catch (Validation.ValidationException)
            {
                isValid = false;
            }
            return isValid;
        }
    }
}
