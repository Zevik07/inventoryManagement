using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

        public static string convertToUnSign3(string s)
        {
            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = s.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
    }
}
