﻿using System;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
        }

        private void mnuGood_Click(object sender, EventArgs e)
        {
            frmGoodList frmGoodList = new frmGoodList();
            frmGoodList.ShowDialog();
        }

        private void mnuCategory_Click(object sender, EventArgs e)
        {
            frmCategoryList frmCategoryList = new frmCategoryList();
            frmCategoryList.ShowDialog();
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            frmCustomerList frmCustomerList = new frmCustomerList();
            frmCustomerList.ShowDialog();
        }

        private void mnuEmployee_Click(object sender, EventArgs e)
        {
            frmEmployeeList frmEmployeeList = new frmEmployeeList();
            frmEmployeeList.ShowDialog();
        }

        private void mnuBIll_Click(object sender, EventArgs e)
        {
            frmOrderDetail frmOrderDetail = new frmOrderDetail();
            frmOrderDetail.ShowDialog();
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e)
        {
            noti.info("Phần mềm được viết bởi Nguyền Hữu Thiên Phú \n" +
                "Đại học cần thơ" +
                "github.com/zevik07");
        }

        private void mnuOrderList_Click(object sender, EventArgs e)
        {
            frmOrderList frmOrderList = new frmOrderList();
            frmOrderList.ShowDialog();
        }

        private void mnuReportRevenue_Click(object sender, EventArgs e)
        {
            frmReportSale frmReport = new frmReportSale();
            frmReport.ShowDialog();
        }
    }
}
