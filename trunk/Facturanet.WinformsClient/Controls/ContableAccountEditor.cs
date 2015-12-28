using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Facturanet.WinformsClient.Controls
{
    [ToolboxItem(true)]
    public partial class ContableAccountEditor : ContableAccountEditorBase
    {
        public ContableAccountEditor()
        {
            InitializeComponent();
        }
    }

    public class ContableAccountEditorBase : Util.FacturanetEditorControl
    {
        public ContableAccountEditorBase()
            : base(typeof(UI.ContableAccount))
        {
        }
    }
}
