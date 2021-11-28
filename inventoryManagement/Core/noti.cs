using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryManagement.Core
{
    class noti
    {
        public static void info (string msg = "Đây là thông báo",
            string title = "Thông báo")
        {
            MessageBox.Show(msg, title,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
