using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using inventoryManagement.Core;

namespace inventoryManagement
{
    public partial class frmOrderList : Form
    {

        private string preMethod;
        private DataTable OrderData;
        private bool btnSearchIsClicked = false;
        public frmOrderList()
        {
            InitializeComponent();
        }

        private void frmBillList_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            // Default buttons's state
            control.disabledBtns(new[] { btnUndo, btnSave });

            // Default textbox's state
            setControlReadMode();
        }

        private void resetTxt()
        {
            txtOrderId.Text = "";
            txtEmployeeName.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtCustomerPhone.Text = "";
            txtOrderPrice.Text = "";
            dtpOrderDate.Value = DateTime.Now;
        }

        private void setControlReadMode(bool yes = true)
        {
            if (yes)
            {
                cbCustomerId.Enabled = false;
                cbEmployeeId.Enabled = false;
                dtpOrderDate.Enabled = false;
            }
            else
            {
                cbCustomerId.Enabled = true;
                cbEmployeeId.Enabled = true;
                dtpOrderDate.Enabled = true;
            }
        }

        private void setTxt()
        {
            DataGridViewRow cRow = dgvOrder.CurrentRow;

            if (cRow == null)
                return;

            if (btnAdd.Enabled && btnAdd.Enabled) // Without add, edit mode
                txtOrderId.Text =
                        cRow.Cells["id"].Value.ToString();

            cbEmployeeId.Text =
                cRow.Cells["employee_id"].Value.ToString();

            txtEmployeeName.Text =
                 cRow.Cells["employee_name"].Value.ToString();

            cbCustomerId.Text =
                cRow.Cells["customer_id"].Value.ToString();

            txtCustomerName.Text =
                 cRow.Cells["customer_name"].Value.ToString();

            txtCustomerAddress.Text =
                 cRow.Cells["customer_address"].Value.ToString();

            txtCustomerPhone.Text =
                 cRow.Cells["customer_phone"].Value.ToString();

            dtpOrderDate.Value = 
                control.getVnDateTime(cRow.Cells["created_at"].Value.ToString());

            txtOrderPrice.Text = cRow.Cells["price"].Value.ToString();

            lblOrderPrice.Text = 
                control.NumberToText(Double.Parse(txtOrderPrice.Text));
        }

        private void setCbCustomerId()
        {
            string qr = "select id from customers";

            DataTable cbData = db.GetDataToTable(qr);

            cbCustomerId.DisplayMember = "id";
            cbCustomerId.DataSource = cbData;

            // If current row is selected
            DataGridViewRow cRow = dgvOrder.CurrentRow;

            if (cRow != null)
            {
                string idValue =
                    cRow.Cells["customer_id"].Value.ToString();

                cbCustomerId.Text = idValue;
            }
        }

        private void setCbEmployeeId()
        {
            string qr = "select id from employees";

            DataTable cbData = db.GetDataToTable(qr);

            cbEmployeeId.DisplayMember = "id";
            cbEmployeeId.DataSource = cbData;

            // If current row is selected
            DataGridViewRow cRow = dgvOrder.CurrentRow;

            if (cRow != null)
            {
                string idValue =
                    cRow.Cells["employee_id"].Value.ToString();

                cbEmployeeId.Text = idValue;
            }
        }

        private void generateId()
        {
            // Increase Id
            string cellId = "0";

            // If dgv is not empty
            if (dgvOrder.CurrentRow != null)
            {
                cellId =
                    dgvOrder.Rows[dgvOrder.RowCount - 1]
                    .Cells["id"].Value.ToString();
            }

            txtOrderId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();
        }

        private void disabledDgv()
        {
            // Prevent edit row
            /*dgvOrder.EditMode = DataGridViewEditMode.EditProgrammatically;*/
        }

