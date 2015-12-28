using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Server
{
    public abstract class Processor<RequestType, ResponseType> : IProcessor
        where RequestType : BaseRequest<ResponseType>
        where ResponseType : Response
    {
        public abstract ResponseType Run(RequestType request, IContext context);

        Response IProcessor.Run(Request request, IContext context)
        {
            return Run((RequestType)request, context);
        }
    }
}
