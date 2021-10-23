using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 
using inventoryManagement.Core;

namespace inventoryManagement
{
    public partial class frmCategoryList : Form
    {
        private DataTable tblCategoryData;
        public frmCategoryList()
        {
            InitializeComponent();
        }

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            disabledBtns();
            LoadDataGridView();
        }

        private void disabledBtns()
        {
            txtId.Enabled = false;
            btnSave.Enabled = false;
            btnUndo.Enabled = false;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT id, name FROM categories";
            tblCategoryData = db.GetDataToTable(sql); //Đọc dữ liệu từ bảng
            dgvCategory.DataSource = tblCategoryData; //Nguồn dữ liệu            
            dgvCategory.Columns[0].HeaderText = "Mã ngành hàng";
            dgvCategory.Columns[1].HeaderText = "Tên ngành hàng";
            disabledDgv();
            /*dgvCategory.Columns[0].Width = 100;
            dgvCategory.Columns[1].Width = 300;*/
            
        }

        private void disabledDgv()
        {
            // Ngăn sửa và thao tác trực tiếp
            dgvCategory.AllowUserToAddRows = false; 
            dgvCategory.EditMode = DataGridViewEditMode.EditProgrammatically;
        }
    }
}
