using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;


namespace Facturanet.Server
{
    internal class TestProcessorFactory : IProcessorFactory
    {
        public IProcessor CreateProcessor(Type tipoSolicitud)
        {
            IProcessor procesador;

            if (tipoSolicitud == typeof(Server.CompositeRequest))
                procesador = new Server.CompositeProcessor();
            else if (tipoSolicitud == typeof(Business.ListProductsRequest))
                procesador = new Business.GetProductsProcessor();
            else if (tipoSolicitud == typeof(Infrastructure.SystemInfoRequest))
                procesador = new Infrastructure.SystemInfoProcessor();
            else procesador = null;

            return procesador;
        }

        public void ForceInit()
        {
            Console.WriteLine("ForzarInicializacion del Factory Mock");
        }
    }
}
