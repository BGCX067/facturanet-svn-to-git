using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using Facturanet.Entities;
using System.Configuration;
using System.Reflection;

namespace Facturanet.Server
{
    public class FacturanetProcessorFactory : IProcessorFactory
    {
        private static readonly List<IProcessorFactory> ProcessorFactoryCollection;

#if DEBUG
        private static readonly IProcessorFactory ProcessorFactoryMock;
#endif

        public static readonly FacturanetProcessorFactory Instance;

        internal static Type[] GetKnownTypesOf(params Type[] types)
        {
            // aca se podría limitar lo tipos permitidos desde algún archivo de configuración
            // otra opción sería usar atributos en los tipos que se van a agregar aca

            List<Type> subclasses = new List<Type>();

            foreach (Type type in types)
            {
                Assembly assembly = type.Module.Assembly;

                if (type.IsInterface)
                {
                    foreach (Type testType in assembly.GetTypes())
                        if (!testType.IsAbstract && testType.GetInterfaces().Contains(type))
                            subclasses.Add(testType);
                }
                else
                {
                    foreach (Type testType in assembly.GetTypes())
                        if (testType.IsSubclassOf(type) && !testType.IsAbstract)
                            subclasses.Add(testType);
                }
            }
            return subclasses.ToArray();
        }


        static FacturanetProcessorFactory()
        {
            ProcessorFactoryCollection = new List<IProcessorFactory>();
            IProcessorFactory processorFactory;

            string cfgDriverAssembly = ConfigurationManager.AppSettings["ModuleAssembly"];
            string cfgDriverType = ConfigurationManager.AppSettings["ModuleType"];
            processorFactory = (IProcessorFactory)(Activator.CreateInstance(
                cfgDriverAssembly,
                cfgDriverType)).Unwrap();
            ProcessorFactoryCollection.Add(processorFactory);

            ////////////////////////////////////////////////////////////
            // TODO: habría que hacer que se cargue un array de factories
            ////////////////////////////////////////////////////////////
#if DEBUG
            string cfgDriverAssemblyMock = ConfigurationManager.AppSettings["ModuleAssemblyTest"];
            string cfgDriverTypeMock = ConfigurationManager.AppSettings["ModuleTypeTest"];
            ProcessorFactoryMock = (IProcessorFactory)(Activator.CreateInstance(
                cfgDriverAssemblyMock,
                cfgDriverTypeMock)).Unwrap();
#endif
            Instance = new FacturanetProcessorFactory();
        }

        public void ForceInit()
        {
            foreach (IProcessorFactory processorFactory in ProcessorFactoryCollection)
                processorFactory.ForceInit();
        }

        public IProcessor CreateProcessor(Type requestType)
        {
            IProcessor processor = null;
            foreach (IProcessorFactory factory in ProcessorFactoryCollection)
            {
                processor = factory.CreateProcessor(requestType);
                if (processor != null)
                    break;
            }
            return processor;
        }



#if DEBUG
        internal IProcessor CreateProcessorMock(Type requestType)
        {
            return ProcessorFactoryMock.CreateProcessor(requestType);
        }
#endif
    }
}
