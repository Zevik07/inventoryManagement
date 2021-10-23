
namespace inventoryManagement
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnuCate = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGood = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBills = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBIll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindBill = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindGood = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportRevenue = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCate,
            this.mnuBills,
            this.mnuSearch,
            this.mnuReport,
            this.toolStripMenuItem10,
            this.toolStripMenuItem7,
            this.toolStripMenuItem3,
            this.toolStripMenuItem1,
            this.mnuOther});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(29, 59);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(574, 48);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCate
            // 
            this.mnuCate.BackColor = System.Drawing.Color.White;
            this.mnuCate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuGood,
            this.mnuCategory,
            this.mnuCustomer,
            this.mnuEmployee});
            this.mnuCate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuCate.Image = global::inventoryManagement.Properties.Resources.Folders_OS_Documents_Metro_icon;
            this.mnuCate.Name = "mnuCate";
            this.mnuCate.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuCate.Size = new System.Drawing.Size(115, 42);
            this.mnuCate.Text = "Danh mục";
            // 
            // mnuGood
            // 
            this.mnuGood.Name = "mnuGood";
            this.mnuGood.Size = new System.Drawing.Size(180, 24);
            this.mnuGood.Text = "Hàng hóa";
            this.mnuGood.Click += new System.EventHandler(this.mnuGood_Click);
            // 
            // mnuCategory
            // 
            this.mnuCategory.Name = "mnuCategory";
            this.mnuCategory.Size = new System.Drawing.Size(180, 24);
            this.mnuCategory.Text = "Ngành hàng";
            this.mnuCategory.Click += new System.EventHandler(this.mnuCategory_Click);
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.Size = new System.Drawing.Size(180, 24);
            this.mnuCustomer.Text = "Khách hàng";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // mnuEmployee
            // 
            this.mnuEmployee.Name = "mnuEmployee";
            this.mnuEmployee.Size = new System.Drawing.Size(180, 24);
            this.mnuEmployee.Text = "Nhân viên";
            // 
            // mnuBills
            // 
            this.mnuBills.BackColor = System.Drawing.Color.White;
            this.mnuBills.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBIll});
            this.mnuBills.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBills.Image = global::inventoryManagement.Properties.Resources.news_icon;
            this.mnuBills.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuBills.Name = "mnuBills";
            this.mnuBills.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuBills.Size = new System.Drawing.Size(106, 42);
            this.mnuBills.Text = "Hóa đơn";
            // 
            // mnuBIll
            // 
            this.mnuBIll.Name = "mnuBIll";
            this.mnuBIll.Size = new System.Drawing.Size(165, 24);
            this.mnuBIll.Text = "Hóa đơn bán";
            // 
            // mnuSearch
            // 
            this.mnuSearch.BackColor = System.Drawing.Color.White;
            this.mnuSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindBill,
            this.mnuFindGood,
            this.mnuFindCustomer});
            this.mnuSearch.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuSearch.Image = global::inventoryManagement.Properties.Resources.search_icon;
            this.mnuSearch.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuSearch.Size = new System.Drawing.Size(109, 42);
            this.mnuSearch.Text = "Tìm kiếm";
            // 
            // mnuFindBill
            // 
            this.mnuFindBill.Name = "mnuFindBill";
            this.mnuFindBill.Size = new System.Drawing.Size(155, 24);
            this.mnuFindBill.Text = "Hóa đơn";
            // 
            // mnuFindGood
            // 
            this.mnuFindGood.Name = "mnuFindGood";
            this.mnuFindGood.Size = new System.Drawing.Size(155, 24);
            this.mnuFindGood.Text = "Hàng";
            // 
            // mnuFindCustomer
            // 
            this.mnuFindCustomer.Name = "mnuFindCustomer";
            this.mnuFindCustomer.Size = new System.Drawing.Size(155, 24);
            this.mnuFindCustomer.Text = "Khách hàng";
            // 
            // mnuReport
            // 
            this.mnuReport.BackColor = System.Drawing.Color.White;
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportInventory,
            this.mnuReportRevenue});
            this.mnuReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuReport.Image = global::inventoryManagement.Properties.Resources.statistics_icon;
            this.mnuReport.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuReport.Size = new System.Drawing.Size(102, 42);
            this.mnuReport.Text = "Báo cáo";
            // 
            // mnuReportInventory
            // 
            this.mnuReportInventory.Name = "mnuReportInventory";
            this.mnuReportInventory.Size = new System.Drawing.Size(147, 24);
            this.mnuReportInventory.Text = "Hàng tồn";
            // 
            // mnuReportRevenue
            // 
            this.mnuReportRevenue.Name = "mnuReportRevenue";
            this.mnuReportRevenue.Size = new System.Drawing.Size(147, 24);
            this.mnuReportRevenue.Text = "Doanh thu";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem10.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11});
            this.toolStripMenuItem10.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem10.Image = global::inventoryManagement.Properties.Resources.FAQ_icon;
            this.toolStripMenuItem10.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.toolStripMenuItem10.Size = new System.Drawing.Size(80, 42);
            this.toolStripMenuItem10.Text = "Khác";
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(216, 24);
            this.toolStripMenuItem11.Text = "Thông tin phần mềm";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem9});
            this.toolStripMenuItem7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem7.Image = global::inventoryManagement.Properties.Resources.statistics_icon;
            this.toolStripMenuItem7.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.toolStripMenuItem7.Size = new System.Drawing.Size(94, 42);
            this.toolStripMenuItem7.Text = "Báo cáo";
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem8.Text = "Hàng tồn";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(136, 22);
            this.toolStripMenuItem9.Text = "Doanh thu";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.toolStripMenuItem3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem3.Image = global::inventoryManagement.Properties.Resources.search_icon;
            this.toolStripMenuItem3.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.toolStripMenuItem3.Size = new System.Drawing.Size(99, 42);
            this.toolStripMenuItem3.Text = "Tìm kiếm";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem4.Text = "Hóa đơn";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem5.Text = "Hàng";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(144, 22);
            this.toolStripMenuItem6.Text = "Khách hàng";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Image = global::inventoryManagement.Properties.Resources.news_icon;
            this.toolStripMenuItem1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.toolStripMenuItem1.Size = new System.Drawing.Size(106, 42);
            this.toolStripMenuItem1.Text = "Hóa đơn";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(165, 24);
            this.toolStripMenuItem2.Text = "Hóa đơn bán";
            // 
            // mnuOther
            // 
            this.mnuOther.BackColor = System.Drawing.Color.White;
            this.mnuOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfo});
            this.mnuOther.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuOther.Image = global::inventoryManagement.Properties.Resources.FAQ_icon;
            this.mnuOther.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuOther.Name = "mnuOther";
            this.mnuOther.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuOther.Size = new System.Drawing.Size(75, 42);
            this.mnuOther.Text = "Khác";
            // 
            // mnuInfo
            // 
            this.mnuInfo.Name = "mnuInfo";
            this.mnuInfo.Size = new System.Drawing.Size(197, 22);
            this.mnuInfo.Text = "Thông tin phần mềm";
            // 
            // lblMainTitle
            // 
            this.lblMainTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblMainTitle.AutoSize = true;
            this.lblMainTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMainTitle.Location = new System.Drawing.Point(4, 27);
            this.lblMainTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(598, 33);
            this.lblMainTitle.TabIndex = 1;
            this.lblMainTitle.Text = "Quản lý kho hàng";
            this.lblMainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSubTitle.Location = new System.Drawing.Point(4, 120);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(598, 24);
            this.lblSubTitle.TabIndex = 2;
            this.lblSubTitle.Text = "Nguyễn Hữu Thiên Phú B1805805";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.lblSubTitle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMainTitle, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 166);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(606, 177);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::inventoryManagement.Properties.Resources.mainBackground;
            this.ClientSize = new System.Drawing.Size(630, 375);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý kho hàng";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCate;
        private System.Windows.Forms.ToolStripMenuItem mnuCategory;
        private System.Windows.Forms.ToolStripMenuItem mnuEmployee;
        private System.Windows.Forms.ToolStripMenuItem mnuCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuGood;
        private System.Windows.Forms.ToolStripMenuItem mnuBills;
        private System.Windows.Forms.ToolStripMenuItem mnuBIll;
        private System.Windows.Forms.ToolStripMenuItem mnuSearch;
        private System.Windows.Forms.ToolStripMenuItem mnuFindBill;
        private System.Windows.Forms.ToolStripMenuItem mnuFindGood;
        private System.Windows.Forms.ToolStripMenuItem mnuFindCustomer;
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuReportInventory;
        private System.Windows.Forms.ToolStripMenuItem mnuReportRevenue;
        private System.Windows.Forms.ToolStripMenuItem mnuOther;
        private System.Windows.Forms.ToolStripMenuItem mnuInfo;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}

