using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Entities;

namespace Facturanet.UI
{
    public class InvoicesListItem : Entities.Base.InvoiceBase, UI.IUIObject
    {
        public override string EnterpriseCode { get; set; }

        public override string CustomerCode { get; set; }

        public override string CustomerName { get; set; }

        public override double Total { get; set; }
        
        public Entities.Base.InvoiceBase CopyFromInvoice
        {
            set
            {
                Date = value.Date;
                FiscalType = value.FiscalType;
                Id = value.Id;
                Number = value.Number;
                EnterpriseCode = value.EnterpriseCode;
                CustomerCode = value.CustomerCode;
                CustomerName = value.CustomerName;
                Total = value.Total;
            }
        }
    }
}
