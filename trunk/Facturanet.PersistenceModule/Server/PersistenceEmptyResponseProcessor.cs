using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Facturanet.Server
{
    public abstract class PersistenceEmptyResponseProcessor<RequestType> : PersistenceProcessor<RequestType, EmptyResponse>
        where RequestType : BaseRequest<EmptyResponse>
    {
        protected override sealed EmptyResponse RunInContext(RequestType request, PersistenceContext context)
        {
            RunInContextEmptyResponse(request, context);
            return new EmptyResponse();
        }

        protected abstract void RunInContextEmptyResponse(RequestType request, PersistenceContext context);
    }
}
