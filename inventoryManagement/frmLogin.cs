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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            txtPass.PasswordChar = '*';
        }

        public static string userId
        {
            get;
            set;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            // Connect to db
            db.Connect();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Trim().Length == 0 ||
                txtPass.Text.Trim().Length == 0)
            {
                noti.info("Bạn chưa nhập đầy đủ thông tin");
                return;
            }

            string sql =
                "select id " +
                "from employees " +
                "where phone = '" + 
                txtPhone.Text + 
                "' and password = '"+ 
                txtPass.Text +"'";

            var rs = db.ReadScalar(sql);

            if (rs != DBNull.Value)
            {
                userId = rs.ToString();
                frmMain main = new frmMain();
                main.ShowDialog();
                this.Close();
            }
            else
            {
                noti.info("Tài khoản hoặc mật khẩu không chính xác");
                return;
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}
