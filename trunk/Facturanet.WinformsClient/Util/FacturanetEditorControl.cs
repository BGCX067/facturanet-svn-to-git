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
    [DockingAttribute(DockingBehavior.Ask)]
    [ToolboxItem(false)]
    public abstract class FacturanetEditorControl : UserControl
    {
        public FacturanetEditorControl(Type type)
        {
            if (!type.ImplementsInterface(typeof(IEditableObject)))
                throw new ApplicationException("Type not implements IEditableObject.");

            bindingSource = new BindingSource(type, "");
            EditableType = type;
            EditableObject = null;
        }

        public Type EditableType { get; private set; }

        protected System.Windows.Forms.BindingSource bindingSource;

        private object editableObject = null;

        public object EditableObject
        {
            get { return editableObject; }
            set 
            {
                if (editableObject != value)
                {
                    SetReadOnly(true);

                    if (value != null && value.GetType().InheritsClass(EditableType))
                    {
                        editableObject = value;
                        bindingSource.DataSource = editableObject;
                    }
                    else
                    {
                        editableObject = null;
                        bindingSource.DataSource = EditableType;
                    }
                }
            }
        }

        private void SetReadOnly(bool value)
        {
            this.Enabled = !value;
        }

        public void BeginEdit()
        {
            ((IEditableObject)editableObject).BeginEdit();
            SetReadOnly(false);
        }

        public void CancelEdit()
        {
            SetReadOnly(true);
            ((IEditableObject)editableObject).CancelEdit();
        }

        public void EndEdit()
        {
            //Acá se podría hacer una validación
            SetReadOnly(true);
            ((IEditableObject)editableObject).EndEdit();
        }
    }
}
