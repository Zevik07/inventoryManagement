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
        private DataTable CategoryData;
        private string preMethod;
        public frmCategoryList()
        {
            InitializeComponent();
        }

        private void frmCategoryList_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            // Default buttons's state
            control.disabledBtns(new[] { btnUndo, btnSave });

            // Default for control
            setControlReadMode();
        }

        private void ResetTxt()
        {
            txtId.Text = "";
            txtName.Text = "";
        }

        private void setTxt()
        {
            if (dgvCategory.CurrentRow == null)
                return;

            if (btnAdd.Enabled && btnEdit.Enabled) // Ở trạng thái bình thường
                txtId.Text = 
                    dgvCategory.CurrentRow.Cells[0].Value.ToString();

            txtName.Text = 
                dgvCategory.CurrentRow.Cells[1].Value.ToString();
        }
        private void disabledDgv()
        {
            // prevent edit
            /*dgvCategory.EditMode = DataGridViewEditMode.EditProgrammatically;*/
        }

        private void setControlReadMode(bool yes = true)
        {
            if (yes)
            {
                txtName.ReadOnly = true;
            }
            else
            {
                txtName.ReadOnly = false;
            }
        }

        private void setId()
        {
            string cellId = "0";

            if (dgvCategory.CurrentRow != null)
            {
                cellId =
                    dgvCategory.Rows[dgvCategory.RowCount - 1]
                    .Cells[0].Value.ToString();
            }

            txtId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();
        }

        private void LoadDataGridView()
        {
            string sql;
            sql = "SELECT id, name FROM categories";

            CategoryData = db.GetDataToTable(sql);
            dgvCategory.DataSource = CategoryData;

            // Load textbox
            setTxt();

            // Change button state
            if (dgvCategory.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }    
        }

        private void dgvCategory_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCategory.Rows.Count == 0)
            {
                notify.showNoti("Không có dữ liệu");
                return;
            }

            setTxt();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            preMethod = "add";

            ResetTxt();

            setControlReadMode(false);

            setId();

            txtName.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit, btnDelete });
            control.enabledBtns(new[] { btnUndo, btnSave });
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

                        sql = "INSERT INTO categories(id, name) " +
                              "VALUES(N'" +
                              txtId.Text.ToString() + "',N'" +
                              txtName.Text.ToString() + 
                              "')";
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

                        sql = "UPDATE categories SET name=N'" +
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

            setControlReadMode();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, btnEdit });
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            preMethod = "edit";

            setControlReadMode(false);

            txtName.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit, btnDelete });
            control.enabledBtns(new[] { btnUndo, btnSave });
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            setTxt();

            setControlReadMode(false);

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
