using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Validation
{
    public class ValidationException : ApplicationException
    {
        public readonly ValidationResultBase FirstError;
        
        public IEnumerable<ValidationResultItem> GetItems()
        {
            return FirstError.GetItems();
        }

        internal ValidationException(ValidationResultBase firstError)
        {
            FirstError = firstError;
        }
    }
}
