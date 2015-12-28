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
    internal class UpdateAccountTreeListProcessor : PersistenceEmptyResponseProcessor<UpdateAccountTreeListRequest>
    {
        //TODO: Elimianar esta Accion
        protected override void RunInContextEmptyResponse(UpdateAccountTreeListRequest request, PersistenceContext context)
        {
            foreach (Guid id in request.DeletedIds)
            {
                AccountTree entity = context.Session.Load<AccountTree>(id);
                entity.MarkAsDelete();
            }

            context.Session.Flush();

            //Modifico los elementos modificados
            foreach (UI.AccountTreeListItem ui in request.UpdatedItems)
            {
                AccountTree entity = context.Session.Load<AccountTree>(ui.Id);
                /*
                if (entity.Version != ui.Version)
                    throw new StaleObjectStateException("AccountTree", ui.Id);
                */

                ui.CopyTo(entity);
                /*-*
                entity.Active = ui.Active;
                entity.Code = ui.Code;
                entity.Description = ui.Description;
                entity.Name = ui.Name;
                */
            }

            context.Session.Flush();

            //Creo los nuevos elementos
            foreach (UI.AccountTreeListItem ui in request.CreatedItems)
            {
                AccountTree entity = new AccountTree(ui.Id);
                ui.CopyTo(entity);
                context.Session.Save(entity);
                /*-*
                AccountTree entity = new AccountTree()
                {
                    Active = ui.Active,
                    Code = ui.Code,
                    Description = ui.Description,
                    Name = ui.Name
                };
                context.Session.Save(entity, ui.Id);
                */
            }
        }
    }
}
