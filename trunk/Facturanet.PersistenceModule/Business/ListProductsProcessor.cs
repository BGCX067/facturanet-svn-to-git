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
    internal class ListProductsProcessor : PersistenceProcessor<ListProductsRequest, ListProductsResponse>
    {
        protected override ListProductsResponse RunInContext(ListProductsRequest request, PersistenceContext context)
        {
            //IList<Lines.ILineProduct> list = context.Session.CreateCriteria(typeof(Entities.Product)).List<Lines.ILineProduct>();
            //return new ListProductsResponse() { List = list };
            /***/
            return new ListProductsResponse();
        }

    }
}
