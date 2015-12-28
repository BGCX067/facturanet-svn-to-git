using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Facturanet.WinformsClient.Util
{
    public class FacturanetBindingNavigator : BindingNavigator
    {
        
        public FacturanetBindingNavigator(System.ComponentModel.IContainer container)
            : base(container)
        { }

        public FacturanetBindingNavigator(BindingSource bindingSource)
            : base(bindingSource)
        { }

        public FacturanetBindingNavigator(bool addStandardItems)
            : base(addStandardItems)
        { }

        protected override void OnLostFocus(EventArgs e)
        {
            RefreshItemsCore();
            base.OnLostFocus(e);
        }

        protected override void OnClick(EventArgs e)
        {
            //de esta forma no me borra el anteultimo si estoy creando el ultimo
            var uno = BindingSource.Current;
            this.Focus();
            var dos = BindingSource.Current;
            DeleteItem.Enabled &= uno == dos;
            ///////////////////////////////////////

            //de esta forma solo evito la excepcion al eliminar el último nuevo vacio
            //this.Focus();
            ///////////////////////////////////////

            base.OnClick(e);
        }
    }
}
