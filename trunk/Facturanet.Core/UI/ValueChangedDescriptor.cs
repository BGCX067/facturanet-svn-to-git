using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.ComponentModel;

using System.Reflection;


namespace Facturanet.UI
{
    /// <summary>
    /// Represent a property with the original and new values.
    /// </summary>
    public struct ValueChangedDescriptor
    {
        public readonly string PropertyName;
        public readonly object OriginalValue;
        public readonly object NewValue;

        private static object GetDefaultTypeValue(Type targetType)
        {
            return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;
        }

        private static string Quoted(object value)
        {
            if (value == null)
                return "null";
            else
                return string.Format("'{0}'", value);
        }

        public ValueChangedDescriptor(string propertyName, object originalValue, object newValue)
        {
            if (propertyName == null)
                throw new ArgumentNullException("propertyName", "propertyName can't be null.");
            else if (propertyName == string.Empty)
                throw new ArgumentException("propertyName", "propertyName can't be an empty string.");
            else if (originalValue == null && newValue == null)
                throw new ArgumentNullException("originalValue, newValue", "originalValue and newValue can't be both null.");
            else
            {
                PropertyName = propertyName;
                OriginalValue = originalValue ?? GetDefaultTypeValue(newValue.GetType());
                NewValue = newValue ?? GetDefaultTypeValue(originalValue.GetType());
            }
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}=>{2}; ", PropertyName, Quoted(OriginalValue), Quoted(NewValue));
        }
    }

    /// <summary>
    /// Collection of changes properties with the original and new values.
    /// </summary>
    public class ValueChangedDescriptorCollection : KeyedCollection<string, ValueChangedDescriptor>
    {
        static public ValueChangedDescriptorCollection CreateEmpty()
        {
            return new ValueChangedDescriptorCollection();
        }

        protected override string GetKeyForItem(ValueChangedDescriptor item)
        {
            return item.PropertyName;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
                sb.Append(item.ToString());
            return sb.ToString();
        }

        public void Add(string propertyName, object originalValue, object newValue)
        {
            base.Add(new ValueChangedDescriptor(propertyName, originalValue, newValue));
        }
    }
}
