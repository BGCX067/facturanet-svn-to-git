using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernate.Criterion;
using Facturanet.Entities;

namespace Facturanet.Server
{
    internal static class SelectorExtensions
    {
        /*
         * Mejoras:
         * Mandar directamente un ICriteria estría mal ya que el cliente dependería de nhibernate
         * tal vez habría que hacer una especie de jerarquia con sus con controladores (igual que 
         * los request. Entonces podría tener distintos selectores (todos genericos): por id, 
         * por consulta, por example, composite, etc. y si necesito algún caso especial no generico 
         * hacerlo que herede de alguno de los genéricos.
         * También hay que hacer algo para devolver un conjunto de resultados cuando es múltiple.
         * */

        public static EntityType GetEntity<EntityType>(this Selector<EntityType> selector, PersistenceContext context)
            where EntityType : Entities.Base.Entity, new()
        {
            if (selector.Multiple)
                throw new Exception("El selector especificado es múltiple por lo tanto debuelve un arreglo sde entidades");
            else
            {
                EntityType entity = null;

                if (selector.Example == null && selector.Id > 0)
                {
                    entity = context.Session.Load<EntityType>(selector.Id);
                }
                else if (selector.Example != null && selector.Id <= 0)
                {
                    ICriteria criteria = context.Session.CreateCriteria(typeof(EntityType));
                    criteria.Add(
                        Example.Create(selector.Example)    
                        .ExcludeZeroes()    //exclude null or zero valued properties
                        .IgnoreCase()       //perform case insensitive string comparisons
                        .EnableLike()       //use like for string comparisons
                    );
                    entity = criteria.UniqueResult<EntityType>();
                }
                else
                    throw new Exception("El criterio no es válido.");

                return entity;
            }
        }
    }
}
