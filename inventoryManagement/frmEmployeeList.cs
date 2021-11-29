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
using System.Text.RegularExpressions;

namespace inventoryManagement
{
    public partial class frmEmployeeList : Form
    {
        private string preMethod;
        private DataTable EmployeeData;
        private bool btnSearchIsClicked = false;
        public frmEmployeeList()
        {
            InitializeComponent();
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            // Default textbox's state
            setControlReadMode();

            txtSearch.Select();
        }

        private void resetTxt()
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
                        cRow.Cells["id"].Value.ToString();

            txtName.Text =
                    cRow.Cells["name"].Value.ToString();
            chkGender.Checked =
                    cRow.Cells["gender"].Value.ToString() == "Nam" ?
                    false : true;
            txtPhone.Text =
                    cRow.Cells["phone"].Value.ToString();
            txtAddress.Text =
                   cRow.Cells["address"].Value.ToString();
            dtpBirthday.Value =
                    DateTime.ParseExact(cRow.Cells["birthday"].Value.ToString(),
                    "dd/MM/yyyy",
                    CultureInfo.CreateSpecificCulture("en-GB"));
        }

        private bool validateTxt()
        {
            if (txtName.Text.Trim().Length == 0 ||
                txtAddress.Text.Trim().Length == 0 ||
                txtPhone.Text.Trim().Length == 0)
            {
                noti.info("Vui lòng nhập tất cả các trường");
                return false;
            }
            string phonePattern =
                @"^((09(\d){8})|(086(\d){7})|(088(\d){7})|(089(\d){7})|(01(\d){9}))$";

            if (!Regex.IsMatch(txtPhone.Text.Trim(), phonePattern))
            {
                noti.warn("Số điện thoại không đúng định dạng");
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
            // Increase id
            string cellId = "0";
            if (dgvEmployee.CurrentRow != null)
            {
                cellId =
                    dgvEmployee.Rows[dgvEmployee.RowCount - 1]
                    .Cells[0].Value.ToString();
            }

            txtId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();
        }
        private string getCell(string name)
        {
            DataGridViewRow cRow = dgvEmployee.CurrentRow;
            return cRow != null ? cRow.Cells[name].Value.ToString() : null;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql =
                "SELECT id, name, gender, address, phone, " +
                "FORMAT(birthday, 'dd/MM/yyyy') as birthday " +
                " FROM employees";

            EmployeeData = db.GetDataToTable(sql);
            dgvEmployee.DataSource = EmployeeData;

            // Load textbox
            setTxt();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnAdd, btnSearch });

            // Change button state
            if (dgvEmployee.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }
            else
            {
                control.enabledBtns(new[] { btnEdit, btnDelete });
            }
        }

        private void dgvEmployee_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvEmployee.Rows.Count == 0)
            {
                noti.info("Không có dữ liệu");
                return;
            }

            setTxt();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            preMethod = "add";

            resetTxt();

            setId();

            setControlReadMode(false);

            txtName.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit,
                btnDelete, btnSearch });
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
                            txtName.Focus();
                            return;
                        }

                        sql =
                            "INSERT INTO " +
                            "employees" +
                            "(id, name, gender, address, phone, birthday) " +
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
                            + "', address = '" + txtAddress.Text.ToString()
                            + "', phone = '" + txtPhone.Text.ToString()
                            + "', birthday = '" + dtpBirthday.Value
                            + "' WHERE id = '" + txtId.Text + "'";
                    }
                    break;
                default:
                    sql = "";
                    break;
            }

            if (db.Write(sql))
            {
                LoadDataGridView();

                setControlReadMode();

                if (btnSearchIsClicked)
                {
                    btnSearchIsClicked = false;
                    btnSearch_Click(this, new EventArgs());
                }
            }
            else
            {
                txtName.Focus();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            preMethod = "edit";

            setControlReadMode(false);

            txtName.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit, 
                btnDelete, btnSearch });
            control.enabledBtns(new[] { btnUndo, btnSave });
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            setTxt();

            setControlReadMode();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, btnEdit, btnSearch });

            if (dgvEmployee.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }

            if (btnSearchIsClicked)
            {
                txtSearch.Text = "";
                btnSearchIsClicked = false;
                LoadDataGridView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs =
                   MessageBox.Show("Bạn có chắc muốn xoá không? \n" +
                   "ĐIỀU NÀY SẼ XÓA MỌI THÔNG TIN LIÊN QUAN", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs == DialogResult.Yes)
            {
                string sql = "DELETE employees WHERE id='" + txtId.Text + "'";

                db.Write(sql);

                LoadDataGridView();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearchIsClicked = true;

            if (txtSearch.Text.ToString().Trim() == "")
            {
                noti.info("Vui lòng nhập nội dung tìm kiếm");
                return;
            }

            string qr =
                "SELECT id, name, gender, address, phone, " +
                "FORMAT(birthday, 'dd/MM/yyyy') as birthday " +
                "FROM employees e " +
                "where " +
                "e.id like '%" + txtSearch.Text + "%' " +
                "or e.name like N'%" + txtSearch.Text + "%' " +
                "or e.phone like '%" + txtSearch.Text + "%';";

            DataTable search = db.GetDataToTable(qr);

            dgvEmployee.DataSource = search;

            resetTxt();

            setTxt();

            control.disabledBtns(new[] { btnAdd });
            control.enabledBtns(new[] { btnUndo });

            if (dgvEmployee.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }
            else
            {
                control.enabledBtns(new[] { btnDelete, btnEdit });
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void lblSearch_MouseMove(object sender, MouseEventArgs e)
        {
            string msg =
                "Có thể tìm kiếm bằng: \n" +
                "- Mã nhân viên \n" +
                "- Tên nhân viên \n" +
                "- Số điện thoại nhân viên \n";

            toolTip1.SetToolTip(lblSearch, msg);
        }
    }
}
