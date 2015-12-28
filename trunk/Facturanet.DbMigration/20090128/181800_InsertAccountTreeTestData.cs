using System;
using Migrator.Framework;
using System.Data;
using Facturanet.Util;

namespace Facturanet.DbMigration.Migrations
{
    [Migration(20090128181800)]
    public class InsertAccountTreeTestData : Migration
    {
        public override void  Up()
        {
            string IdContableConfigurationSample = IdentifierHelper.GenerateComb().ToString();
            string IdAccountTreeSample = IdentifierHelper.GenerateComb().ToString();
            string IdDefaultAccountSample = IdentifierHelper.GenerateComb().ToString();
            string IdParentAccountSample = IdentifierHelper.GenerateComb().ToString();

            Database.Insert(
                "AccountTree",
                new string[] 
                { 
                    "Id", 
                    "Code", 
                    "Name", 
                    "Description"
                },
                new string[] 
                { 
                    IdAccountTreeSample, 
                    "CODIGOTREE",
                    "PruebaTree", 
                    "Arbol de cuentas de prueba"
                }
            );


            Database.Insert(
                "ContableAccount",
                new string[] 
                { 
                    "Id", 
                    "Code", 
                    "Name", 
                    "Description",
                    "Imputable",
                    "IdAccountTree"
                },
                new string[] 
                { 
                    IdDefaultAccountSample, 
                    "CODIGODEFAULT",
                    "PruebaDefault", 
                    "Cuenta por defecto",
                    "True",
                    IdAccountTreeSample
                }
            );

            Database.Insert(
                "ContableAccount",
                new string[] 
                { 
                    "Id", 
                    "Code", 
                    "Name", 
                    "Description",
                    "Imputable",
                    "IdAccountTree"
                },
                new string[] 
                { 
                    IdentifierHelper.GenerateComb().ToString(), 
                    "CODIGO1",
                    "Prueba1", 
                    "Cuenta1",
                    "True",
                    IdAccountTreeSample
                }
            );

            Database.Insert(
                "ContableAccount",
                new string[] 
                { 
                    "Id", 
                    "Code", 
                    "Name", 
                    "Description",
                    "Imputable",
                    "IdAccountTree"
                },
                new string[] 
                { 
                    IdParentAccountSample, 
                    "CODIGOPADRE",
                    "PruebaPadre", 
                    "CuentaPadre",
                    "False",
                    IdAccountTreeSample
                }
            );

            Database.Insert(
                "ContableAccount",
                new string[] 
                { 
                    "Id", 
                    "Code", 
                    "Name", 
                    "Description",
                    "Imputable",
                    "IdAccountTree",
                    "IdParentAccount"
                },
                new string[] 
                { 
                    IdentifierHelper.GenerateComb().ToString(), 
                    "CODIGOHIJO1",
                    "PruebaHijo1", 
                    "CuentaHijo1",
                    "False",
                    IdAccountTreeSample,
                    IdParentAccountSample
                }
            );

            Database.Insert(
                "ContableAccount",
                new string[] 
                { 
                    "Id", 
                    "Code", 
                    "Name", 
                    "Description",
                    "Imputable",
                    "IdAccountTree",
                    "IdParentAccount"
                },
                new string[] 
                { 
                    IdentifierHelper.GenerateComb().ToString(), 
                    "CODIGOHIJO2",
                    "PruebaHijo2", 
                    "CuentaHijo2",
                    "False",
                    IdAccountTreeSample,
                    IdParentAccountSample
                }
            );


            Database.Insert(
                "ContableConfiguration",
                new string[] 
                { 
                    "Id", 
                    "Code", 
                    "Name", 
                    "Description",
                    "IdAccountTree",
                    "IdDefaultAccount",
                        
                },
                new string[] 
                { 
                    IdContableConfigurationSample, 
                    "CODIGOCONFIGURACION",
                    "PruebaConfiguracion", 
                    "Configuración contable de prueba",
                    IdAccountTreeSample,
                    IdDefaultAccountSample
                }
            );

        }

        public override void Down()
        {
        }
    }
}
