using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using System.Runtime.Serialization;

namespace Facturanet.Infrastructure
{
    [DataContract]
    public class SystemInfoResponse : Response
    {
        [DataMember]
        public string ServerVersion { get; set; } 

        [DataMember]
        public string DriverVersion { get; set; }

        [DataMember]
        public string DriverName { get; set; }

        public override string ToString()
        {
            return string.Format(
@"ServerVersion {0} 
DriverName {1}
DriverVersion {2}
", ServerVersion, DriverName, DriverVersion); 
        }
    }
}
