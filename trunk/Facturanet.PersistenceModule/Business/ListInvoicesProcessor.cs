using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Entities;
using Facturanet.Server;
using Facturanet.Business;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Facturanet.NHUtil;

namespace Facturanet.Business
{
    internal class ListInvoicesProcessor : PersistenceProcessor<ListInvoicesRequest, ListInvoicesResponse>
    {
        protected override ListInvoicesResponse RunInContext(ListInvoicesRequest request, PersistenceContext context)
        {
            //Esto obtiene todas las facturas con sus items y realiza la suma en .net, 
            //después se podría optimizar trayendo la suma desde la db, pero 
            //repetimos el código en .net y en las consultas

            var response = new ListInvoicesResponse();
            response.Items = new List<UI.InvoicesListItem>(context.Session
                .GetNamedQuery("InvoicesList")
                .ToDTOEnumerable<UI.InvoicesListItem>("CopyFromInvoice"));

            return response;
        }

    }
}
