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

            // Data grid view column order
            dgvEmployee.Columns["Column5"].DisplayIndex = 4;
            dgvEmployee.Columns["Column6"].DisplayIndex = 5;
        }

        private void ResetTxt()
        {
            txtId.Text = "";
            txtName.Text = "";
            chkGender.Checked = false;
            txtAddress.Text = "";
            txtPhone.Text = "";
            dtpBirthday.Value = new DateTime(1995, 6, 20);
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

            // In view mode
            if (btnAdd.Enabled && btnEdit.Enabled)
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

        private void setId()
        {
            // Increase Id
            string cellId = "0";
            if (dgvEmployee.CurrentRow != null)
            {
                cellId =
                    dgvEmployee.Rows[dgvEmployee.RowCount - 1].Cells[0].Value.ToString();
            }

            txtId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();
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
        }

        private void dgvEmployee_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvEmployee.Rows.Count == 0)
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

            setId();

            setControlReadMode(false);

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
                        if (!validateTxt())
                        {
                            return;
                        }

                        sql =
                            "INSERT INTO employees(id, name, gender, address, phone, birthday) " +
                            "VALUES(N'" +
                            txtId.Text.ToString() + "',N'" +
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
                   MessageBox.Show("Bạn có chắc muốn xoá không?", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "DELETE employees WHERE id='" + txtId.Text + "'";
                db.Write(sql);
                LoadDataGridView();
            }
        }

        private void lblSearch_Click(object sender, EventArgs e)
        {
            string msg =
               "Có thể tìm kiếm bằng: \n" +
               "- Mã hóa đơn \n" +
               "- Ngày tạo (định dạng năm-tháng-ngày) \n" +
               "- Tổng thanh toán \n" +
               "- Mã nhân viên \n" +
               "- Mã khách hàng \n" +
               "- Tên nhân viên \n" +
               "- Tên khách \n" +
               "- Số điện thoại khách";

            toolTip1.SetToolTip(lblSearch, msg);
        }
    }
}
