using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Validation
{
    public class ValidationResult : ValidationResultBase
    {
        Dictionary<string, ValidationResultBase> propertiesResults;

        public object Object { get; protected set; }

        internal ValidationResult(object obj)
            : base("", new object[] { })
        {
            propertiesResults = new Dictionary<string, ValidationResultBase>();
            Object = obj;
        }

        public static ValidationResult Create(object obj)
        {
            return new ValidationResult(obj);
        }

        public void Add(Level exceptionOverLevel, string propertyName, Level level, string code, string message)
        {
            Add(exceptionOverLevel, propertyName, null, level, code, message, new object[] { });
        }

        public void Add(Level exceptionOverLevel, string propertyName, object index, Level level, string code, string message, params object[] messageData)
        {
            var propertyValidationResult = new PropertyValidationResult(level, code, message, messageData);
            Add(exceptionOverLevel, propertyName, index, propertyValidationResult);
        }

        public void Add(Level exceptionOverLevel, string propertyName, ValidationResultBase propertyResult)
        {
            Add(exceptionOverLevel, propertyName, null, propertyResult);
        }

        public void Add(Level exceptionOverLevel, string propertyName, object index, ValidationResultBase propertyResult)
        {
            //solo admite un error por propiedad/index
            if (propertyResult.Level > Level.Empty)
            {
                string name = (index == null)
                    ? propertyName
                    : string.Format("{0}[{1}]", propertyName, index);
                propertiesResults.Add(name, propertyResult);
                Length++;
                if (propertyResult.Level > Level)
                    Level = propertyResult.Level;
            }

            if (propertyResult.Level > exceptionOverLevel)
                throw new ValidationException(this);
        }

        internal override IEnumerable<ValidationResultItem> GetItems(
                    Level level,
                    int depth,
                    string[] propertiesChain)
        {
            if (Level > level)
            {
                yield return new ValidationResultItem(propertiesChain, this);
                foreach (var propertyResult in this.propertiesResults)
                {
                    var items = propertyResult.Value.GetItems(level, depth - 1, propertiesChain, propertyResult.Key);
                    foreach (var item in items)
                        yield return item;
                }
            }
        }
    }
}
