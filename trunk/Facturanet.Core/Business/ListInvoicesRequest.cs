using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using System.Runtime.Serialization;
using Facturanet.Entities;

namespace Facturanet.Business
{
    [DataContract]
    public class ListInvoicesRequest : BaseRequest<ListInvoicesResponse>
    {
        Selector<Enterprise> EnterpriseSelector { get; set; }
        Selector<Customer> CustomerSelector { get; set; }
        DateTime? DateFrom { get; set; }
        DateTime? DateTo { get; set; }
    }
}
