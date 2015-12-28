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

namespace Facturanet.Server
{
    internal class CompositeProcessor : PersistenceProcessor<CompositeRequest, CompositeResponse>
    {
        protected override CompositeResponse RunInContext(CompositeRequest requests, PersistenceContext context)
        {
            CompositeResponse response = new CompositeResponse();

            foreach (Request request in requests.Requests)
                response.Responses.Add(request.Run(context));

            return response;            
        }
    }
}
