using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Validation
{
    public abstract class ValidationResultBase
    {
        //Lo ideal tal vez sería que este objeto vaya consultando o validando al objeto principal
        //a medida que se le va solicitando, pero no que valide todo de una.
        public Level Level { get; protected set; }
        public int Length { get; protected set; }

        public readonly string Message;
        public readonly object[] MessageData;

        internal ValidationResultBase(string message, params object[] messageData) 
        {
            Length = 0;
            Level = Level.Empty;
            Message = message;
            MessageData = messageData;
        }
        
        public IEnumerator<ValidationResultItem> GetEnumerator()
        {
            return GetItems().GetEnumerator();
        }

        public IEnumerable<ValidationResultItem> GetItems()
        {
            return GetItems(Level.Empty);
        }

        public IEnumerable<ValidationResultItem> GetItems(Level level)
        {
            return GetItems(level, -1);
        }

        public IEnumerable<ValidationResultItem> GetItems(Level level, int depth)
        {
            return GetItems(level, -1, new string[] { });
        }

        internal abstract IEnumerable<ValidationResultItem> GetItems(
            Level level,
            int depth,
            string[] propertiesChain);

        internal IEnumerable<ValidationResultItem> GetItems(
            Level level,
            int depth,
            string[] propertiesChainSub1,
            string property)
        {
            string[] propertiesChain = propertiesChainSub1.Concat(new string[] {property}).ToArray();
            return GetItems(level, depth, propertiesChain);
        }

        public string GetResultText()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in this)
                sb.AppendLine(item.ToString());
            return sb.ToString();
        }
    }
}
