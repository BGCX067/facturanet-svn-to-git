using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using Facturanet.Business;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Facturanet.Entities;

namespace Facturanet.Business
{
    internal class UpdateCompleteAccountTreeProcessor : PersistenceEmptyResponseProcessor<UpdateCompleteAccountTreeRequest>
    {
        protected override void RunInContextEmptyResponse(UpdateCompleteAccountTreeRequest request, PersistenceContext context)
        {
            foreach (Guid id in request.DeletedTreesIds)
            {
                AccountTree entity = context.Session.Load<AccountTree>(id);
                entity.MarkAsDelete();
            }

            context.Session.Flush(); //por los uniques

            foreach (UI.AccountTreeListItem ui in request.UpdatedTrees)
            {
                AccountTree entity = context.Session.Load<AccountTree>(ui.Id);
                ui.CopyTo(entity);
            }

            context.Session.Flush(); //por los uniques

            foreach (UI.AccountTreeListItem ui in request.CreatedTrees)
            {
                AccountTree entity = new AccountTree(ui.Id);
                ui.CopyTo(entity);
                context.Session.Save(entity);
            }

            foreach (UI.ContableAccount ui in request.UpdatedAccounts)
            {
                ContableAccount entity = context.Session.Load<ContableAccount>(ui.Id);
                ui.CopyTo(entity); //las modificaciones sin cambio de padres
                entity.AccountTree = context.Session.Load<AccountTree>(ui.AccountTreeId);
            }

            foreach (UI.ContableAccount ui in request.CreatedAccounts)
            {
                ContableAccount entity = new ContableAccount(ui.Id);
                ui.CopyTo(entity);
                entity.AccountTree = context.Session.Load<AccountTree>(ui.AccountTreeId);
                context.Session.Save(entity); //los grabo sin padre
            }

            //para cada una de las modificadas o creadas les pongo el padre
            foreach (UI.ContableAccount ui in request.UpdatedAccounts.Union(request.CreatedAccounts))
            {
                ContableAccount entity = context.Session.Load<ContableAccount>(ui.Id);
                if (ui.ParentAccountId.HasValue)
                    entity.ParentAccount = context.Session.Load<ContableAccount>(ui.ParentAccountId.Value);
                else
                    entity.ParentAccount = null;
            }
        }
    }
}
