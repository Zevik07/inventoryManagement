using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using inventoryManagement.Core;

namespace inventoryManagement
{
    public partial class frmGoodList : Form
    {
        private string preMethod;
        private DataTable goodData;

        public frmGoodList()
        {
            InitializeComponent();
        }

        private void frmGoodList_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            // Default buttons's state
            control.disabledBtns(new[] { btnUndo, btnSave });

            // Default textbox's state
            setControlReadMode();
        }

        private void ResetTxt()
        {
            txtName.Text = "";
            numQty.Value = 0;
            txtPriceIn.Text = "";
            txtPriceOut.Text = "";
            txtNote.Text = "";
            pbImg.ImageLocation = "";
        }

        private void setControlReadMode(bool yes = true)
        {
            if (yes)
            {
                txtName.ReadOnly = true;
                numQty.ReadOnly = true;
                txtPriceIn.ReadOnly = true;
                txtPriceOut.ReadOnly = true;
                txtNote.ReadOnly = true;
                btnOpenImg.Enabled = false;
            }
            else
            {
                txtName.ReadOnly = false;
                numQty.ReadOnly = false;
                txtPriceIn.ReadOnly = false;
                txtPriceOut.ReadOnly = false;
                txtNote.ReadOnly = false;
                btnOpenImg.Enabled = false;
            }
        }

        private void setTxt()
        {
            DataGridViewRow cRow = dgvGood.CurrentRow;
            if (cRow == null)
                return;

            txtId.Text =
                    cRow.Cells[0].Value.ToString();
            txtName.Text = cRow.Cells[0].Value.ToString();
            


        }
        private void disabledDgv()
        {
            // Prevent edit row
            /*dgvEmployee.EditMode = DataGridViewEditMode.EditProgrammatically;*/
        }

        private bool validateTxt()
        {
            if (txtName.Text.Trim().Length == 0 ||
                txtAddress.Text.Trim().Length == 0 ||
                txtPhone.Text.Trim().Length == 0)
            {
                notify.showNoti("Vui lòng nhập tất cả các trường");
                return false;
            }
            return true;
        }

        private string getGender()
        {
            return chkGender.Checked ? "Nữ" : "Nam";
        }
        private void LoadDataGridView()
        {
            string sql;
            sql =
                "SELECT id, name, gender, address, phone, "
                + "FORMAT(birthday, 'dd/MM/yyyy') as birthday"
                + " FROM employees";

            EmployeeData = db.GetDataToTable(sql);
            dgvEmployee.DataSource = EmployeeData;

            // Load textbox
            setTxt();

            // Change button state
            if (dgvEmployee.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }

            disabledDgv();
        }

        private void dgvEmployee_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (btnAdd.Enabled == false)
            {
                notify.showNoti("Bạn đang ở trạng thái thêm hoặc sửa, nhấn quay lại");
                dgvEmployee.Focus();
                return;
            }

            if (dgvEmployee.Rows.Count == 0)
            {
                notify.showNoti("Không có dữ liệu");
                return;
            }

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, btnEdit });

            setTxt();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            preMethod = "add";

            control.disabledBtns(new[] { btnAdd, btnEdit, btnDelete });
            control.enabledBtns(new[] { btnUndo, btnSave });
            ResetTxt();

            setControlReadMode(false);

            // Increase Id
            string cellId =
                    dgvEmployee.Rows[dgvEmployee.RowCount - 1].Cells[0].Value.ToString();
            txtId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();
            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;

            switch (preMethod)
            {
                case "add":
                    {
                        if (!validateTxt())
                        {
                            return;
                        }

                        sql =
                            "INSERT INTO employees(name, gender, address, phone, birthday) " +
                            "VALUES(N'" +
                            txtName.Text.ToString() + "',N'" +
                            getGender() + "',N'" +
                            txtAddress.Text.ToString() + "','" +
                            txtPhone.Text.ToString() + "','" +
                            dtpBirthday.Value +
                            "')";
                    }
                    break;
                case "edit":
                    {
                        if (!validateTxt())
                        {
                            txtName.Focus();
                            return;
                        }

                        sql = "UPDATE employees SET name = N'" +
                            txtName.Text.ToString()
                            + "', gender = N'" + getGender()
                            + "', address = N'" + txtAddress.Text.ToString()
                            + "', phone = '" + txtPhone.Text.ToString()
                            + "', birthday = '" + dtpBirthday.Value
                            + "' WHERE id = '" + txtId.Text + "'";
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

            setControlReadMode(false);

            txtName.Focus();
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
                   MessageBox.Show("Bạn có chắc muốn xoá không?", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "DELETE employees WHERE id='" + txtId.Text + "'";
                db.Write(sql);
                LoadDataGridView();
            }
        }
    }
}
