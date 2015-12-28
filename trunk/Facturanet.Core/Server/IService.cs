using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using System.ServiceModel;
using Facturanet.Entities;

namespace Facturanet.Server
{
    [ServiceContract]
    public interface IService 
    {
        [OperationContract]
        Response Run(Request request);
        
#if DEBUG
        [OperationContract]
        Response RunMock(Request request);
#endif

        [OperationContract]
        void ForceInit();
    }
}
