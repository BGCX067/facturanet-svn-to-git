using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facturanet;
using Facturanet.Entities;
using Facturanet.Server;
using Facturanet.Business;
using Facturanet.Infrastructure;
using Facturanet.Test;

namespace Facturanet.WinformsClient
{
    public partial class Form1 : Form
    {
        //private Customer selectedCustomer = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var solicitudes = new CompositeRequest()
            {
                Requests = 
                {
                    new SystemInfoRequest(),
                    new ListProductsRequest(),
                    new ListCustomersRequest(),
                    new ListInvoicesRequest()
                }
            };

            /*
            var solicitudes = new CompositeRequest();

            var solicitud0 = new SystemInfoRequest();
            var solicitud1 = new ListProductsRequest();
            var solicitud2 = new ListCustomersRequest();

            solicitudes.Requests.Add(solicitud0);
            solicitudes.Requests.Add(solicitud1);
            solicitudes.Requests.Add(solicitud2);
            */

            var respuesta = this.checkBox1.Checked
                ? solicitudes.RunMock()
                : solicitudes.Run();


            var systemInfoResponse = respuesta.Responses[0] as SystemInfoResponse;
            Console.WriteLine("*systemInfoResponse*");
            Console.WriteLine(systemInfoResponse.ToString());


            var listProductsResponse = respuesta.Responses[1] as ListProductsResponse;
            Console.WriteLine("*listProductsResponse*");
            Console.WriteLine(listProductsResponse.ToString());


            var listCustomersResponse = respuesta.Responses[2] as ListCustomersResponse;
            Console.WriteLine("*listCustomersResponse*");
            Console.WriteLine(listCustomersResponse.ToString());

            var listInvoicesResponse = respuesta.Responses[3] as ListInvoicesResponse;
            Console.WriteLine("*ListInvoicesResponse*");
            Console.WriteLine(listInvoicesResponse.ToString());

            this.articuloBindingSource.DataSource = listProductsResponse.Items;
            this.clienteBindingSource.DataSource = listCustomersResponse.Items;
            this.invoicesListItemBindingSource.DataSource = listInvoicesResponse.Items;
            
            ActualizarItems();
        }

        private void facturaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ActualizarItems();
        }

        private void ActualizarItems()
        {
            //this.itemFacturaBindingSource.DataSource = facturaBindingSource.Current;
            //this.itemFacturaBindingSource.DataMember = "Items";
            /*
            Factura f = facturaBindingSource.Current as Factura;
            if (f == null || f.Id == 0)
            {
                this.itemFacturaBindingSource.DataSource = null;
            }
            else
            {
                Factura f2 = Servicios.BusinessServices.RecuperarFactura(f.Id);
                this.itemFacturaBindingSource.DataSource = f2.Items;
            }
            */
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UI.AccountTreeListItem a = new Facturanet.UI.AccountTreeListItem();
            /*
            GenerateTestDataRequest r = new GenerateTestDataRequest();
            try
            {
                r.Run();
                MessageBox.Show("GenerateTestData OK");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
             * */
            /*
            CompositeRequest requests = new CompositeRequest();
            requests.Requests.Add(
                new SystemInfoRequest()
            );
            requests.Requests.Add(
                new RemoveProductRequest()
                {
                    ProductIdentificator = new Selector<Product>() { Id = 2 }
                });
            requests.Requests.Add(
                new RemoveProductRequest()
                {
                    ProductIdentificator = new Selector<Product>()
                    {
                        Example = new Product() { Name = "Arr%" }
                    }
                });
            requests.Requests.Add(
                new RemoveProductRequest()
                {
                    ProductIdentificator = new Selector<Product>()
                    {
                        Example = new Product() { Name = "POLLO" }
                    }
                });
             */
            /*
            requests.Requests.Add(
                new RemoveProductRequest()
                {
                    ProductIdentificator = new Selector<Product>()
                    {
                        Example = new Product() { Name = "%" } //devuelve varios
                    }
                });
            */
            /*
            try
            {
                CompositeResponse responses = requests.Run();
                foreach (Response r in responses.Responses)
                {
                    SystemInfoResponse sir = r as SystemInfoResponse;
                    RemoveProductResponse rpr = r as RemoveProductResponse;
                    if (rpr != null)
                        Console.WriteLine(rpr.RespuestaPrueba);
                    else if (sir != null)
                        Console.WriteLine(sir);
                    else
                        Console.WriteLine("Respuesta no esperada");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
             * */
        }

        private void clienteBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ActualizarFacturas(clienteBindingSource.Current as Customer);
        }

        private void ActualizarFacturas(Customer customer)
        {
            /*
            if (customer != selectedCustomer)
            {
                selectedCustomer = customer;

                if (customer == null)
                {
                    facturaBindingSource.DataSource = typeof(Invoice);
                }
                else
                {
                    var solicitud = new ListInvoicesRequest();

                    var respuesta = this.checkBox1.Checked
                        ? solicitud.RunMock()
                        : solicitud.Run();

                    facturaBindingSource.DataSource = respuesta.Items;
                }
            }
            */
        }

        private void btnEditAccountTrees_Click(object sender, EventArgs e)
        {
            var f = new Forms.AccountTreesABM();
            f.Show();
        }
    }
}
