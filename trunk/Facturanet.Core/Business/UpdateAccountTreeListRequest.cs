using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using System.Runtime.Serialization;

namespace Facturanet.Business
{

    /// <summary>
    /// This request allow to delete AccountTrees, Insert new empties AccountTrees and update base data of AccountTrees
    /// </summary>
    [DataContract]
    public class UpdateAccountTreeListRequest : BaseRequest<EmptyResponse>
    {
        //TODO: eliminar esta accion
        [DataMember]
        public Guid[] DeletedIds { get; set; }

        [DataMember]
        public UI.AccountTreeListItem[] UpdatedItems { get; set; }

        [DataMember]
        public UI.AccountTreeListItem[] CreatedItems { get; set; }

        public UpdateAccountTreeListRequest(UI.AccountTreeListItem[] createdItems, UI.AccountTreeListItem[] updatedItems, Guid[] deletedIds)
        {
            CreatedItems = createdItems;
            UpdatedItems = updatedItems;
            DeletedIds = deletedIds;
        }

        public UpdateAccountTreeListRequest(
            IEnumerable<UI.AccountTreeListItem> createdItems, 
            IEnumerable<UI.AccountTreeListItem> updatedItems, 
            IEnumerable<UI.AccountTreeListItem> deletedItems)
            : this(
                createdItems.ToArray(),
                updatedItems.ToArray(),
                (from item in deletedItems 
                 select item.Id).ToArray())
        {

        }
        
        public override Facturanet.Validation.ValidationResult GetValidationResult(Facturanet.Validation.Level exceptionOverLevel)
        {
            var result = base.GetValidationResult(exceptionOverLevel);

            if (CreatedItems.Length == 0
                && UpdatedItems.Length == 0
                && DeletedIds.Length == 0)
            {
                result.Add(exceptionOverLevel, "{GENERAL}", Validation.Level.Info, "NOACTION", "This request will not do any action");
            }
            else
            {
               for (int i = 0; i < CreatedItems.Length; i++)
                   result.Add(exceptionOverLevel, "CreatedItems", i, CreatedItems[i].GetValidationResult(exceptionOverLevel));
                for (int i = 0; i < UpdatedItems.Length; i++)
                    result.Add(exceptionOverLevel, "UpdatedItems", i, UpdatedItems[i].GetValidationResult(exceptionOverLevel));
            }
            return result;
        }
        
    }
}
