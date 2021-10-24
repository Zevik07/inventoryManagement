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
using System.Globalization;

namespace inventoryManagement
{
    public partial class frmEmployeeList : Form
    {
        private string preMethod;
        private DataTable EmployeeData;
        public frmEmployeeList()
        {
            InitializeComponent();
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            LoadDataGridView();
            // Default buttons's state
            control.disabledBtns(new[] { btnUndo, btnSave });
            // Default textbox's state
            setControlReadMode();
        }

        private void ResetTxt()
        {
            txtId.Text = "";
            txtName.Text = "";
            chkGender.Checked = false;
            txtAddress.Text = "";
            txtPhone.Text = "";
            dtpBirthday.Value = new DateTime(1985, 6, 20);
        }

        private void setControlReadMode(bool yes = true)
        {
            if (yes)
            {
                txtName.ReadOnly = true;

                // Checkbox
                chkGender.ForeColor = Color.DarkSlateGray; // Read-only appearance
                chkGender.AutoCheck = false;      // Read-only behavior 

                txtAddress.ReadOnly = true;
                txtPhone.ReadOnly = true;
                dtpBirthday.Enabled = false;
            }
            else
            {
                txtName.ReadOnly = false;

                // Checkbox
                chkGender.ForeColor = Color.Black; // Read-only appearance
                chkGender.AutoCheck = true;      // Read-only behavior 

                txtAddress.ReadOnly = false;
                txtPhone.ReadOnly = false;
                dtpBirthday.Enabled = true;
            }
        }

        private void setTxt()
        {
            DataGridViewRow cRow = dgvEmployee.CurrentRow;
            if (cRow == null)
                return;

            txtId.Text =
                    cRow.Cells[0].Value.ToString();
            txtName.Text =
                    cRow.Cells[1].Value.ToString();
            chkGender.Checked =
                    cRow.Cells[2].Value.ToString() == "Nam" ?
                    false : true;
            txtAddress.Text =
                    cRow.Cells[3].Value.ToString();
            txtPhone.Text =
                    cRow.Cells[4].Value.ToString();
            dtpBirthday.Value =
                    DateTime.ParseExact(cRow.Cells[5].Value.ToString(), "dd/MM/yyyy",
                    CultureInfo.CreateSpecificCulture("en-GB"));

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
