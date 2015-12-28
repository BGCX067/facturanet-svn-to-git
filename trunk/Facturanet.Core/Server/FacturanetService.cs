using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Server
{
    public class FacturanetService : IService
    {
        public Response Run(Request request)
        {
            return request.Run();
        }

#if DEBUG
        public Response RunMock(Request request)
        {
            return request.RunMock();
        }
#endif

        public void ForceInit()
        {
            FacturanetProcessorFactory.Instance.ForceInit();
        }
    }
}
