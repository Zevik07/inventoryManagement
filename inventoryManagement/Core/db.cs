using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace inventoryManagement.Core
{
    class db
    {
        public static SqlConnection Con;

        public static void Connect()
        {
            try
            {
                Con = new SqlConnection();

                // Su dung window authentication cho sql server
                Con.ConnectionString = "Server = ZEVIK-PC; Database = inventoryManagement; " +
                    "Trusted_Connection = True; ";

                Con.Open();

                if (Con.State == ConnectionState.Open)
                    MessageBox.Show("Kết nối thành công");
                else MessageBox.Show("Không thể kết nối với dữ liệu");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        public static void Disconnect()
        {
            if (Con.State == ConnectionState.Open)
            {
                Con.Close();
                Con.Dispose();
                Con = null;
            }
        }

        public static DataTable GetDataToTable(string sql)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con); 
            //Khai báo đối tượng table thuộc lớp DataTable
            DataTable table = new DataTable();
            // Đổ kết quả từ câu lệnh sql vào table
            dap.Fill(table);

            return table;
        }
    }
}
