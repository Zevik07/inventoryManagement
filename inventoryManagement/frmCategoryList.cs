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
        private string preMethod;
        public frmCategoryList()
        {
            InitializeComponent();
            //Default setting components
            dgvCategory.AutoGenerateColumns = false;
        }

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            control.disabledBtns(new[] { btnUndo, btnSave });
        }

        private void ResetTxt()
        {
            txtId.Text = "";
            txtName.Text = "";
        }

        private void setTxt()
        {
            txtId.Text = dgvCategory.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvCategory.CurrentRow.Cells[1].Value.ToString();
        }
        private void disabledDgv()
        {
            // prevent add, edi row
            dgvCategory.AllowUserToAddRows = false;
            dgvCategory.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT id, name FROM categories";

            tblCategoryData = db.GetDataToTable(sql);
            dgvCategory.DataSource = tblCategoryData;

            // Load textbox
            txtId.Text = dgvCategory.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvCategory.CurrentRow.Cells[1].Value.ToString();

            // Change button state
            if (dgvCategory.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }    

            disabledDgv();
        }

        private void dgvCategory_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (btnAdd.Enabled == false)
            {
                notify.showNoti("Bạn đang ở trạng thái thêm hoặc sửa, nhấn quay lại");
                dgvCategory.Focus();
                return;
            }

            if (dgvCategory.Rows.Count == 0)
            {
                notify.showNoti("Không có dữ liệu");
                return;
            }

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, btnEdit });

            txtId.Text = dgvCategory.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvCategory.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            preMethod = "add";

            control.disabledBtns(new[] { btnAdd, btnEdit, btnDelete });
            control.enabledBtns(new[] { btnUndo, btnSave });
            ResetTxt();

            // Txt
            txtId.Text = (dgvCategory.Rows.Count + 1).ToString();
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;

            switch (preMethod)
            {
                case "add":
                    {
                        if (txtName.Text.Trim().Length == 0)
                        {
                            notify.showNoti("Vui lòng nhập tên ngành hàng");
                            txtName.Focus();
                            return;
                        }

                        sql = "INSERT INTO categories(name) " +
                              "VALUES('" + txtName.Text.ToString() + "')";
                    }
                    break;
                case "edit":
                    {
                        if (txtName.Text.Trim().Length == 0)
                        {
                            notify.showNoti("Tên ngành hàng không hợp lệ");
                            txtName.Focus();
                            return;
                        }

                        sql = "UPDATE categories SET name='" +
                            txtName.Text.ToString() +
                            "' WHERE id='" + txtId.Text + "'";
                    }
                    break;
                default:
                    sql = "";
                    break;
            }

            db.Write(sql);
            LoadDataGridView();
            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, btnEdit });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            preMethod = "edit";

            control.disabledBtns(new[] { btnAdd, btnEdit, btnDelete });
            control.enabledBtns(new[] { btnUndo, btnSave });

            txtName.Focus();
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            setTxt();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, btnEdit });
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs = 
                   MessageBox.Show("Bạn có muốn xoá không?", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "DELETE categories WHERE id='" + txtId.Text + "'";
                db.Write(sql);
                LoadDataGridView();
            }
        }
    }
}
