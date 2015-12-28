using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using Facturanet.WebserviceModule;

namespace Facturanet.Server
{
    internal class VirtualProcessor : IProcessor
    {
        public Response Run(Request request, IContext context)
        {
            return WebserviceProcessorFactory.ServiceClient.Run(request);
        }
    }
}
