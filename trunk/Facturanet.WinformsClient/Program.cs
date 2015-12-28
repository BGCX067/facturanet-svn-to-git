using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Facturanet.Server;
using Facturanet.Infrastructure;


namespace Facturanet.WinformsClient
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FacturanetProcessorFactory.Instance.ForceInit();
            //FacturanetProcessorFactory servidor = new FacturanetProcessorFactory();
            //Console.WriteLine(new SystemInfoRequest().Run().ToString());
            
            Application.Run(new Form1());
        }
    }
}
