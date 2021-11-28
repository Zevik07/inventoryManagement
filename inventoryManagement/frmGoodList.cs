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
using System.IO;

namespace inventoryManagement
{
    public partial class frmGoodList : Form
    {
        private string preMethod;
        private DataTable goodData;
        private string imgPath = @"Images\Good\";
        private bool btnSearchIsClicked = false;
        public frmGoodList()
        {
            InitializeComponent();  
        }

        private void frmGoodList_Load(object sender, EventArgs e)
        {
            LoadDataGridView();

            // Default textbox's state
            setControlReadMode();
        }

        private void resetTxt()
        {
            txtId.Text = "";
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
                numQty.Enabled = false;
                txtPriceIn.ReadOnly = true;
                txtPriceOut.ReadOnly = true;
                txtNote.ReadOnly = true;
                btnOpenImg.Enabled = false;
                cbCategory.Enabled = false;
            }
            else
            {
                txtName.ReadOnly = false;
                numQty.Enabled = true;
                txtPriceIn.ReadOnly = false;
                txtPriceOut.ReadOnly = false;
                txtNote.ReadOnly = false;
                btnOpenImg.Enabled = true;
                cbCategory.Enabled = true;
            }
        }

        private void setTxt()
        {
            DataGridViewRow cRow = dgvGood.CurrentRow;

            if (cRow == null)
                return;
            
            if (btnAdd.Enabled && btnAdd.Enabled) // In add, edit mode
                txtId.Text =
                        cRow.Cells[0].Value.ToString();

            txtName.Text = cRow.Cells[1].Value.ToString();

            setCateCb();

            numQty.Value = Int32.Parse(cRow.Cells[3].Value.ToString());

            txtPriceIn.Text = cRow.Cells[4].Value.ToString();

            txtPriceOut.Text = cRow.Cells[5].Value.ToString();

            pbImg.ImageLocation =
                imgPath + cRow.Cells[6].Value.ToString();

            txtNote.Text = cRow.Cells[7].Value.ToString() ;
        }

        private void setCateCb()
        {
            string qr = "select id, name from categories";
            DataTable cbData = db.GetDataToTable(qr);
   
            cbCategory.ValueMember = "id";
            cbCategory.DisplayMember = "name";
            cbCategory.DataSource = cbData;

            // If current row is selected
            DataGridViewRow cRow = dgvGood.CurrentRow;

            if (cRow != null)
            {
                string txtName =
                    cRow.Cells[2].Value.ToString();

                int index = cbCategory.FindString(txtName);

                cbCategory.SelectedIndex = index;
            }
        }

        private void generateId()
        {
            // Increase Id
            string cellId = "0";

            if (dgvGood.CurrentRow != null)
            {
                cellId =
                    dgvGood.Rows[dgvGood.RowCount - 1]
                    .Cells[0].Value.ToString();
            }

            txtId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();
        }