        private bool validateTxt()
        {
            if (cbCustomerId.Text.Trim().Length == 0 ||
                cbEmployeeId.Text.Trim().Length == 0)
            {
                notify.showNoti("Không được để trống mã nhân viên và mã khách");
                return false;
            }

            return true;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql =
                "select " +
                "o.id, " +
                "o.employee_id, " +
                "o.customer_id, " +
                "FORMAT(o.created_at, 'hh:mm tt - dd/MM/yyyy') as created_at, " +
                "price, " +
                "e.name as employee_name, " +
                "c.name as customer_name, " +
                "c.address as customer_address, " +
                "c.phone as customer_phone " +
                "from orders o " +
                "inner " +
                "join employees e " +
                "on e.id = o.employee_id " +
                "inner " +
                "join customers c " +
                "on c.id = o.customer_id ";

            OrderData = db.GetDataToTable(sql);
            dgvOrder.DataSource = OrderData;

            // Load textbox
            setTxt();

            // Change button state
            if (dgvOrder.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit, btnDetail, btnPrint });
            }
        }

        private void dgvOrder_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrder.Rows.Count == 0)
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

            generateId();

            setCbCustomerId();

            setCbEmployeeId();

            setControlReadMode(false);

            cbEmployeeId.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit, btnDelete,
                btnSearch, btnDetail, btnPrint });

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
                            "insert into orders " +
                            "(id, created_at, employee_id, customer_id, price) " +
                            "values('" +
                            txtOrderId.Text + "', '" +
                            dtpOrderDate.Value + "', '" +
                            cbEmployeeId.Text + "', '" +
                            cbCustomerId.Text + "', '" +
                            0 +
                            "')";
                    }
                    break;
                case "edit":
                    {
                        if (!validateTxt())
                        {
                            dtpOrderDate.Focus();
                            return;
                        }

                        sql = "UPDATE orders SET"
                            + " created_at = '" + dtpOrderDate.Value
                            + "', employee_id = '" + cbEmployeeId.Text
                            + "', customer_id = '" + cbCustomerId.Text
                            + "' WHERE id = '" + txtOrderId.Text + "'";
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
            control.enabledBtns(new[] { btnDelete, btnAdd, btnEdit, 
                btnSearch, btnDetail, btnPrint });

            // If in search mode, search again after save
            if (btnSearchIsClicked)
            {
                btnSearchIsClicked = false;
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            preMethod = "edit";


            setCbCustomerId();

            setCbEmployeeId();

            setControlReadMode(false);

            dtpOrderDate.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit, 
                btnDelete, btnSearch, btnDetail, btnPrint });
            control.enabledBtns(new[] { btnUndo, btnSave });
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            setTxt();

            setControlReadMode();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, 
                btnEdit, btnSearch, btnPrint, btnDetail });

            if (btnSearchIsClicked)
            {
                btnSearchIsClicked = false;
                LoadDataGridView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs =
                   MessageBox.Show("Bạn có chắc muốn xoá không? \n" +
                   "ĐIỀU NÀY SẼ XÓA MỌI CHI TIẾT HÓA ĐƠN", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                string sql = "DELETE orders WHERE id='" + txtOrderId.Text + "'";

                string currentImgName =
                    dgvOrder.CurrentRow.Cells[6].Value.ToString();

                db.Write(sql);

                LoadDataGridView();
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
                 "select " +
                "o.id, " +
                "o.employee_id, " +
                "o.customer_id, " +
                "FORMAT(o.created_at, 'hh:mm tt - dd/MM/yyyy') as created_at, " +
                "price, " +
                "e.name as employee_name, " +
                "c.name as customer_name, " +
                "c.address as customer_address, " +
                "c.phone as customer_phone " +
                "from orders o " +
                "inner " +
                "join employees e " +
                "on e.id = o.employee_id " +
                "inner " +
                "join customers c " +
                "on c.id = o.customer_id " +
                "where " +
                "o.id like '%" + txtSearch.Text + "%'" +
                "or o.price like '%" + txtSearch.Text + "%'" +
                "or FORMAT(o.created_at, 'hh:mm tt - dd/MM/yyyy') like '%" + txtSearch.Text + "%'" +
                "or o.employee_id like '%" + txtSearch.Text + "%'" +
                "or o.customer_id like '%" + txtSearch.Text + "%'" +
                "or e.name like '%" + txtSearch.Text + "%'" +
                "or c.name like '%" + txtSearch.Text + "%'" +
                "or c.phone like '%" + txtSearch.Text + "%'";

            DataTable search = db.GetDataToTable(qr);

            dgvOrder.DataSource = search;

            resetTxt();

            setTxt();

            // Change button state
            if (dgvOrder.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnAdd, btnDelete, btnEdit, btnSave });
            }

            control.enabledBtns(new[] { btnUndo });
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail();
            frmOrderDetail.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void lblSearch_MouseMove(object sender, MouseEventArgs e)
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
