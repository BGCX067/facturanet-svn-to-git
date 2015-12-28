using System;

namespace Facturanet.Server
{
    public interface IProcessor
    {
        Response Run(Request request, IContext context);
    }
}
