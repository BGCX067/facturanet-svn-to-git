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
    internal class CreateAccountTreeProcessor : PersistenceEmptyResponseProcessor<CreateAccountTreeRequest>
    {
        protected override void RunInContextEmptyResponse(CreateAccountTreeRequest request, PersistenceContext context)
        {
            context.Session.Save(request.AccountTree);
        }
    }
}
