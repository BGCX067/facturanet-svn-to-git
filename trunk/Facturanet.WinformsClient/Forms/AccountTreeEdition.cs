using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facturanet.UI;
using Facturanet.Validation;
using Facturanet.WinformsClient.Controls;
using Facturanet.Util;
using Facturanet.WinformsClient.Util;

namespace Facturanet.WinformsClient.Forms
{
    public partial class AccountTreeEdition : Form
    {
        public Guid? AccountTreeId { get; private set; }
        /*
        AccountTreeListItem accountTreeHeader = null;
        AccountTreeListItemTreeNode rootNode = null;
        */
        public AccountTreeEdition()
        {
            InitializeComponent();
        }

        public AccountTreeEdition(Guid accountTreeId)
            : this()
        {
            AccountTreeId = accountTreeId;
            RefreshTree();
        }

        private Util.FacturanetEditorControl GetNodeEditor(object data)
        {
            if (data == null)
                return null;
            if (data is AccountTreeListItem)
                return accountTreeListItemEditor1;
            else if (data is ContableAccount)
                return contableAccountEditor1;
            else
                return null;
        }

        private enum Mode
        {
            Browsing,
            Editing,
            Creating
        }

        private Mode mode;
        private void SetMode(Mode newMode)
        {
            if (newMode != mode)
            {
                switch (newMode)
                {
                    case Mode.Browsing :
                        accountTreesTreeView1.ReadOnly = false;
                        btnNewChild.Enabled = true;
                        btnNewBrother.Enabled = true;
                        btnBeginEdit.Enabled = true;
                        btnEndEdit.Enabled = false;
                        btnCancelEdit.Enabled = false;
                        break;
                    case Mode.Editing :
                    case Mode.Creating :
                        accountTreesTreeView1.ReadOnly = true;
                        btnNewChild.Enabled = false;
                        btnNewBrother.Enabled = false;
                        btnBeginEdit.Enabled = false;
                        btnEndEdit.Enabled = true;
                        btnCancelEdit.Enabled = true;
                        break;
                }
                mode = newMode;
            }
        }


        private void BeginEdit()
        {
            var editor = GetNodeEditor(accountTreesTreeView1.Current);
            if (editor != null)
            {
                SetMode(Mode.Editing);
                editor.BeginEdit();
            }
        }

        private void BeginCreate()
        {
            var editor = GetNodeEditor(accountTreesTreeView1.Current);
            if (editor != null)
            {
                SetMode(Mode.Creating);
                editor.BeginEdit();
            }
        }

        private void EndEdit()
        {
            var editor = GetNodeEditor(accountTreesTreeView1.Current);
            if (editor != null)
            {
                editor.EndEdit();
                SetMode(Mode.Browsing);
            }
        }

        private void CancelEdit()
        {
            var editor = GetNodeEditor(accountTreesTreeView1.Current);
            if (editor != null)
            {
                editor.CancelEdit();
                if (mode == Mode.Creating)
                    accountTreesTreeView1.RemoveCurrent();
                SetMode(Mode.Browsing);
            }
        }
        /*
        private void BeginNewAccount(bool child)
        {
            


            if (treeView1.SelectedNode != null)
            {
                var parentNode = child
                    ? (FacturanetTreeNode)treeView1.SelectedNode
                    : (FacturanetTreeNode)treeView1.SelectedNode.Parent;

                if (parentNode != null)
                {
                    var account = new ContableAccount();
                    var node = new ContableAccountTreeNode(account);

                    //¿No puedo hacer que el nodo se entere de que le cambió el padre?
                    var parent = parentNode.Data as ContableAccount;
                    account.ParentAccountId = parent == null
                        ? null
                        : (Guid?)parent.Id;

                    parentNode.Nodes.Add(node);
                    treeView1.SelectedNode = node;
                    var editor = GetNodeEditor(treeView1.SelectedNode);
                    SetMode(Mode.Creating);
                    editor.BeginEdit();
                }
            }
        }
        
        private AccountTreeListItemTreeNode GenerateTree(AccountTreeListItem accountTreeHeader, IEnumerable<ContableAccount> accounts)
        {
            AccountTreeListItemTreeNode rootNode = new AccountTreeListItemTreeNode(accountTreeHeader);

            Dictionary<Guid, ContableAccountTreeNode> aux = new Dictionary<Guid, ContableAccountTreeNode>();

            foreach (ContableAccount account in accounts)
                aux.Add(
                    account.Id,
                    new ContableAccountTreeNode(account));

            foreach (var auxItem in aux)
            {
                var accountNode = auxItem.Value;
                Guid? parentId = accountNode.ContableAccount.ParentAccountId;
                if (parentId.HasValue)
                {
                    var parentNode = aux[parentId.Value];
                    parentNode.Nodes.Add(accountNode);
                }
                else
                    rootNode.Nodes.Add(auxItem.Value);
            }

            return rootNode;
        }
        */
        private void RefreshTree()
        {
            accountTreesTreeView1.Clear();

            if (AccountTreeId.HasValue)
            {
                var request = new Business.GetCompleteAccountTreeRequest();
                request.AccountTreeId = AccountTreeId.Value;
                var response = request.Run();

                accountTreesTreeView1.AddAccountTree(response.AccountTreeHeader);
                accountTreesTreeView1.AddAccounts(response.Items);
            }
        }

        private void btnBeginEdit_Click(object sender, EventArgs e)
        {
            BeginEdit();
        }

        private void btnEndEdit_Click(object sender, EventArgs e)
        {
            EndEdit();
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            CancelEdit();
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            accountTreesTreeView1.NewChild();
            BeginCreate();
        }


        private void btnNewBrother_Click(object sender, EventArgs e)
        {
            accountTreesTreeView1.NewBrother();
            BeginCreate();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTree();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var request = new Business.UpdateCompleteAccountTreeRequest();

            var createdTrees = new List<AccountTreeListItem>();
            var updatedTrees = new List<AccountTreeListItem>();
            var updatedAccounts = new List<ContableAccount>();
            var createdAccounts = new List<ContableAccount>();

            foreach (var tree in accountTreesTreeView1.Trees)
            {
                if (tree.IsNew())
                    createdTrees.Add(tree);
                else if (tree.IsDirty())
                    updatedTrees.Add(tree);
            }

            foreach (var account in accountTreesTreeView1.Accounts)
            {
                if (account.IsNew())
                    createdAccounts.Add(account);
                else if (account.IsDirty())
                    updatedAccounts.Add(account);
            }

            request.CreatedTrees = createdTrees.ToArray();
            request.UpdatedTrees = updatedTrees.ToArray();
            request.CreatedAccounts = createdAccounts.ToArray();
            request.UpdatedAccounts = updatedAccounts.ToArray();
            
            if (request.IsValid())
            {
                request.Run();
                RefreshTree();
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

        private void accountTreesTreeView1_CurrentChanged(object sender, EventArgs e)
        {
            accountTreeListItemEditor1.Visible = false;
            contableAccountEditor1.Visible = false;

            var editor = GetNodeEditor(accountTreesTreeView1.Current);
            if (editor != null)
            {
                editor.EditableObject = accountTreesTreeView1.Current;
                editor.Visible = true;
            }
        }
    }
}
