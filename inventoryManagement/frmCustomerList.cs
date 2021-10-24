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
    public partial class frmCustomerList : Form
    {
        private string preMethod;
        private DataTable CustomerData;
        public frmCustomerList()
        {
            InitializeComponent();
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
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
            txtAddress.Text = "";
            txtPhone.Text = "";
        }

        private void setTxt()
        {
            if (dgvCustomer.CurrentRow == null)
                return;

            txtId.Text = dgvCustomer.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dgvCustomer.CurrentRow.Cells[1].Value.ToString();
            txtAddress.Text = dgvCustomer.CurrentRow.Cells[2].Value.ToString();
            txtPhone.Text = dgvCustomer.CurrentRow.Cells[3].Value.ToString();
        }
        private void disabledDgv()
        {
            // Prevent add, edit row
            /*dgvCustomer.EditMode = DataGridViewEditMode.EditProgrammatically;*/
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
            string sql;
            sql = "SELECT id, name, address, phone FROM customers";

            CustomerData = db.GetDataToTable(sql);
            dgvCustomer.DataSource = CustomerData;

            // Load textbox
            setTxt();

            // Change button state
            if (dgvCustomer.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }

            disabledDgv();
        }

        private void dgvCustomer_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (btnAdd.Enabled == false)
            {
                notify.showNoti("Bạn đang ở trạng thái thêm hoặc sửa, nhấn quay lại");
                dgvCustomer.Focus();
                return;
            }

            if (dgvCustomer.Rows.Count == 0)
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

            // Increase id
            string cellId = dgvCustomer.Rows[dgvCustomer.RowCount - 1].Cells[0].Value.ToString();
            txtId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();
            // Focus
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
                            txtName.Focus();
                            return;
                        }

                        sql = "INSERT INTO customers(name, address, phone) " +
                              "VALUES(N'" + 
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

                        sql = "UPDATE customers SET name = N'" + txtName.Text.ToString()
                            + "', address = N'" + txtAddress.Text.ToString()
                            + "', phone = '" + txtPhone.Text.ToString()
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
                   MessageBox.Show("Bạn có muốn xoá không?", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "DELETE customers WHERE id='" + txtId.Text + "'";
                db.Write(sql);
                LoadDataGridView();
            }
        }
    }
}
