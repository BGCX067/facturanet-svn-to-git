using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Facturanet.Util;

namespace Facturanet.WinformsClient.Util
{
    public abstract class FacturanetTreeNode : TreeNode
    {
        public Type DataType { get; private set; }
        protected bool TypeIsUIObject { get; private set; }
        protected bool TypeIsEditable { get; private set; }
        protected bool TypeIsDeletable { get; private set; }

        public object Data { get; private set; }
        
        public FacturanetTreeNode(object data)
            : base()
        {
            DataType = data.GetType();
            TypeIsUIObject = DataType.ImplementsInterface<UI.IUIObject>();
            TypeIsEditable = DataType.ImplementsInterface<UI.IEditableUIObject>();
            TypeIsDeletable = DataType.ImplementsInterface<UI.IDeletableUIObject>();
            Data = data;

            if (TypeIsEditable)
            {
                var editable = data as UI.IEditableUIObject;
                editable.DiscartableChangesControl = true;
                editable.PropertyChanged += new PropertyChangedEventHandler(editable_PropertyChanged);
            }

            RefreshData();
        }

        void editable_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            RefreshData();
        }

        public virtual void RefreshData()
        {
            Name = GetNodeName();
            Text = GetNodeText();
            ToolTipText = GetNodeToolTipText();
        }

        protected abstract string GetNodeName();
        protected abstract string GetNodeText();
        protected abstract string GetNodeToolTipText();
    }
}
