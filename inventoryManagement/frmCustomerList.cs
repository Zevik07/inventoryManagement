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
    public partial class frmCustomerList : Form
    {
        private string preMethod;
        private DataTable CustomerData;
        private bool btnSearchIsClicked = false;
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            // Default textbox's state
            setControlReadMode();
        }

        private void resetTxt()
        {
            txtId.Text = "";
            txtName.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }

        private void setTxt()
        {
            DataGridViewRow cRow = dgvCustomer.CurrentRow;

            if (cRow == null)
                return;
            
            // In view mode
            if (btnAdd.Enabled && btnEdit.Enabled)
                txtId.Text = 
                    cRow.Cells[0].Value.ToString();

            txtName.Text = 
                cRow.Cells[1].Value.ToString();

            txtAddress.Text = 
                cRow.Cells[2].Value.ToString();

            txtPhone.Text = 
                cRow.Cells[3].Value.ToString();
        }

        private bool validateTxt()
        {
            if (txtName.Text.Trim().Length == 0 ||
                txtAddress.Text.Trim().Length == 0 ||
                txtPhone.Text.Trim().Length == 0)
            {
                notify.showNoti("Vui lòng tất cả các trường");
                return false;
            }    
            return true;
        }

        private void setControlReadMode(bool yes = true)
        {
            if (yes)
            {
                txtName.ReadOnly = true;
                txtAddress.ReadOnly = true;
                txtPhone.ReadOnly = true;
            }
            else
            {
               
                txtName.ReadOnly = false;
                txtAddress.ReadOnly = false;
                txtPhone.ReadOnly = false;
            }
        }

        private void LoadDataGridView()
        {
            string sql =
                "SELECT id, name, address, phone FROM customers";

            CustomerData = db.GetDataToTable(sql);

            dgvCustomer.DataSource = CustomerData;

            // Load textbox
            setTxt();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnAdd, btnSearch });

            // Change button state
            if (dgvCustomer.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }
            else
            {
                control.enabledBtns(new[] { btnDelete, btnEdit });
            }
        }

        private void dgvCustomer_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgvCustomer.Rows.Count == 0)
            {
                notify.showNoti("Không có dữ liệu");
                return;
            }

            setTxt();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            preMethod = "add";

            resetTxt();

            setControlReadMode(false);

            // Increase id
            string cellId = 
                dgvCustomer.Rows[dgvCustomer.RowCount - 1].Cells[0].Value.ToString();
            txtId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();
            // Focus
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

                        sql = "INSERT INTO customers(id, name, address, phone) " +
                              "VALUES(N'" +
                              txtId.Text.ToString() + "',N'" +
                              txtName.Text.ToString() + "',N'" +
                              txtAddress.Text.ToString() + "','" +
                              txtPhone.Text.ToString() +
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

                        sql = "UPDATE customers SET " +
                            "name = N'" + txtName.Text.ToString()
                            + "', address = N'" + txtAddress.Text.ToString()
                            + "', phone = '" + txtPhone.Text.ToString()
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
            control.enabledBtns(new[] { btnDelete, btnAdd, 
                btnEdit, btnSearch });

            if (dgvCustomer.Rows.Count == 0)
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
                string sql = "DELETE customers WHERE id='" + txtId.Text + "'";

                db.Write(sql);

                LoadDataGridView();
            }
        }

        private void lblSearch_MouseMove(object sender, MouseEventArgs e)
        {
            string msg =
                "Có thể tìm kiếm bằng: \n" +
                "- Mã khách \n" +
                "- Tên khách \n" +
                "- Địa chỉ khách \n" +
                "- Số điện thoại khách \n";

            toolTip1.SetToolTip(lblSearch, msg);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnSearchIsClicked = true;

            if (txtSearch.Text.ToString().Trim() == "")
            {
                notify.showNoti("Vui lòng nhập nội dung tìm kiếm");
                return;
            }

            string qr =
                "SELECT id, name, address, phone " +
                "FROM customers c " +
                "where " +
                "c.id like '%" + txtSearch.Text + "%' " +
                "or c.name like N'%" + txtSearch.Text + "%' " +
                "or c.address like N'%" + txtSearch.Text + "%' " +
                "or c.phone like '%" + txtSearch.Text + "%';";

            DataTable search = db.GetDataToTable(qr);

            dgvCustomer.DataSource = search;

            resetTxt();

            setTxt();

            control.disabledBtns(new[] { btnAdd });
            control.enabledBtns(new[] { btnUndo });

            if (dgvCustomer.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }
            else
            {
                control.enabledBtns(new[] { btnDelete, btnEdit });
            }
        }
    }
}
