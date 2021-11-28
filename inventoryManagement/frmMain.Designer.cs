
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
            this.mnuCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGood = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBills = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrderList = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportRevenue = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuReportInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
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
            this.mnuReport,
            this.toolStripMenuItem10});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(81, 66);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(460, 48);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuCate
            // 
            this.mnuCate.BackColor = System.Drawing.Color.White;
            this.mnuCate.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCategory,
            this.mnuGood,
            this.mnuCustomer,
            this.mnuEmployee});
            this.mnuCate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuCate.Image = global::inventoryManagement.Properties.Resources.Folders_OS_Documents_Metro_icon;
            this.mnuCate.Name = "mnuCate";
            this.mnuCate.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuCate.Size = new System.Drawing.Size(115, 42);
            this.mnuCate.Text = "Danh mục";
            // 
            // mnuCategory
            // 
            this.mnuCategory.Name = "mnuCategory";
            this.mnuCategory.Size = new System.Drawing.Size(159, 24);
            this.mnuCategory.Text = "Ngành hàng";
            this.mnuCategory.Click += new System.EventHandler(this.mnuCategory_Click);
            // 
            // mnuGood
            // 
            this.mnuGood.Name = "mnuGood";
            this.mnuGood.Size = new System.Drawing.Size(159, 24);
            this.mnuGood.Text = "Hàng hóa";
            this.mnuGood.Click += new System.EventHandler(this.mnuGood_Click);
            // 
            // mnuCustomer
            // 
            this.mnuCustomer.Name = "mnuCustomer";
            this.mnuCustomer.Size = new System.Drawing.Size(159, 24);
            this.mnuCustomer.Text = "Khách hàng";
            this.mnuCustomer.Click += new System.EventHandler(this.mnuCustomer_Click);
            // 
            // mnuEmployee
            // 
            this.mnuEmployee.Name = "mnuEmployee";
            this.mnuEmployee.Size = new System.Drawing.Size(159, 24);
            this.mnuEmployee.Text = "Nhân viên";
            this.mnuEmployee.Click += new System.EventHandler(this.mnuEmployee_Click);
            // 
            // mnuBills
            // 
            this.mnuBills.BackColor = System.Drawing.Color.White;
            this.mnuBills.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOrderList});
            this.mnuBills.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuBills.Image = global::inventoryManagement.Properties.Resources.news_icon;
            this.mnuBills.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuBills.Name = "mnuBills";
            this.mnuBills.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuBills.Size = new System.Drawing.Size(113, 42);
            this.mnuBills.Text = "Đơn hàng";
            // 
            // mnuOrderList
            // 
            this.mnuOrderList.Name = "mnuOrderList";
            this.mnuOrderList.Size = new System.Drawing.Size(128, 24);
            this.mnuOrderList.Text = "Quản lý";
            this.mnuOrderList.Click += new System.EventHandler(this.mnuOrderList_Click);
            // 
            // mnuReport
            // 
            this.mnuReport.BackColor = System.Drawing.Color.White;
            this.mnuReport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuReportRevenue,
            this.mnuReportInventory});
            this.mnuReport.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mnuReport.Image = global::inventoryManagement.Properties.Resources.statistics_icon;
            this.mnuReport.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.mnuReport.Name = "mnuReport";
            this.mnuReport.Padding = new System.Windows.Forms.Padding(10, 0, 5, 0);
            this.mnuReport.Size = new System.Drawing.Size(102, 42);
            this.mnuReport.Text = "Báo cáo";
            // 
            // mnuReportRevenue
            // 
            this.mnuReportRevenue.Name = "mnuReportRevenue";
            this.mnuReportRevenue.Size = new System.Drawing.Size(180, 24);
            this.mnuReportRevenue.Text = "Doanh thu";
            this.mnuReportRevenue.Click += new System.EventHandler(this.mnuReportRevenue_Click);
            // 
            // mnuReportInventory
            // 
            this.mnuReportInventory.Name = "mnuReportInventory";
            this.mnuReportInventory.Size = new System.Drawing.Size(180, 24);
            this.mnuReportInventory.Text = "Hàng tồn";
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
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItem11_Click);
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
        private System.Windows.Forms.ToolStripMenuItem mnuReport;
        private System.Windows.Forms.ToolStripMenuItem mnuReportInventory;
        private System.Windows.Forms.ToolStripMenuItem mnuReportRevenue;
        private System.Windows.Forms.Label lblMainTitle;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem mnuOrderList;
    }
}

