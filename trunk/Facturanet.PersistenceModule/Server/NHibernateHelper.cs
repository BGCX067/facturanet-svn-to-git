using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet;
using Facturanet.Entities;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Facturanet.Server
{
    internal static class NHibernateHelper
    {
        public static readonly ISessionFactory SessionFactory;
        
        internal static readonly System.Reflection.Assembly Assembly = typeof(NHibernateHelper).Assembly;
        internal static readonly string ConfigNH = Assembly.CodeBase + ".xml"; 

        static NHibernateHelper()
        {
            Console.WriteLine("CREANDO FACTORY");
            Configuration cfg = new Configuration();
            cfg.Configure(ConfigNH);
            cfg.AddAssembly(Assembly);
            //CrearEstructuraDB(cfg);
            SessionFactory = cfg.BuildSessionFactory();
            //CrearDatosDB();
        }

        public static void ForceInit()
        {
            Console.WriteLine(SessionFactory);
        }

        
        private static void CrearEstructuraDB(Configuration config)
        {
            SchemaExport exporter = new SchemaExport(config);
            exporter.Create(true, true); //borra y crea nuevamente las tablas en la base.
        }
/*        
        private static void CrearDatosDB()
        {
            //ISession session = SessionFactory.OpenSession();
            using (var session = NHibernateHelper.SessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {



                transaction.Commit();
            }
            Console.WriteLine("SE SUPONE QUE SE GRABÓ");
        }
 */
    }
}
