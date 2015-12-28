using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Facturanet.Entities.Base
{
    public abstract class InvoiceBase : Entity
    {
        public virtual string FiscalType { get; set; }
        public virtual string Number { get; set; }
        public virtual DateTime Date { get; set; }
        public abstract string EnterpriseCode { get; set; }
        public abstract string CustomerCode { get; set; }
        public abstract string CustomerName { get; set; }
        public abstract double Total { get; set; }
    }
}

namespace Facturanet.Entities
{
    public class Invoice : Base.InvoiceBase
    {
        public virtual Enterprise Enterprise { get; set; }
        public virtual Customer Customer { get; set; }

        private IList<InvoiceItem> items = new List<InvoiceItem>();
        public virtual IList<InvoiceItem> Items
        {
            get { return items; }
            set { items = value; }
        }

        [IgnoreDataMember]
        public override string EnterpriseCode 
        {
            get { return Enterprise.Code; }
            set { throw new UI.UIObjectImplementationException(); }
        }

        [IgnoreDataMember]
        public override string CustomerCode 
        {
            get { return Customer.Code; }
            set { throw new UI.UIObjectImplementationException(); }
        }

        [IgnoreDataMember]
        public override string CustomerName 
        {
            get { return Customer.Name; }
            set { throw new UI.UIObjectImplementationException(); }
        }

        [IgnoreDataMember]
        public override double Total 
        {
            get { return Items.Sum(i => i.Total); }
            set { throw new UI.UIObjectImplementationException(); }
        }
    }
}




