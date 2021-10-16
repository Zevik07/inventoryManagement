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
    public partial class frmCategoryList : Form
    {
        public frmCategoryList()
        {
            InitializeComponent();
        }

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            this.dgvCategory.Rows.Add("1", "XsdfsdfsdX");
            this.dgvCategory.Rows.Add("123", "XsdfsdfsdX");
            this.dgvCategory.Rows.Add("11", "XXsss");
            this.dgvCategory.Rows.Add("12", "XsdfX");
            this.dgvCategory.Rows.Add("12", "XX");
            this.dgvCategory.Rows.Add("1", "XsdfsX");
            this.dgvCategory.Rows.Add("1", "XX");
            this.dgvCategory.Rows.Add("1", "XX");
            this.dgvCategory.Rows.Add("1", "XsdfsdfsdX");
            this.dgvCategory.Rows.Add("123", "XsdfsdfsdX");
            this.dgvCategory.Rows.Add("11", "XXsss");
            this.dgvCategory.Rows.Add("121231231", "XsdfX");
            this.dgvCategory.Rows.Add("12", "XX");
            this.dgvCategory.Rows.Add("1", "XsdfsX");
            this.dgvCategory.Rows.Add("1", "XX");
            this.dgvCategory.Rows.Add("1", "XX");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
