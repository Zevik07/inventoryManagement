
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
            this.mnuMaterial = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGood = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBills = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBIll = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindBill = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindGood = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFindCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportRevenue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOther = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMainTitle = new System.Windows.Forms.Label();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCate,
            this.mnuBills,
            this.mnuSearch,
            this.mnuReport,
            this.mnuOther});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(80, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(386, 45);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCate
            // 
            this.mnuCate.BackColor = System.Drawing.Color.White;
            this.mnuCate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMaterial,
            this.mnuEmployee,
            this.mnuCustomer,
            this.mnuGood});
            this.mnuCate.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuCate.Name = "mnuCate";
            this.mnuCate.Size = new System.Drawing.Size(78, 39);
            this.mnuCate.Text = "Danh mục";
            // 
            // mnuMaterial
            // 
            this.mnuMaterial.Name = "mnuMaterial";
            this.mnuMaterial.Size = new System.Drawing.Size(180, 22);
            this.mnuMaterial.Text = "Chất liệu";
            // 
            // mnuEmployee
            // 
            this.mnuEmployee.Name = "mnuEmployee";
            this.mnuEmployee.Size = new System.Drawing.Size(180, 22);
            this.mnuEmployee.Text = "Nhân viên";
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.Size = new System.Drawing.Size(180, 22);
            this.mnuCustomer.Text = "Khách hàng";
            // 
            // mnuGood
            // 
            this.mnuGood.Name = "mnuGood";
            this.mnuGood.Size = new System.Drawing.Size(180, 22);
            this.mnuGood.Text = "Hàng hóa";
            // 
            // mnuBills
            // 
            this.mnuBills.BackColor = System.Drawing.Color.White;
            this.mnuBills.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuBIll});
            this.mnuBills.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBills.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuBills.Name = "mnuBills";
            this.mnuBills.Size = new System.Drawing.Size(71, 39);
            this.mnuBills.Text = "Hóa đơn";
            // 
            // mnuBIll
            // 
            this.mnuBIll.Name = "mnuBIll";
            this.mnuBIll.Size = new System.Drawing.Size(180, 22);
            this.mnuBIll.Text = "Hóa đơn bán";
            // 
            // mnuSearch
            // 
            this.mnuSearch.BackColor = System.Drawing.Color.White;
            this.mnuSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFindBill,
            this.mnuFindGood,
            this.mnuFindCustomer});
            this.mnuSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuSearch.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuSearch.Name = "mnuSearch";
            this.mnuSearch.Size = new System.Drawing.Size(72, 39);
            this.mnuSearch.Text = "Tìm kiếm";
            // 
            // mnuFindBill
            // 
            this.mnuFindBill.Name = "mnuFindBill";
            this.mnuFindBill.Size = new System.Drawing.Size(180, 22);
            this.mnuFindBill.Text = "Hóa đơn";
            // 
            // mnuFindGood
            // 
            this.mnuFindGood.Name = "mnuFindGood";
            this.mnuFindGood.Size = new System.Drawing.Size(180, 22);
            this.mnuFindGood.Text = "Hàng";
            // 
            // mnuFindCustomer
            // 
            this.mnuFindCustomer.Name = "mnuFindCustomer";
            this.mnuFindCustomer.Size = new System.Drawing.Size(180, 22);
            this.mnuFindCustomer.Text = "Khách hàng";
            // 
            // mnuReport
            // 
            this.mnuReport.BackColor = System.Drawing.Color.White;
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportInventory,
            this.mnuReportRevenue});
            this.mnuReport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuReport.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Size = new System.Drawing.Size(67, 39);
            this.mnuReport.Text = "Báo cáo";
            // 
            // mnuReportInventory
            // 
            this.mnuReportInventory.Name = "mnuReportInventory";
            this.mnuReportInventory.Size = new System.Drawing.Size(180, 22);
            this.mnuReportInventory.Text = "Hàng tồn";
            // 
            // mnuReportRevenue
            // 
            this.mnuReportRevenue.Name = "mnuReportRevenue";
            this.mnuReportRevenue.Size = new System.Drawing.Size(180, 22);
            this.mnuReportRevenue.Text = "Doanh thu";
            // 
            // mnuOther
            // 
            this.mnuOther.BackColor = System.Drawing.Color.White;
            this.mnuOther.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInfo});
            this.mnuOther.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuOther.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuOther.Name = "mnuOther";
            this.mnuOther.Size = new System.Drawing.Size(48, 39);
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
            this.lblMainTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMainTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblMainTitle.Location = new System.Drawing.Point(4, 21);
            this.lblMainTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMainTitle.Name = "lblMainTitle";
            this.lblMainTitle.Size = new System.Drawing.Size(540, 37);
            this.lblMainTitle.TabIndex = 1;
            this.lblMainTitle.Text = "Quản lý kho hàng";
            this.lblMainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMainTitle.Click += new System.EventHandler(this.lblMainTitle_Click);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSubTitle.AutoSize = true;
            this.lblSubTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblSubTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSubTitle.Location = new System.Drawing.Point(4, 106);
            this.lblSubTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTitle.Name = "lblSubTitle";
            this.lblSubTitle.Size = new System.Drawing.Size(540, 24);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 133);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 158);
            this.tableLayoutPanel1.TabIndex = 3;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.00001F));
            this.tableLayoutPanel2.Controls.Add(this.menuStrip1, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(12, 44);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(548, 45);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::inventoryManagement.Properties.Resources.mainBackground;
            this.ClientSize = new System.Drawing.Size(572, 323);
            this.Controls.Add(this.tableLayoutPanel2);
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuCate;
        private System.Windows.Forms.ToolStripMenuItem mnuMaterial;
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
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

