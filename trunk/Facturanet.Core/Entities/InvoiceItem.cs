using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;


namespace Facturanet.Entities.Base
{
    // TODO: Sacar la herencia de Entity?
    public abstract class InvoiceItemBase : Entity
    {
        public virtual int InvoiceLine { get; set; }
        public virtual double Quantity { get; set; }
        public virtual double Price { get; set; }
        public virtual double Total 
        {
            get { return Quantity * Price; }
        }
    }
}

namespace Facturanet.Entities
{
    public class InvoiceItem : Base.InvoiceItemBase
    {
        public virtual Product Product { get; set; }
    }
}
