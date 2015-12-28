using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Facturanet.Entities.Base
{
    public abstract class AccountTreeBase : Entity
    {
        public AccountTreeBase()
        {
            Active = true;
        }

        public virtual string Code { get; set; }
        public virtual bool Active { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual Guid? DeletedMark { get; set; }

        public virtual bool IsDeleted()
        {
            return DeletedMark.HasValue;
        }

        public virtual void MarkAsDelete()
        {
            DeletedMark = Id;
        }

        public override Validation.ValidationResult GetValidationResult(Validation.Level exceptionOverLevel)
        {
            var result = base.GetValidationResult(exceptionOverLevel);

            if (Code == null || Code == string.Empty)
                result.Add(exceptionOverLevel, "Code", Validation.Level.Error, "NULLEMPTY", "This field cant't be null or empty");
            if (Name == null || Name == string.Empty)
                result.Add(exceptionOverLevel, "Name", Validation.Level.Error, "NULLEMPTY", "This field cant't be null or empty");
            if (Description == null || Description == string.Empty)
                result.Add(exceptionOverLevel, "Description", Validation.Level.Error, "NULLEMPTY", "This field cant't be null or empty");
            
            return result;
        }
    }
}

namespace Facturanet.Entities
{
    public class AccountTree : Base.AccountTreeBase
    {
        public virtual Iesi.Collections.Generic.ISet<ContableAccount> Accounts { get; set; }
        
        #region Constructors

        public AccountTree()
        {
        }

        public AccountTree(Guid id)
            : this()
        {
            Id = id;
        }

        #endregion

        public virtual void AddAccount(ContableAccount account)
        {
            account.AccountTree = this;
            if (!Accounts.Contains(account))
                Accounts.Add(account);
        }

        public override Facturanet.Validation.ValidationResult GetValidationResult(Facturanet.Validation.Level exceptionOverLevel)
        {
            var result = base.GetValidationResult(exceptionOverLevel);

            foreach (ContableAccount account in Accounts)
                result.Add(exceptionOverLevel, "Accounts", account.Id, account.GetValidationResult(exceptionOverLevel));
                
            return result;
        }
    }
}
