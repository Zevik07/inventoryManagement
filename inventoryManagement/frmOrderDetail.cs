using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using inventoryManagement.Core;

namespace inventoryManagement
{
    public partial class frmOrderDetail : Form
    {
        private int orderId;
        private string preMethod;
        private DataTable oderDetailData;
        private bool btnSearchIsClicked = false;

        public frmOrderDetail(int orderIdParam = 1)
        {
            InitializeComponent();

            orderId = orderIdParam;

            // Set title id
            lblTitle.Text = "Chi tiết hóa đơn mã: " + orderId;
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            // Default buttons's state
            control.disabledBtns(new[] { btnUndo, btnSave });

            // Default textbox's state
            setControlReadMode();
        }

        private void resetTxt()
        {
            cbGoodId.Text = "";
            numQty.Value = 0;
            txtGoodName.Text = "";
            txtDiscount.Text = "";
            txtGoodPriceOut.Text = "";
            txtOrderPrice.Text = "";
            txtPriceTotal.Text = "";
        }
        private void setControlReadMode(bool yes = true)
        {
            if (yes)
            {
                cbGoodId.Enabled = false;
                numQty.Enabled = false;
                txtDiscount.Enabled = false;
            }
            else
            {
                cbGoodId.Enabled = false;
                numQty.Enabled = false;
                txtDiscount.Enabled = false;
            }
        }

        private void setTxt()
        {
            DataGridViewRow cRow = dgvOrderDetail.CurrentRow;

            if (cRow == null)
                return;

            if (btnAdd.Enabled && btnAdd.Enabled) // Without add, edit mode
                cbGoodId.Text =
                        cRow.Cells["good_id"].Value.ToString();

            numQty.Value =
                Int32.Parse(cRow.Cells["quantity"].Value.ToString());

            txtGoodPriceOut.Text =
                 cRow.Cells["good_price_out"].Value.ToString();

            txtGoodName.Text =
                cRow.Cells["good_name"].Value.ToString();

            txtDiscount.Text =
                 cRow.Cells["discount"].Value.ToString();

            txtPriceTotal.Text =
                 cRow.Cells["price_total"].Value.ToString();
        }

        private void setCbGoodId()
        {
            /*string qr = "select id from goods";

            DataTable cbData = db.GetDataToTable(qr);

            cbGoodId.DisplayMember = "id";
            cbGoodId.DataSource = cbData;

            // If current row is selected
            DataGridViewRow cRow = dgvOrderDetailDetail.CurrentRow;

            if (cRow != null)
            {
                string idValue =
                    cRow.Cells["good_id"].Value.ToString();

                cbGoodId.Text = idValue;
            }*/
        }

        private void generateId()
        {
           /* // Increase Id
            string cellId = "0";

            // If dgv is not empty
            if (dgvOrderDetail.CurrentRow != null)
            {
                cellId =
                    dgvOrderDetail.Rows[dgvOrderDetail.RowCount - 1]
                    .Cells["id"].Value.ToString();
            }

            txtOrderId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();*/
        }

        private void disabledDgv()
        {
        }

        private bool validateTxt()
        {
            /*if (cbCustomerId.Text.Trim().Length == 0 ||
                cbEmployeeId.Text.Trim().Length == 0)
            {
                notify.showNoti("Không được để trống mã nhân viên và mã khách");
                return false;
            }

            return true;*/
            return true;
        }

        private void LoadDataGridView()
        {
            /*string sql;
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
            dgvOrderDetail.DataSource = OrderData;

            // Load textbox
            setTxt();

            // Change button state
            if (dgvOrderDetail.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit, btnDetail, btnPrint });
            }*/
        }

        private void dgvOrderDetail_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           /* preMethod = "add";

            resetTxt();

            generateId();

            setCbCustomerId();

            setCbEmployeeId();

            setControlReadMode(false);

            cbEmployeeId.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit, btnDelete,
                btnSearch, btnDetail, btnPrint });

            control.enabledBtns(new[] { btnUndo, btnSave });*/
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           /* string sql;

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
            }*/
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            /*setTxt();

            setControlReadMode();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd,
                btnEdit, btnSearch, btnPrint, btnDetail });

            if (btnSearchIsClicked)
            {
                btnSearchIsClicked = false;
                LoadDataGridView();
            }*/
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
           /* DialogResult rs =
                   MessageBox.Show("Bạn có chắc muốn xoá không? \n" +
                   "ĐIỀU NÀY SẼ XÓA MỌI CHI TIẾT HÓA ĐƠN", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                string sql = "DELETE orders WHERE id='" + txtOrderId.Text + "'";

                string currentImgName =
                    dgvOrderDetail.CurrentRow.Cells[6].Value.ToString();

                db.Write(sql);

                LoadDataGridView();
            }*/
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            /*btnSearchIsClicked = true;

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

            dgvOrderDetail.DataSource = search;

            resetTxt();

            setTxt();

            // Change button state
            if (dgvOrderDetail.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnAdd, btnDelete, btnEdit, btnSave });
            }

            control.enabledBtns(new[] { btnUndo });*/
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
