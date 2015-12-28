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
    public class ContableAccountTreeNode : Util.FacturanetTreeNode
    {
        public ContableAccountTreeNode(ContableAccount data)
            : base(data)
        {
        }


        public ContableAccount ContableAccount 
        {
            get { return (ContableAccount)Data; }
        }

        protected override string GetNodeName()
        {
            return ContableAccount.Id.ToString();
        }

        protected override string GetNodeText()
        {
            return string.Format(
                "[{0}] {1}",
                ContableAccount.Code,
                ContableAccount.Name);
        }

        protected override string GetNodeToolTipText()
        {
            return ContableAccount.Description;
        }
    }
}
