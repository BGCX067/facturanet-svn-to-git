using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Entities;
using Facturanet.Server;
using Facturanet.Business;


namespace Facturanet.Server
{
    internal class CompositeProcessor : Processor<CompositeRequest, CompositeResponse>
    {
        public override CompositeResponse Run(CompositeRequest requests, IContext context)
        {
            CompositeResponse response = new CompositeResponse();

            foreach (Request request in requests.Requests)
                response.Responses.Add(request.RunMock());

            return response;
        }
    }
}
