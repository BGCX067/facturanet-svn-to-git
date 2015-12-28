using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Facturanet.Server;

namespace Facturanet.Entities.Base
{
    [DataContract]
    [KnownType("GetKnownTypes")]
    public abstract class Entity : Validation.IValidable
    {
        [DataMember]
        public virtual Guid Id { get; protected set; }

        [DataMember]
        public virtual int Version { get; set; }

        static private Type[] knownTypesCache = null;
        static Type[] GetKnownTypes()
        {
            if (knownTypesCache == null)
                knownTypesCache = FacturanetProcessorFactory.GetKnownTypesOf(typeof(Entity));
            return knownTypesCache;
        }

        /// <summary>
        /// Constructor para nuevos objetos
        /// </summary>
        public Entity()
        {
            Id = Util.IdentifierHelper.GenerateComb();
        }

        #region Implement IValidable
        public virtual Validation.ValidationResult GetValidationResult(Validation.Level exceptionOverLevel)
        {
            var result = Validation.ValidationResult.Create(this);
            if (this.Id == null)
                result.Add(exceptionOverLevel, "Id", Validation.Level.Error, "IDNULL", "Id can't be null");
            return result;
        }
        #endregion

        #region Override object methods

        public override bool Equals(object obj)
        {
            //conviene que haga esto???
            if (this == obj)
                return true;

            if (obj == null || !(obj is Entity))
                return false;

            Entity other = (Entity)obj;
            if (Id == null)
                return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            if (Id != null)
                return Id.GetHashCode();
            else
                return base.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format(
                "{0}#{1}",
                GetType().Name,
                Id);
        }

        #endregion
    }
}
