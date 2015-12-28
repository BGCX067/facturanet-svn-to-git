using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facturanet.UI;
using Facturanet.Util;
using Facturanet.WinformsClient.Util;

namespace Facturanet.WinformsClient.Controls
{
    public partial class AccountTreesTreeView : UserControl
    {
        //TODO: se podría hacer una interface para cada item que diga cual es el id del arbol al que pertenece, cual es el id y el de padre
        public event EventHandler CurrentChanged;

        protected Dictionary<Guid, AccountTreeListItemTreeNode> RootNodesDictionary { get; private set; }
        protected Dictionary<Guid, ContableAccountTreeNode> AccountNodesDictionary { get; private set; }
        
        protected TreeNode PreviousNode { get; private set; }

        public bool ReadOnly
        {
            get { return !treeView.Enabled; }
            set { treeView.Enabled = !value; }
        }

        public object Current
        {
            get 
            {
                var node = treeView.SelectedNode as FacturanetTreeNode;
                if (node == null)
                    return null;
                else
                    return node.Data;
            }
        }

        public void RemoveCurrent()
        {
            var node = treeView.SelectedNode;
            if (PreviousNode != null)
                treeView.SelectedNode = PreviousNode;
            node.Remove();
        }


        public void NewAccount(Guid accountTreeId, Guid? parentAccountId)
        {
            var account = new ContableAccount();
            account.ParentAccountId = parentAccountId;
            account.AccountTreeId = accountTreeId;
            var node = AddAccount(account);
            treeView.SelectedNode = node;
        }

        public void NewAccountTree()
        {
            var tree = new AccountTreeListItem();
            var node = AddAccountTree(tree);
            treeView.SelectedNode = node;
        }

        public void NewBrother()
        {
            var currentAccount = Current as ContableAccount;
            if (currentAccount != null)
                NewAccount(currentAccount.AccountTreeId, currentAccount.ParentAccountId);
            else
                NewAccountTree();
        }

        public void NewChild()
        {
            var currentAccount = Current as ContableAccount;
            if (currentAccount != null)
                NewAccount(currentAccount.AccountTreeId, currentAccount.Id);
            else
            {
                var currentTree = Current as AccountTreeListItem;
                if (currentTree != null)
                    NewAccount(currentTree.Id, null);
            }
        }

        public IEnumerable<AccountTreeListItem> Trees
        {
            get
            {
                return
                    from node in RootNodesDictionary.Values
                    select node.AccountTreeListItem;
            }
        }

        public IEnumerable<ContableAccount> Accounts
        {
            get
            {
                return
                    from node in AccountNodesDictionary.Values
                    select node.ContableAccount;
            }
        }
        
        public AccountTreesTreeView()
        {
            InitializeComponent();
            Clear();
        }

        public void Clear()
        {
            treeView.Nodes.Clear();
            RootNodesDictionary = new Dictionary<Guid, AccountTreeListItemTreeNode>();
            AccountNodesDictionary = new Dictionary<Guid, ContableAccountTreeNode>();
        }

        public AccountTreeListItemTreeNode AddAccountTree(AccountTreeListItem accountTree)
        {
            var node = new AccountTreeListItemTreeNode(accountTree);
            RootNodesDictionary.Add(accountTree.Id, node);
            treeView.Nodes.Add(node);
            return node;
        }

        public void MoveNode(ContableAccountTreeNode node, FacturanetTreeNode parent)
        {
            node.Remove();

            var parentAsAccountTreeListItem = parent.Data as AccountTreeListItem;
            if (parentAsAccountTreeListItem != null)
            {
                node.ContableAccount.AccountTreeId = parentAsAccountTreeListItem.Id;
                node.ContableAccount.ParentAccountId = null;
            }
            else
            {
                var parentAsContableAccount = parent.Data as ContableAccount;
                node.ContableAccount.AccountTreeId = parentAsContableAccount.AccountTreeId;
                node.ContableAccount.ParentAccountId = parentAsContableAccount.Id;
            }
                
            parent.Nodes.Add(node);
        }

        public ContableAccountTreeNode AddAccount(ContableAccount account)
        {
            var node = new ContableAccountTreeNode(account);
            AccountNodesDictionary.Add(account.Id, node);
            TreeNode parentNode;
            if (!account.ParentAccountId.HasValue)
                parentNode = RootNodesDictionary[account.AccountTreeId];
            else if (AccountNodesDictionary.ContainsKey(account.ParentAccountId.Value))
                parentNode = AccountNodesDictionary[node.ContableAccount.ParentAccountId.Value];
            else
                parentNode = null;
            
            if (parentNode != null)
                parentNode.Nodes.Add(node);

            return node;
        }

        public void AddAccounts(IEnumerable<ContableAccount> accounts)
        {
            treeView.BeginUpdate();

            var pendents = new List<ContableAccountTreeNode>();

            foreach(var account in accounts)
            {
                var node = AddAccount(account);
                if (node.Parent == null)
                    pendents.Add(node);
            }

            //una segunda pasada para las que quedaron sin padre por el orden
            foreach (var node in pendents)
            {
                var parentNode = AccountNodesDictionary[node.ContableAccount.ParentAccountId.Value];
                parentNode.Nodes.Add(node);
            }

            treeView.EndUpdate();
        }

        private void treeView_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            PreviousNode = treeView.SelectedNode;
        }

        protected void OnCurrentChanged()
        {
            if (CurrentChanged != null)
                CurrentChanged(this, EventArgs.Empty);
        }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            OnCurrentChanged();
        }

        private void treeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //solo arastrar si es un ContableAccountTreeNode
            ContableAccountTreeNode contableAccountTreenode = e.Item as ContableAccountTreeNode;
            if (contableAccountTreenode != null)
                treeView.DoDragDrop(contableAccountTreenode, DragDropEffects.Move);
        }

        private TreeNode DestinationNode(TreeView treeView, int X, int Y)
        {
            Point pt = treeView.PointToClient(new Point(X, Y));
            TreeNode DestinationNode = treeView.GetNodeAt(pt);
            return DestinationNode;
        }

        private bool AllowMove(FacturanetTreeNode node, FacturanetTreeNode destination)
        {
            if (destination != null
                && node != null
                && destination != node
                && !node.IsAncestorOf(destination))
            {
                Guid destinationTreeId;
                var destinationAsAccountTreeListItem = destination.Data as AccountTreeListItem;
                if (destinationAsAccountTreeListItem != null)
                    destinationTreeId = destinationAsAccountTreeListItem.Id;
                else
                    destinationTreeId = ((ContableAccount)destination.Data).AccountTreeId;
                return destinationTreeId == ((ContableAccount)node.Data).AccountTreeId;
            }
            else
                return false;
        }

        private void treeView_DragDrop(object sender, DragEventArgs e)
        {
            var destination = DestinationNode((TreeView)sender, e.X, e.Y) as FacturanetTreeNode;
            var dragged = e.Data.GetTypedData<ContableAccountTreeNode>();

            if (AllowMove(dragged, destination))
            {
                e.Effect = DragDropEffects.Move;
                MoveNode(dragged, destination);
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void treeView_DragOver(object sender, DragEventArgs e)
        {
            var destination = DestinationNode((TreeView)sender, e.X, e.Y) as FacturanetTreeNode;
            var dragged = e.Data.GetTypedData<ContableAccountTreeNode>();

            if (AllowMove(dragged, destination))
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}
