using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Facturanet.Server
{
    public abstract class PersistenceProcessor<RequestType, ResponseType> : Processor<RequestType, ResponseType>
        where RequestType : BaseRequest<ResponseType>
        where ResponseType : Response
    {
        public override sealed ResponseType Run(RequestType request, IContext context)
        {
            if (context == null)
            {
                ResponseType response = null;

                using (var session = NHibernateHelper.SessionFactory.OpenSession())
                using (var transaction = session.BeginTransaction())
                {
                    response = RunInContext(request, new PersistenceContext(session, transaction));
                    transaction.Commit();
                } 

                return response;
            }
            else
                return RunInContext(request, context as PersistenceContext);
        }

        protected abstract ResponseType RunInContext(RequestType request, PersistenceContext context);
    }
}