        private bool validateTxt()
        {
            if (txtName.Text.Trim().Length == 0 ||
                txtPriceIn.Text.Trim().Length == 0 ||
                txtPriceOut.Text.Trim().Length == 0)
            {
                noti.info("Vui lòng nhập đầy đủ tên, giá nhập và giá bán");
                return false;
            }

            if (cbCategory.SelectedItem == null)
            {
                noti.info("Vui lòng chọn ngành hàng");
                return false;
            }
            
            if (numQty.Value < 1)
            {
                noti.info("Số lượng phải lớn hơn 1");
                return false;
            }    

            return true;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql =
                "select " +
                "d.id, " +
                "d.name, " +
                "c.name as category_name, " +
                "quantity, " +
                "price_in, " +
                "price_out, " +
                "image_url, " +
                "note " +
                "from goods d " +
                "inner join categories c " +
                "ON d.category_id = c.id; ";

            goodData = db.GetDataToTable(sql);
            dgvGood.DataSource = goodData;

            // Load textbox
            setTxt();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnAdd, btnSearch });

            // Change button state
            if (dgvGood.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }
            else
            {
                control.enabledBtns(new[] { btnDelete, btnEdit });
            } 
        }

        private void dgvGood_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (dgvGood.Rows.Count == 0)
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

            generateId();

            setCateCb();

            setControlReadMode(false);

            txtName.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit, 
                btnDelete, btnSearch });
            control.enabledBtns(new[] { btnUndo, btnSave });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;

            string ImgName = "";

            // if there are a upload picture in picturebox
            if (File.Exists(pbImg.ImageLocation))
            {
                DataGridViewRow cRow = dgvGood.CurrentRow;

                string oldImgName = "";

                // if in edit mode
                if (cRow != null && 
                    cRow.Cells[0].Value.ToString() == txtId.Text)
                {
                    oldImgName = Path.GetFileName(cRow.Cells[6].Value.ToString());
                }

                // Image url
                string newImg = pbImg.ImageLocation;

                // New name
                string newImgName =
                    DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") +
                    "_" +
                    Guid.NewGuid().ToString("n").Substring(0, 8) +
                    Path.GetExtension(newImg);

                // Create dir if it is not exists
                if (!Directory.Exists(imgPath))
                    Directory.CreateDirectory(imgPath);

                // Copy img to dir
                File.Copy(newImg, Path.Combine(imgPath, newImgName));

                ImgName = newImgName;

                // Get old img file = path + img name
                string oldImgFile =
                    imgPath + oldImgName;

                // Delete previous img
                if (File.Exists(oldImgFile))
                {
                    File.Delete(oldImgFile);
                }
            }

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
                            "goods" +
                            "(id, name, category_id, quantity," +
                            "price_in, price_out, image_url, note) " +
                            "VALUES(N'" +
                            txtId.Text.ToString() + "',N'" +
                            txtName.Text.ToString() + "',N'" +
                            cbCategory.SelectedValue + "',N'" +
                            numQty.Value + "','" +
                            txtPriceIn.Text + "','" +
                            txtPriceOut.Text + "','" +
                            ImgName + "',N'" +
                            txtNote.Text +
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

                        sql = "UPDATE goods SET"
                            + " name = N'" + txtName.Text.ToString()
                            + "', category_id = '" + cbCategory.SelectedValue
                            + "', quantity = '" + numQty.Value
                            + "', price_in = '" + txtPriceIn.Text
                            + "', price_out = '" + txtPriceOut.Text
                            + "', image_url = '" + ImgName
                            + "', note = '" + txtNote.Text
                            + "' WHERE id = '" + txtId.Text + "'";
                    }
                    break;
                default:
                    sql = "";
                    break;
            }

            if (db.Write(sql))
            {
                setControlReadMode();

                LoadDataGridView();

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

            if (dgvGood.Rows.Count == 0)
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
                string sql = 
                    "DELETE goods WHERE id='" + txtId.Text + "'";

                string currentImgName =
                    dgvGood.CurrentRow.Cells[6].Value.ToString();

                // Get current img = path + img name
                string currentImg =
                    imgPath + currentImgName;

                // Delete current img
                if (File.Exists(currentImg))
                {
                    File.Delete(currentImg);
                }

                db.Write(sql);

                LoadDataGridView();
            }
        }

        private void btnOpenImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlgOpen = new OpenFileDialog();
            dlgOpen.Filter = 
                "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
            dlgOpen.FilterIndex = 2;

            dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                pbImg.ImageLocation = dlgOpen.FileName;
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
                "select d.id, d.name, c.name as category_name, " +
                "quantity, price_in, price_out, image_url, note " +
                "from goods d " +
                "inner join categories c " +
                "ON d.category_id = c.id " +
                "where " +
                "d.name like N'%" + txtSearch.Text + "%'" +
                "or d.id like '%" + txtSearch.Text +"%'" +
                "or d.price_in like '%" + txtSearch.Text + "%'" +
                "or d.price_out like '%" + txtSearch.Text + "%'" +
                "or note like N'%" + txtSearch.Text + "%'" +
                "or c.name like N'%" + txtSearch.Text + "%'";

            DataTable search = db.GetDataToTable(qr);

            dgvGood.DataSource = search;

            resetTxt();

            setTxt();

            control.enabledBtns(new[] { btnUndo });
            control.disabledBtns(new[] { btnAdd });

            // Change button state
            if (dgvGood.Rows.Count == 0)
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
               "- Mã sản phẩm \n" +
               "- Tên sản phẩm \n" +
               "- Giá nhập \n" +
               "- Giá bán \n" +
               "- Ghi chú \n" +
               "- Tên ngành \n";

            toolTip1.SetToolTip(lblSearch, msg);
        }
    }
}
