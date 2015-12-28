using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.WebserviceModule.FacturanetServiceReference;

namespace Facturanet.Server
{
    internal class WebserviceProcessorFactory : IProcessorFactory
    {
        static readonly private VirtualProcessor ProcesadorVirtual;
        static readonly public ServiceClient ServiceClient;

        static WebserviceProcessorFactory()
        {
            ServiceClient = new ServiceClient();
            ProcesadorVirtual = new VirtualProcessor();
        }

        public IProcessor CreateProcessor(Type requestType)
        {
            return ProcesadorVirtual;
        }

        public void ForceInit()
        {
            ServiceClient.ForceInit();
        }

    }
}
