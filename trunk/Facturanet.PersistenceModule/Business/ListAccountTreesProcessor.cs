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


namespace Facturanet.Business
{
    internal class ListAccountTreesProcessor : PersistenceProcessor<ListAccountTreesRequest, ListAccountTreesResponse>
    {
        protected override ListAccountTreesResponse RunInContext(ListAccountTreesRequest request, PersistenceContext context)
        {
            var response = new ListAccountTreesResponse();

            response.Items = context.Session
                .CreateQuery(@"
select 
    accountTree
from 
    AccountTree accountTree")
                .ToDTOEnumerable<UI.AccountTreeListItem>(tuple =>
                    new UI.AccountTreeListItem((Entities.AccountTree)tuple[0]))
                .ToList();

            /*-*
            response.Items = context.Session
                .CreateQuery(@"
select 
    accountTree.Id, 
    accountTree.Version, 
    accountTree.Active, 
    accountTree.Code, 
    accountTree.Name,
    accountTree.Description
from 
    AccountTree accountTree")
                //.ToDTOEnumerable<UI.AccountTreesListItem>("Active, Code, Description, Id, Name")
                .ToDTOEnumerable<UI.AccountTreeListItem>(tuple =>
                    new UI.AccountTreeListItem((Guid)tuple[0]) 
                    {
                        Version = (int)tuple[1],
                        Active = (bool)tuple[2],
                        Code = (string)tuple[3],
                        Name = (string)tuple[4],
                        Description = (string)tuple[5]
                    })
                .ToList();
             */
            return response;
        }
    }
}
