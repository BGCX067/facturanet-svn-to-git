using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Facturanet.WinformsClient.Util
{
    public static class BindingSourceExtensions
    {
        public static T GetCurrent<T>(this BindingSource bindingSource)
            where T : class
        {
            return bindingSource.Current as T;
        }
    }
}
