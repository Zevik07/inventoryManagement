using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using inventoryManagement.Core;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;

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
            // Default buttons's state
            control.disabledBtns(new[] { btnUndo, btnSave });

            LoadDataGridView();

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

        private bool validateTxt()
        {
            if (cbCustomerId.Text.Trim().Length == 0 ||
                cbEmployeeId.Text.Trim().Length == 0 ||
                txtEmployeeName.Text.Trim().Length == 0 ||
                txtCustomerName.Text.Trim().Length == 0)
            {
                notify.showNoti("Thông tin khách hoặc nhân viên không hợp lệ");
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
                "e.name as employee_name, " +
                "c.name as customer_name, " +
                "c.address as customer_address, " +
                "c.phone as customer_phone, " +
                "SUM(od.quantity*od.price_unit*(1-od.discount/100)) as price " +
                "from orders o " +
                "inner join " +
                "order_details od " +
                "on o.id = od.order_id " +
                "inner join " +
                "employees e on " +
                "e.id = o.employee_id " +
                "inner join customers c " +
                "on c.id = o.customer_id " +
                "group by " +
                "o.id, " +
                "o.employee_id, " +
                "o.customer_id, " +
                "created_at, " +
                "e.name, " +
                "c.name, " +
                "c.address, " +
                "c.phone";

            OrderData = db.GetDataToTable(sql);
            dgvOrder.DataSource = OrderData;

            // Load textbox
            setTxt();

            control.enabledBtns(new[] { btnAdd, btnSearch });
            control.disabledBtns(new[] { btnUndo, btnSave });

            // Change button state
            if (dgvOrder.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit,
                    btnDetail, btnPrint });
            }
            else
            {
                control.enabledBtns(new[] { btnDelete, btnEdit,
                    btnDetail, btnPrint });
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
            string sql = "";

            switch (preMethod)
            {
                case "add":
                    {
                        if (!validateTxt())
                        {
                            cbEmployeeId.Focus();
                            return;
                        }

                        sql =
                            "insert into orders " +
                            "(id, created_at, employee_id, customer_id) " +
                            "values('" +
                            txtOrderId.Text + "', '" +
                            dtpOrderDate.Value + "', '" +
                            cbEmployeeId.Text + "', '" +
                            cbCustomerId.Text + 
                            "')";
                    }
                    break;
                case "edit":
                    {
                        if (!validateTxt())
                        {
                            cbEmployeeId.Focus();
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

            if(db.Write(sql))
            {
                setControlReadMode();

                LoadDataGridView();

                // If in search mode, search again after save
                if (btnSearchIsClicked)
                {
                    btnSearchIsClicked = false;
                    btnSearch_Click(this, new EventArgs());
                }
            }
            else
            {
                cbCustomerId.Focus();
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            preMethod = "edit";

            setCbCustomerId();

            setCbEmployeeId();

            setControlReadMode(false);

            cbEmployeeId.Focus();

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

            if (dgvOrder.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit, 
                    btnDetail, btnPrint });
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
                   "ĐIỀU NÀY SẼ XÓA MỌI CHI TIẾT HÓA ĐƠN", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (rs == DialogResult.Yes)
            {
                string sql = 
                    "DELETE orders WHERE id = '" + txtOrderId.Text + "'";

                db.Write(sql);

                LoadDataGridView();

                // If in search mode, search again after delete
                if (btnSearchIsClicked)
                {
                    btnSearchIsClicked = false;
                    btnSearch_Click(this, new EventArgs());
                }
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
                "e.name as employee_name, " +
                "c.name as customer_name, " +
                "c.address as customer_address, " +
                "c.phone as customer_phone, " +
                "SUM(od.quantity*od.price_unit*(1-od.discount/100)) as price " +
                "from orders o " +
                "inner join " +
                "order_details od " +
                "on o.id = od.order_id " +
                "inner join " +
                "employees e on " +
                "e.id = o.employee_id " +
                "inner join customers c " +
                "on c.id = o.customer_id " +
                "where " +
                "o.id like '%" + txtSearch.Text + "%'" +
                "or o.price like '%" + txtSearch.Text + "%'" +
                "or FORMAT(o.created_at, 'hh:mm tt - dd/MM/yyyy') like '%" + txtSearch.Text + "%'" +
                "or o.employee_id like '%" + txtSearch.Text + "%'" +
                "or o.customer_id like '%" + txtSearch.Text + "%'" +
                "or e.name like N'%" + txtSearch.Text + "%'" +
                "or c.name like N'%" + txtSearch.Text + "%'" +
                "or c.phone like '%" + txtSearch.Text + "%'" +
                "group by o.id, o.employee_id, o.customer_id, " +
                "created_at, e.name, c.name, c.address, c.phone";

            DataTable search = db.GetDataToTable(qr);

            dgvOrder.DataSource = search;

            resetTxt();

            setTxt();

            control.disabledBtns(new[] { btnAdd });
            control.enabledBtns(new[] { btnUndo });

            if (dgvOrder.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit, 
                    btnPrint, btnDetail });
            }
            else
            {
                control.enabledBtns(new[] { btnEdit, btnDelete, 
                    btnDetail, btnPrint });
            }
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
            frmOrderDetail frmOrderDetail = 
                new frmOrderDetail(Int32.Parse(txtOrderId.Text));
            frmOrderDetail.ShowDialog();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // Get current row
            DataGridViewRow cRow = dgvOrder.CurrentRow;

            // Create a document object
            Document doc = new Document(PageSize.A6, 10, 10, 10, 10);

            // Directory to store
            string path = Environment.CurrentDirectory + "/Bills";

            // Create dir if it is not exists
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            // File name
            string fileName =
                    DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") +
                    "_" +
                    "HD" +
                    cRow.Cells["id"].Value.ToString() +
                    ".pdf";

            // Get a PDFWriter object 
            PdfWriter writer = PdfWriter.GetInstance(doc, 
                new FileStream(path + "/"+ fileName, FileMode.Create, FileAccess.Write, FileShare.Read));

            // Meta data
            doc.AddAuthor("Nguyen Huu Thien Phu");
            doc.AddCreator("Inventory Management");
            doc.AddKeywords("Bill PDF");
            doc.AddSubject("Document subject - Describing the steps creating a PDF document");
            doc.AddTitle("The document title - PDF creation using iTextSharp");

            // Open the document for writting
            doc.Open();

            // Default font format
            string fontFile = 
                Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.Fonts),
                    "arial.TTF");
            BaseFont bf = 
                BaseFont.CreateFont(fontFile, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            Font titleFont = 
                new Font(bf, 11, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            Font textFont =
                new Font(bf, 9, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
            Font noteFont =
                new Font(bf, 8, iTextSharp.text.Font.ITALIC, BaseColor.BLACK);

            // Header
            string dateEx =
               DateTime.Now.ToString("hh:mm tt - dd/MM/yyyy").ToString();
            string dateOrder = 
               cRow.Cells["created_at"].Value.ToString();

            Paragraph shopName = 
                new Paragraph("Quản lý bán hàng", textFont);
            doc.Add(shopName);

            Chunk glue = new Chunk(new VerticalPositionMark());
            Paragraph phoneRow = new Paragraph("Điện thoại: ", noteFont);
            phoneRow.Add((new Chunk(glue)));
            phoneRow.Add("Ngày xuất: " + dateEx);
            doc.Add(phoneRow);

            Paragraph addressRow = new Paragraph("Địa chỉ: ", noteFont);
            addressRow.Add((new Chunk(glue)));
            addressRow.Add("Ngày đặt: " + dateOrder);
            doc.Add(addressRow);

            var title = new Paragraph("HÓA ĐƠN", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            doc.Add(title);

            // Info
            Paragraph emRow = new Paragraph("Nhân viên bán: ", textFont);
            emRow.Add((new Chunk(glue)));
            emRow.Add("Mã nhân viên: " + cRow.Cells["employee_id"].Value.ToString());
            doc.Add(emRow);

            Paragraph cusRow = new Paragraph("Khách hàng: ", textFont);
            cusRow.Add((new Chunk(glue)));
            cusRow.Add("Điện thoại: " + cRow.Cells["customer_phone"].Value.ToString());
            doc.Add(cusRow);

            Paragraph customerAddrRow = 
                new Paragraph(
                    "Địa chỉ: " + cRow.Cells["customer_address"].Value.ToString(), 
                    textFont);
            doc.Add(customerAddrRow);

            // Details
            string sql;

            sql =
                "select " +
                "od.id, " +
                "od.good_id, " +
                "od.quantity, " +
                "od.price_unit, " +
                "od.discount, " +
                "g.name as good_name, " +
                "sum(quantity*price_unit*(1-discount/100)) as price_total " +
                "from order_details od " +
                "left join goods g " +
                "on g.id = od.good_id " +
                "where order_id = '" + getCell("order_id") + "'";

            DataTable odData = db.GetDataToTable(sql);
            odData.Columns.Add("STT");
            odData.Columns.Add("Mã hàng");
            odData.Columns.Add("Tên hàng");
            odData.Columns.Add("Số lượng");
            odData.Columns.Add("Đơn giá");
            odData.Columns.Add("Giảm (%)");
            odData.Columns.Add("Thành tiền");

            /*dt.Rows.Add(new object[] { "James Bond, LLC", 120, "Garrison Neely", "123 3428749020", 35, "6.000", "$24,590", "$13,432",
            "$12,659", "12/13/21", "1/30/27", 55, "ILS", "R"});

            ds.Tables.Add(dt);*/
            // Created at
            Paragraph time = new Paragraph();








            // Close the document
            doc.Close();
            writer.Close();
        }

        private string getCell(string name)
        {
            DataGridViewRow cRow = dgvOrder.CurrentRow;
            return cRow != null ? cRow.Cells[name].Value.ToString() : null;
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

        private void cbEmployeeId_TextChanged(object sender, EventArgs e)
        {
            // Load good info 
            string sql =
                "select " +
                "e.name " +
                "from employees e " +
                "where e.id = '" +
                cbEmployeeId.Text + "'";

            SqlDataReader emData = db.Read(sql);

            if (emData.HasRows)
            {
                if (emData.Read())
                {
                    txtEmployeeName.Text = emData["name"].ToString();
                }
            }
            else
            {
                txtEmployeeName.Text = "";
            }

            emData.Close();
        }

        private void cbCustomerId_TextChanged(object sender, EventArgs e)
        {
            // Load good info 
            string sql =
                "select " +
                "c.name, " +
                "c.address, " +
                "c.phone " +
                "from customers c " +
                "where c.id = '" +
                cbCustomerId.Text + "'";

            SqlDataReader customerData = db.Read(sql);

            if (customerData.HasRows)
            {
                if (customerData.Read())
                {
                    txtCustomerName.Text = customerData["name"].ToString();
                    txtCustomerAddress.Text = customerData["address"].ToString();
                    txtCustomerPhone.Text = customerData["phone"].ToString();
                }
            }
            else
            {
                txtCustomerName.Text = "";
                txtCustomerAddress.Text = "";
                txtCustomerPhone.Text = "";
            }

            customerData.Close();
        }
    }
}
