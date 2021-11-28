using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        // Data attribute
        private int orderId;
        private int currentOrderDetailId = 0;
        private DataTable oderDetailData;
        // For controls
        private string preMethod;
        private bool btnSearchIsClicked = false;

        public frmOrderDetail(int orderIdParam = 0)
        {
            InitializeComponent();

            orderId = orderIdParam;

            // Set title id
            lblTitle.Text = "Chi tiết đơn hàng mã: " + orderId;
        }

        private void frmOrderDetail_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            // Default textbox's state
            setControlReadMode();
        }

        private void resetTxt()
        {
            cbGoodId.Text = "";
            numQty.Value = 1;
            txtGoodName.Text = "";
            numDiscount.Value = 0;
            txtPriceUnit.Text = "";
            txtOrderPrice.Text = "";
            txtPriceTotal.Text = "";
        }
        private void setControlReadMode(bool yes = true)
        {
            if (yes)
            {
                cbGoodId.Enabled = false;
                numQty.ReadOnly = true;
                numDiscount.ReadOnly = true;
                numQty.Increment = 0;
                numDiscount.Increment = 0;
            }
            else
            {
                cbGoodId.Enabled = true;
                numQty.ReadOnly = false;
                numDiscount.ReadOnly = false;
                numQty.Increment = 1;
                numDiscount.Increment = 1;
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

            txtGoodName.Text =
                cRow.Cells["good_name"].Value.ToString();

            numQty.Value =
                Int32.Parse(cRow.Cells["quantity"].Value.ToString());

            txtPriceUnit.Text =
                 cRow.Cells["price_unit"].Value.ToString();

            numDiscount.Text =
                 cRow.Cells["discount"].Value.ToString();

            txtPriceTotal.Text =
                 cRow.Cells["price_total"].Value.ToString();

            currentOrderDetailId = 
                Int32.Parse(cRow.Cells["id"].Value.ToString());
        }

        private void setCbGoodId()
        {
            string qr = "select id from goods";

            DataTable cbData = db.GetDataToTable(qr);

            cbGoodId.DisplayMember = "id";
            cbGoodId.DataSource = cbData;

            // If current row is selected
            DataGridViewRow cRow = dgvOrderDetail.CurrentRow;

            if (cRow != null)
            {
                string idValue =
                    cRow.Cells["good_id"].Value.ToString();

                cbGoodId.Text = idValue;
            }
        }

        private string generateId()
        {
            // Increase Id
            string id = "0";

            // If dgv is not empty
            string sql =
                "SELECT TOP 1 id FROM order_details ORDER BY id DESC";

            var rs = db.ReadScalar(sql);

            if (rs != DBNull.Value)
            {
                id = rs.ToString();
            }

            return (Int16.Parse(id) + 1)
                        .ToString();
        }

        private void setPriceTotalOrder()
        {
            // Get in db
            string sql =
                "select sum(quantity*price_unit*(1-discount/100)) " +
                "from order_details od " +
                "where order_id = '"+ orderId +"'";

            var rs = db.ReadScalar(sql);

            if (rs != DBNull.Value)
            {
                Decimal price = Convert.ToDecimal(rs);
                txtOrderPrice.Text = price.ToString();
                lblOrderPrice.Text = 
                    control.NumberToText(Double.Parse(txtOrderPrice.Text));
            }
        }

        private bool validate()
        {
            if (cbGoodId.Text.Trim().Length == 0)
            {
                noti.info("Không được để trống mã nhân viên và mã khách");
                return false;
            }

            if (numQty.Value == 0)
            {
                noti.info("Số lượng phải lớn hơn 0");
                return false;
            }

            if (txtGoodName.Text.Trim().Length == 0 ||
                txtPriceUnit.Text.Trim().Length == 0)
            {
                noti.info("Hàng hóa không tồn tại");
                return false;
            }

            return true;
        }

        private void LoadDataGridView()
        {
            string sql;

            sql =
                "select " +
                "od.id, " +
                "od.order_id, " +
                "od.good_id, " +
                "od.quantity, " +
                "od.price_unit, " +
                "od.discount, " +
                "g.name as good_name, " +
                "od.quantity*od.price_unit*(1-od.discount/100) as price_total " +
                "from order_details od " +
                "left join goods g " +
                "on g.id = od.good_id " +
                "where order_id = '" + orderId + "'";

            oderDetailData = db.GetDataToTable(sql);

            dgvOrderDetail.DataSource = oderDetailData;

            // Load textbox
            setTxt();

            setPriceTotalOrder();

            control.enabledBtns(new[] { btnAdd, btnSearch });
            control.disabledBtns(new[] { btnUndo, btnSave });

            // Change button state
            if (dgvOrderDetail.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }
            else
            {
                control.enabledBtns(new[] { btnDelete, btnEdit });
            }
        }

        private void dgvOrderDetail_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrderDetail.Rows.Count == 0)
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

            setCbGoodId();

            setControlReadMode(false);

            cbGoodId.Focus();

            control.disabledBtns(new[] { btnAdd, btnDelete, 
                btnSearch, btnEdit });
            control.enabledBtns(new[] { btnUndo, btnSave });
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            preMethod = "edit";

            setCbGoodId();

            setControlReadMode(false);

            // Prevent update good_id, it can make trigger wrong
            cbGoodId.Enabled = false;

            cbGoodId.Focus();

            control.disabledBtns(new[] { btnAdd, btnDelete,
                btnSearch, btnEdit });
            control.enabledBtns(new[] { btnUndo, btnSave });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql = "";

            switch (preMethod)
            {
                case "add":
                    {
                        if (!validate())
                        {
                            return;
                        }

                        sql =
                            "insert into " +
                            "order_details " +
                            "values ('" +
                            generateId() + "', '" +
                            orderId + "', '" +
                            cbGoodId.Text + "', '" +
                            numQty.Value + "', '" +
                            txtPriceUnit.Text + "', '" +
                            numDiscount.Value + "'" +
                            ")";
                    }
                    break;
                case "edit":
                    {
                        if (!validate())
                        {
                            cbGoodId.Focus();
                            return;
                        }

                        sql = "UPDATE order_details SET"
                            + " good_id = '" 
                            + cbGoodId.Text
                            + "', quantity = '" 
                            + numQty.Value
                            + "', discount = '" 
                            + numDiscount.Value
                            + "' WHERE id = '" 
                            + currentOrderDetailId  + "'";
                    }
                    break;
                default:
                    break;
            }

            if (db.Write(sql))
            {
                setControlReadMode();

                LoadDataGridView();

                setPriceTotalOrder();

                // If in search mode, search again after save
                if (btnSearchIsClicked)
                {
                    btnSearchIsClicked = false;
                    btnSearch_Click(this, new EventArgs());
                }
            }
            else
            {
                numQty.Focus();
            }
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {
            setTxt();

            setControlReadMode();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, 
                btnEdit, btnSearch});

            if (dgvOrderDetail.Rows.Count == 0)
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
            string currentId =
                dgvOrderDetail.CurrentRow.Cells["id"].Value.ToString();

            string sql = 
                "DELETE order_details WHERE id='" + currentId + "'";

            db.Write(sql);

            LoadDataGridView();

            // If in search mode, search again after delete
            if (btnSearchIsClicked)
            {
                btnSearchIsClicked = false;
                btnSearch_Click(this, new EventArgs());
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

            string searchTxt = txtSearch.Text;

            string qr =
                "select " +
                "od.id, " +
                "od.order_id, " +
                "od.good_id, " +
                "od.quantity, " +
                "od.price_unit, " +
                "od.discount, " +
                "od.price_total, " +
                "g.name as good_name " +
                "quantity*price_unit*(1-discount/100) as price_total " +
                "from order_details od " +
                "inner join goods g " +
                "on g.id = od.good_id " +
                "where " +
                "g.id like N'%" + searchTxt + "%' " +
                "or g.name like N'%" + searchTxt + "%'";

            DataTable search = db.GetDataToTable(qr);

            dgvOrderDetail.DataSource = search;

            setTxt();

            control.enabledBtns(new[] { btnUndo });
            control.disabledBtns(new[] { btnAdd });

            // Change button state
            if (dgvOrderDetail.Rows.Count == 0)
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
                "- Mã hàng hóa \n" +
                "- Tên hàng hóa \n";

            toolTip1.SetToolTip(lblSearch, msg);
        }

        private void cbGoodId_TextChanged(object sender, EventArgs e)
        {
            // Load good info 
            string sql =
                "select " +
                "g.name, " +
                "g.price_out " +
                "from goods g " +
                "where g.id ='" +
                cbGoodId.Text + "'";

            SqlDataReader goodData = db.Read(sql);

            if (goodData.HasRows)
            {
                if (goodData.Read())
                {
                    txtGoodName.Text = goodData["name"].ToString();
                    txtPriceUnit.Text = goodData["price_out"].ToString();
                }
            }
            else
            {
                txtGoodName.Text = "";
                txtPriceUnit.Text = "";
            }

            goodData.Close();
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}
