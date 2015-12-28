using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Facturanet.Entities;
using Facturanet.Infrastructure;
using Facturanet.Server;

namespace Facturanet.Infrastructure
{
    internal class SystemInfoProcessor : Processor<SystemInfoRequest, SystemInfoResponse>
    {
        public override SystemInfoResponse Run(SystemInfoRequest request, IContext context)
        {
            Assembly assembly = this.GetType().Assembly;
            return new SystemInfoResponse()
            {
                DriverName = assembly.FullName + " * " + assembly.CodeBase + " * " + assembly.EntryPoint,
                DriverVersion = "PENDIENTE",
                ServerVersion = "PENDIENTE"
            };
        }
    }
}
