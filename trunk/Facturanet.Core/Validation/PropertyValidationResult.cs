using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Validation
{
    internal class PropertyValidationResult : ValidationResultBase
    {
        public readonly string Code;

        internal PropertyValidationResult(Level level, string code, string message, object[] messageData)
            : base(message, messageData)
        {
            Length = 1;
            Code = code;
            Level = level;
        }

        internal override IEnumerable<ValidationResultItem> GetItems(
            Level level,
            int depth,
            string[] propertiesChain)
        {
            if (Level > level)
                yield return new ValidationResultItem(propertiesChain, this);
            else
                yield break;
        }
    }
}
