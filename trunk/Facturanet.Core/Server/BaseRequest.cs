using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Facturanet.Server
{
    [DataContract]
    public abstract class BaseRequest<ResponseType> : Request
        where ResponseType : Response
    {
        private static ResponseType CastResponse(Response response)
        {
            if (response == null)
                return null;
            else
            {
                ResponseType typedResponse = response as ResponseType;
                if (typedResponse != null)
                    return typedResponse;
                else
                    throw new Exception(string.Format(
                        "El tipo de la respuesta ({0}) no corresponde con el esperado ({1})",
                        response.GetType(),
                        typeof(ResponseType)));
                /*
                 * else
                 * {
                 *    ExceptionResponse exceptionResponse = response as ExceptionResponse;
                 *    if (exceptionResponse != null)
                 *        throw exceptionResponse.Exception;
                 *    else
                 *        throw new Exception(string.Format(
                 *            "El tipo de la respuesta ({0}) no corresponde con el esperado ({1})",
                 *            response.GetType(),
                 *            typeof(ResponseType)));
                 * }
                 * ********************************************************
                 * namespace Facturanet.Server
                 * {
                 *   [DataContract]
                 *   public class ExceptionResponse : Response
                 *   {
                 *       [DataMember]
                 *       public Exception Exception { get; set; }
                 *       public ExceptionResponse()
                 *       {
                 *           Exception = new Exception();
                 *       }
                 *       public ExceptionResponse(Exception exception)
                 *       {
                 *           Exception = exception;
                 *       }
                 *   }
                 * }
                */
            }
        }

        public new ResponseType Run()
        {
            return CastResponse(base.Run(null));
        }

#if DEBUG
        public new ResponseType RunMock()
        {
            return CastResponse(base.RunMock(null));
        }
#endif
    }
}
