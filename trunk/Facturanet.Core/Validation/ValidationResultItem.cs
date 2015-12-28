using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Validation
{
    public class ValidationResultItem
    {
        public readonly string[] PropertiesChain;
        public readonly string Message;
        public readonly object[] MessageData;
        public readonly Level Level;

        public readonly string Code = null; 
        public readonly Object Object = null;

        internal ValidationResultItem(string[] propertiesChain, PropertyValidationResult result)
        {
            PropertiesChain = propertiesChain;
            Message = result.Message;
            MessageData = result.MessageData;
            Code = result.Code;
            Level = result.Level;
        }

        internal ValidationResultItem(string[] propertiesChain, ValidationResult result)
        {
            PropertiesChain = propertiesChain;
            Message = result.Message;
            MessageData = result.MessageData;
            Object = result.Object;
            Level = result.Level;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < PropertiesChain.Length; i++)
                sb.Append("\t");
            if (PropertiesChain.Length > 0)
                sb.AppendFormat("{0}: ", PropertiesChain[PropertiesChain.Length - 1]);
            if (Object != null)
                sb.Append(Object);
            sb.AppendFormat(Message, MessageData);
            return sb.ToString();
        }
    }
}
