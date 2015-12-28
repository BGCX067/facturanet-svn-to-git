using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facturanet.Util;
using Facturanet.UI;

namespace Facturanet.WinformsClient.Controls
{
    public class AccountTreeListItemTreeNode : Util.FacturanetTreeNode
    {
        public AccountTreeListItemTreeNode(AccountTreeListItem data)
            : base(data)
        {
        }

        public AccountTreeListItem AccountTreeListItem
        {
            get { return (AccountTreeListItem)Data; }
        }

        protected override string GetNodeName()
        {
            return AccountTreeListItem.Id.ToString();
        }

        protected override string GetNodeText()
        {
            return string.Format(
                "[{0}] {1}",
                AccountTreeListItem.Code,
                AccountTreeListItem.Name);
        }

        protected override string GetNodeToolTipText()
        {
            return AccountTreeListItem.Description;
        }
    }
}
