using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryManagement.Core
{
    class control
    {
        public static void disabledBtns(Button[] btns = null)
        {
            if (btns != null)
            {
                foreach (Button a in btns)
                {
                    a.Enabled = false;
                }
            }
        }

        public static void enabledBtns(Button[] btns = null)
        {
            if (btns != null)
            {
                foreach (Button a in btns)
                {
                    a.Enabled = true;
                }
            }
        }
    }
}
