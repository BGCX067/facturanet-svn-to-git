using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facturanet.Business;
using Facturanet.UI;
using Facturanet.Validation;
using Facturanet.WinformsClient.Util;

namespace Facturanet.WinformsClient.Forms
{
    public partial class AccountTreesABM : Form
    {
        private FacturanetBindingList<AccountTreeListItem> list;
        
        public AccountTreesABM()
        {
            InitializeComponent();
            RefreshList();
        }

        /// <summary>
        /// Refreshes the list.
        /// </summary>
        private void RefreshList()
        {
            var request = new ListAccountTreesRequest();
            var response = request.Run();
            list = new FacturanetBindingList<AccountTreeListItem>(response.Items);
            listBindingSource.DataSource = list;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var request = new Business.UpdateAccountTreeListRequest(
                list.GetInsertedItems(),
                list.GetUpdatedItems(),
                list.GetDeletedItems());

            if (request.IsValid())
            {
                request.Run();
                RefreshList();
            }
            else
            {
                Validation.ValidationResultBase results = request.GetValidationResult();

                if (results.Level == Validation.Level.Empty)
                    Console.WriteLine("Sin errores");
                else
                    Console.WriteLine("Máximo error: {0}", results.Level);

                Console.WriteLine("Cantidad de propiedades con errores: {0}", results.Length);

                MessageBox.Show(results.GetResultText());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var tree = listBindingSource.GetCurrent<AccountTreeListItem>();

            if (tree == null)
                MessageBox.Show("You have to select an item to edit");
            else if (tree.IsNew())
                MessageBox.Show("The item is new, you have to save changes to edit");
            else
            {
                var f = new Forms.AccountTreeEdition(tree.Id);
                f.Show();
            }
        }
    }
}
