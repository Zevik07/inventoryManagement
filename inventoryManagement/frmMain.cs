using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventoryManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // Kết nối database 
            Core.db.Connect();
        }

        private void mnuGood_Click(object sender, EventArgs e)
        {
            frmGoodList frmGoodList = new frmGoodList();
            frmGoodList.ShowDialog();
        }

        private void mnuCategory_Click(object sender, EventArgs e)
        {
            frmCategoryList frmCategoryList = new frmCategoryList();
            frmCategoryList.ShowDialog();
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerList frmCustomerList = new frmCustomerList();
            frmCustomerList.ShowDialog();
        }

        private void mnuEmployee_Click(object sender, EventArgs e)
        {
            frmEmployeeList frmEmployeeList = new frmEmployeeList();
            frmEmployeeList.ShowDialog();
        }
    }
}
