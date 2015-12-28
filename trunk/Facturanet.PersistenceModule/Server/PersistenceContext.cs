using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Facturanet.Server
{
    public class PersistenceContext : IContext
    {
        public ISession Session { get; private set; }
        public ITransaction Transaction { get; private set; }

        public PersistenceContext(ISession session, ITransaction transaction)
        {
            Session = session;
            Transaction = transaction;
        }
    }
}
