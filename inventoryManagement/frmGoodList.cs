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
using System.IO;

namespace inventoryManagement
{
    public partial class frmGoodList : Form
    {
        private string preMethod;
        private DataTable goodData;

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

            txtId.Text =
                    cRow.Cells[0].Value.ToString();
            txtName.Text = 
                    cRow.Cells[1].Value.ToString();

            setCateCb();

            numQty.Value = Int32.Parse(cRow.Cells[3].Value.ToString());

            txtPriceIn.Text = cRow.Cells[4].Value.ToString();

            txtPriceOut.Text = cRow.Cells[5].Value.ToString();

            pbImg.ImageLocation =
                @"Images\Good\" + cRow.Cells[6].Value.ToString();

            txtNote.Text = cRow.Cells[7].Value.ToString();
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
            string txtName =
                    cRow.Cells[2].Value.ToString();

            if (cRow != null)
            {
                int index = cbCategory.FindString(txtName);
                cbCategory.SelectedIndex = index;
            }
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
                "quantity, price_out, price_in, image_url, note " +
                "from goods d " +
                "inner join categories c " +
                "ON d.id = c.id; ";

            goodData = db.GetDataToTable(sql);
            dgvGood.DataSource = goodData;

            // Load textbox
            setTxt();

            // Change button state
            if (dgvGood.Rows.Count == 0)
            {
                control.disabledBtns(new[] { btnDelete, btnEdit });
            }

            disabledDgv();
        }

        private void dgvGood_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (btnAdd.Enabled == false)
            {
                notify.showNoti("Bạn đang ở trạng thái thêm hoặc sửa, nhấn quay lại");
                dgvGood.Focus();
                return;
            }

            if (dgvGood.Rows.Count == 0)
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

            // Increase Id
            string cellId =
                    dgvGood.Rows[dgvGood.RowCount - 1].Cells[0].Value.ToString();
            txtId.Text = (Int16.Parse(cellId) + 1)
                        .ToString();

            txtName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string sql;

            // Image with url
            string imgFile = pbImg.ImageLocation;

            // New name
            string fileName =
                DateTime.Now.ToString("yyyy-MM-dd_HH_mm_ss") +
                Path.GetFileName("@C:/Images" + imgFile);

            notify.showNoti(imgFile);
            /*// Dir contain img
            string directory = "Assets/Images";

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            File.Copy(url, Path.Combine(directory, fileName));*/

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
                            "(name, category_id, quantity, price_in, price_out, image_url, note) " +
                            "VALUES(N'" +
                            txtName.Text.ToString() + "',N'" +
                            cbCategory.SelectedValue + "',N'" +
                            numQty.Value + "','" +
                            txtPriceIn.Text + "','" +
                            txtPriceOut.Text + "','" +
                            pbImg.ImageLocation.ToString() + "',N'" +
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
                            + "', image_url = '" + pbImg.ImageLocation
                            + "', note = '" + txtNote.ToString()
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
                   MessageBox.Show("Bạn có chắc muốn xoá không?", "Xác nhận",
                   MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
            {
                string sql = "DELETE goods WHERE id='" + txtId.Text + "'";
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
                pbImg.Image = Image.FromFile(dlgOpen.FileName);
                //otify.showNoti(Path.GetFileNameWithoutExtension(dlgOpen.FileName));
            }
        }
    }
}
