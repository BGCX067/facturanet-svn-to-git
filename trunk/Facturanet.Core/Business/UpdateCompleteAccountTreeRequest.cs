using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facturanet.Server;
using System.Runtime.Serialization;

namespace Facturanet.Business
{

    /// <summary>
    /// This request allow to update AccountTree header data and add, remove, edit and reorder their ContableAccounts
    /// </summary>
    [DataContract]
    public class UpdateCompleteAccountTreeRequest : BaseRequest<EmptyResponse>
    {
        [DataMember]
        public Guid[] DeletedTreesIds { get; set; }

        [DataMember]
        public UI.AccountTreeListItem[] UpdatedTrees { get; set; }

        [DataMember]
        public UI.AccountTreeListItem[] CreatedTrees { get; set; }

        [DataMember]
        public UI.ContableAccount[] UpdatedAccounts { get; set; }

        [DataMember]
        public UI.ContableAccount[] CreatedAccounts { get; set; }

        public UpdateCompleteAccountTreeRequest()
        {
            DeletedTreesIds = new Guid[0];
            UpdatedTrees = new UI.AccountTreeListItem[0];
            CreatedTrees = new UI.AccountTreeListItem[0];
            UpdatedAccounts = new UI.ContableAccount[0];
            CreatedAccounts = new UI.ContableAccount[0];
        }

        public override Facturanet.Validation.ValidationResult GetValidationResult(Facturanet.Validation.Level exceptionOverLevel)
        {
            var result = base.GetValidationResult(exceptionOverLevel);

            if (
                UpdatedTrees.Length == 0
                && CreatedTrees.Length == 0
                && UpdatedAccounts.Length == 0
                && CreatedAccounts.Length == 0)
            {
                result.Add(exceptionOverLevel, "{GENERAL}", Validation.Level.Info, "NOACTION", "This request will not do any action");
            }
            else
            {
                for (int i = 0; i < UpdatedTrees.Length; i++)
                    result.Add(exceptionOverLevel, "UpdatedTrees", i, UpdatedTrees[i].GetValidationResult(exceptionOverLevel));

                for (int i = 0; i < UpdatedTrees.Length; i++)
                    result.Add(exceptionOverLevel, "CreatedTrees", i, CreatedTrees[i].GetValidationResult(exceptionOverLevel));

                for (int i = 0; i < UpdatedAccounts.Length; i++)
                    result.Add(exceptionOverLevel, "UpdatedAccounts", i, UpdatedAccounts[i].GetValidationResult(exceptionOverLevel));

                for (int i = 0; i < CreatedAccounts.Length; i++)
                    result.Add(exceptionOverLevel, "CreatedAccounts", i, CreatedAccounts[i].GetValidationResult(exceptionOverLevel));
            }
            return result;
        }
    }
}
