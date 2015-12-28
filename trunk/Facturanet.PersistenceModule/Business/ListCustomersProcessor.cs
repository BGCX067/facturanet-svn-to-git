using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using Facturanet.Business;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Facturanet.Business
{
    internal class ListCustomersProcessor : PersistenceProcessor<ListCustomersRequest, ListCustomersResponse>
    {
        protected override ListCustomersResponse RunInContext(ListCustomersRequest request, PersistenceContext context)
        {
            //IList<Lines.ILineCustomer> list = context.Session.CreateCriteria(typeof(Entities.Customer)).List<Lines.ILineCustomer>();
            //return new ListCustomersResponse() { List = list };
            /***/
            return new ListCustomersResponse();
        }

    }
}
