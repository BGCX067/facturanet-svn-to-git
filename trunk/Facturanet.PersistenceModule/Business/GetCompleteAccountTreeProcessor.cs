using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using Facturanet.Business;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using Facturanet.NHUtil;
using NHibernate.Criterion;


namespace Facturanet.Business
{
    internal class GetCompleteAccountTreeProcessor : PersistenceProcessor<GetCompleteAccountTreeRequest, GetCompleteAccountTreeResponse>
    {

        protected override GetCompleteAccountTreeResponse RunInContext(GetCompleteAccountTreeRequest request, PersistenceContext context)
        {
            
            var response = new GetCompleteAccountTreeResponse();
            
            Entities.AccountTree tree = context.Session
                .CreateCriteria(typeof(Entities.AccountTree), "tree")
                .Add(Expression.IdEq(request.AccountTreeId))
                .SetFetchMode("Accounts", FetchMode.Eager)
                .UniqueResult<Entities.AccountTree>();

            response.AccountTreeHeader =
                new UI.AccountTreeListItem(tree);
                /*-*
                new UI.AccountTreeListItem(tree.Id)
                {
                    Active = tree.Active,
                    Code = tree.Code,
                    Description = tree.Description,
                    Name = tree.Name,
                    Version = tree.Version
                };
                */
            response.Items = new List<Facturanet.UI.ContableAccount>();

            foreach (var entity in tree.Accounts)
            {
                response.Items.Add(new UI.ContableAccount(entity)
                    /*-*
                    new UI.ContableAccount(entity.Id)
                    {
                        Active = entity.Active,
                        Code = entity.Code,
                        Description = entity.Description,
                        Imputable = entity.Imputable,
                        Name = entity.Name,
                        ParentAccountId = entity.ParentAccount == null 
                            ? null
                            : (Guid?)entity.ParentAccount.Id,
                        Version = entity.Version
                    }*/
                       );
            }

            return response;
        }
        
    }
}
