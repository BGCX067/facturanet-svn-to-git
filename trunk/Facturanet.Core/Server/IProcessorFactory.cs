using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Facturanet.Server
{
    public interface IProcessorFactory
    {
        IProcessor CreateProcessor(Type requestType);
        void ForceInit();
    }
}
