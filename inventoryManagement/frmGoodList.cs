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

            // Default buttons's state
            control.disabledBtns(new[] { btnUndo, btnSave });

            // Default textbox's state
            setControlReadMode();
        }

        private void ResetTxt()
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

            txtName.Text = 
                cRow.Cells[1].Value.ToString();

            setCateCb();

            numQty.Value = Int32.Parse(cRow.Cells[3].Value.ToString());

            txtPriceIn.Text = cRow.Cells[4].Value.ToString();

            txtPriceOut.Text = cRow.Cells[5].Value.ToString();

            pbImg.ImageLocation =
                imgPath + cRow.Cells[6].Value.ToString();

            // Thực tế khỏi cần kiểm tra null, vì đổ vào bảng là không còn null nữa
            txtNote.Text = cRow.Cells[7].Value != null ?
                           cRow.Cells[7].Value.ToString() :
                           null;
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

        private void setTxtId()
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

        private void disabledDgv()
        {
            // Prevent edit row
            /*dgvGood.EditMode = DataGridViewEditMode.EditProgrammatically;*/
        }

        private bool validateTxt()
        {
            if (txtName.Text.Trim().Length == 0 ||
                txtPriceIn.Text.Trim().Length == 0 ||
                txtPriceOut.Text.Trim().Length == 0)
            {
                notify.showNoti("Vui lòng nhập đầy đủ tên, giá nhập và giá bán");
                return false;
            }

            if (cbCategory.SelectedItem == null)
            {
                notify.showNoti("Vui lòng chọn ngành hàng");
                return false;
            }
            
            if (numQty.Value < 1)
            {
                notify.showNoti("Số lượng phải lớn hơn 1");
                return false;
            }    

            return true;
        }

        private void LoadDataGridView()
        {
            string sql;
            sql =
                "select d.id, d.name, c.name as category_name, " +
                "quantity, price_in, price_out, image_url, note " +
                "from goods d " +
                "inner join categories c " +
                "ON d.category_id = c.id; ";

            goodData = db.GetDataToTable(sql);
            dgvGood.DataSource = goodData;

            // Load textbox
            setTxt();

            // Change button state
            if (dgvGood.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }
        }

        private void dgvGood_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            
            if (dgvGood.Rows.Count == 0)
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

            setCateCb();

            setControlReadMode(false);

            setTxtId();

            txtName.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit, btnDelete, btnSearch });
            control.enabledBtns(new[] { btnUndo, btnSave });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;

            string ImgName = "";

            // if if there are a upload picture in picturebox
            if (File.Exists(pbImg.ImageLocation))
            {
                DataGridViewRow cRow = dgvGood.CurrentRow;

                // exist current row and current row is selected row in edit mode
                if (cRow != null && cRow.Cells[0].Value.ToString() == txtId.Text)
                {
                    ImgName = Path.GetFileName(cRow.Cells[6].Value.ToString());
                }

                string oldImgName = ImgName;

                // Image url
                string newImg = pbImg.ImageLocation;

                // New name
                string newImgName =
                    DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") +
                    "_" +
                    control.convertToUnSign3(Path.GetFileName(newImg)); // bỏ dấu

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
                            return;
                        }

                        sql =
                            "INSERT INTO goods" +
                            "(id, name, category_id, quantity," +
                            " price_in, price_out, image_url, note) " +
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

            db.Write(sql);

            LoadDataGridView();

            setControlReadMode();

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, btnEdit, btnSearch });

            if (btnSearchIsClicked)
            {
                btnSearchIsClicked = false;
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            preMethod = "edit";

            setControlReadMode(false);

            txtName.Focus();

            control.disabledBtns(new[] { btnAdd, btnEdit, btnDelete, btnSearch });
            control.enabledBtns(new[] { btnUndo, btnSave });
        }

        private void btnUndo_Click(object sender, EventArgs e)
        {

            setTxt();

            setControlReadMode(false);

            control.disabledBtns(new[] { btnUndo, btnSave });
            control.enabledBtns(new[] { btnDelete, btnAdd, btnEdit, btnSearch });

            if (btnSearchIsClicked)
            {
                btnSearchIsClicked = false;
                LoadDataGridView();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult rs =
                   MessageBox.Show("Bạn có chắc muốn xoá không?", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "DELETE goods WHERE id='" + txtId.Text + "'";

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
            dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
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
                notify.showNoti("Vui lòng nhập nội dung tìm kiếm");
                return;
            }

            string qr = 
                "select d.id, d.name, c.name as category_name, " +
                "quantity, price_in, price_out, image_url, note " +
                "from goods d " +
                "inner join categories c " +
                "ON d.category_id = c.id " +
                "where d.name like '%" + txtSearch.Text + "%'" +
                "or d.quantity like '%" + txtSearch.Text +"%'" +
                "or d.price_in like '%" + txtSearch.Text + "%'" +
                "or d.price_out like '%" + txtSearch.Text + "%'" +
                "or note like '%" + txtSearch.Text + "%'" +
                "or c.name like '%" + txtSearch.Text + "%'";

            DataTable search = db.GetDataToTable(qr);

            dgvGood.DataSource = search;

            ResetTxt();

            setTxt();

            // Change button state
            if (dgvGood.Rows.Count == 0)
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
    }
}
