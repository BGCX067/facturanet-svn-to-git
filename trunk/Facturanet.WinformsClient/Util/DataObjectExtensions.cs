using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace Facturanet.WinformsClient.Util
{
    public static class DataObjectExtensions
    {
        public static T GetTypedData<T>(this IDataObject data)
        {
            if (data.GetDataPresent(typeof(T)))
                return (T)data.GetData(typeof(T));
            else
                return default(T);
        }
    }
}
