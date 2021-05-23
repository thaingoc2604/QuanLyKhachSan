
namespace QuanLyKhachSan
{
    partial class fTableManager
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngtintaikhoang = new System.Windows.Forms.ToolStripMenuItem();
            this.thôngTinCáNhânToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chứcNăngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thanhToánToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmMónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupAndRestoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lsvBill = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaoLuu = new System.Windows.Forms.Button();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.cbSwitchRoom = new System.Windows.Forms.ComboBox();
            this.btnSwitchRoom = new System.Windows.Forms.Button();
            this.nmDisCount = new System.Windows.Forms.NumericUpDown();
            this.btnGiamGia = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.nmRoomCount = new System.Windows.Forms.NumericUpDown();
            this.btnAddServiceRoom = new System.Windows.Forms.Button();
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.cboCategory = new System.Windows.Forms.ComboBox();
            this.flpTable = new System.Windows.Forms.FlowLayoutPanel();
            this.statusStripOne = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelOne = new System.Windows.Forms.ToolStripStatusLabel();
            this.colorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.foregroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmRoomCount)).BeginInit();
            this.statusStripOne.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adminToolStripMenuItem,
            this.thôngtintaikhoang,
            this.chứcNăngToolStripMenuItem,
            this.colorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(436, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.adminToolStripMenuItem_Click);
            // 
            // thôngtintaikhoang
            // 
            this.thôngtintaikhoang.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thôngTinCáNhânToolStripMenuItem,
            this.đăngXuấtToolStripMenuItem});
            this.thôngtintaikhoang.Name = "thôngtintaikhoang";
            this.thôngtintaikhoang.Size = new System.Drawing.Size(126, 20);
            this.thôngtintaikhoang.Text = "Thông Tin Tài Khoản";
            // 
            // thôngTinCáNhânToolStripMenuItem
            // 
            this.thôngTinCáNhânToolStripMenuItem.Name = "thôngTinCáNhânToolStripMenuItem";
            this.thôngTinCáNhânToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.thôngTinCáNhânToolStripMenuItem.Text = "Thông Tin Cá Nhân";
            this.thôngTinCáNhânToolStripMenuItem.Click += new System.EventHandler(this.thôngTinCáNhânToolStripMenuItem_Click);
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            this.đăngXuấtToolStripMenuItem.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // chứcNăngToolStripMenuItem
            // 
            this.chứcNăngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thanhToánToolStripMenuItem,
            this.thêmMónToolStripMenuItem,
            this.backupAndRestoreToolStripMenuItem});
            this.chứcNăngToolStripMenuItem.Name = "chứcNăngToolStripMenuItem";
            this.chứcNăngToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.chứcNăngToolStripMenuItem.Text = "Chức Năng";
            // 
            // thanhToánToolStripMenuItem
            // 
            this.thanhToánToolStripMenuItem.Name = "thanhToánToolStripMenuItem";
            this.thanhToánToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.thanhToánToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.thanhToánToolStripMenuItem.Text = "Thanh Toán";
            this.thanhToánToolStripMenuItem.Click += new System.EventHandler(this.thanhToánToolStripMenuItem_Click);
            // 
            // thêmMónToolStripMenuItem
            // 
            this.thêmMónToolStripMenuItem.Name = "thêmMónToolStripMenuItem";
            this.thêmMónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this.thêmMónToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.thêmMónToolStripMenuItem.Text = "Thêm Món";
            this.thêmMónToolStripMenuItem.Click += new System.EventHandler(this.thêmMónToolStripMenuItem_Click);
            // 
            // backupAndRestoreToolStripMenuItem
            // 
            this.backupAndRestoreToolStripMenuItem.Name = "backupAndRestoreToolStripMenuItem";
            this.backupAndRestoreToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.backupAndRestoreToolStripMenuItem.Text = "Backup and Restore";
            this.backupAndRestoreToolStripMenuItem.Click += new System.EventHandler(this.backupAndRestoreToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.lsvBill);
            this.panel2.Location = new System.Drawing.Point(372, 95);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 249);
            this.panel2.TabIndex = 2;
            // 
            // lsvBill
            // 
            this.lsvBill.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvBill.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvBill.GridLines = true;
            this.lsvBill.HideSelection = false;
            this.lsvBill.Location = new System.Drawing.Point(3, 18);
            this.lsvBill.Name = "lsvBill";
            this.lsvBill.Size = new System.Drawing.Size(413, 228);
            this.lsvBill.TabIndex = 0;
            this.lsvBill.UseCompatibleStateImageBehavior = false;
            this.lsvBill.View = System.Windows.Forms.View.Details;
            this.lsvBill.SelectedIndexChanged += new System.EventHandler(this.lsvBill_SelectedIndexChanged);
            this.lsvBill.MouseLeave += new System.EventHandler(this.lsvBill_MouseLeave);
            this.lsvBill.MouseHover += new System.EventHandler(this.lsvBill_MouseHover);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Tên Món";
            this.columnHeader1.Width = 160;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Số lượng";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Đơn Giá";
            this.columnHeader3.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Thành Tiền";
            this.columnHeader4.Width = 98;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel3.Controls.Add(this.btnSaoLuu);
            this.panel3.Controls.Add(this.txtTotalPrice);
            this.panel3.Controls.Add(this.cbSwitchRoom);
            this.panel3.Controls.Add(this.btnSwitchRoom);
            this.panel3.Controls.Add(this.nmDisCount);
            this.panel3.Controls.Add(this.btnGiamGia);
            this.panel3.Controls.Add(this.btnThanhToan);
            this.panel3.Location = new System.Drawing.Point(372, 357);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(417, 79);
            this.panel3.TabIndex = 3;
            // 
            // btnSaoLuu
            // 
            this.btnSaoLuu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaoLuu.Image = global::QuanLyKhachSan.Properties.Resources.save16;
            this.btnSaoLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaoLuu.Location = new System.Drawing.Point(202, 43);
            this.btnSaoLuu.Name = "btnSaoLuu";
            this.btnSaoLuu.Size = new System.Drawing.Size(75, 23);
            this.btnSaoLuu.TabIndex = 8;
            this.btnSaoLuu.Text = "  Sao lưu";
            this.btnSaoLuu.UseVisualStyleBackColor = true;
            this.btnSaoLuu.Click += new System.EventHandler(this.btnSaoLuu_Click);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalPrice.ForeColor = System.Drawing.Color.Red;
            this.txtTotalPrice.Location = new System.Drawing.Point(202, 14);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(50, 25);
            this.txtTotalPrice.TabIndex = 7;
            this.txtTotalPrice.Text = "0";
            this.txtTotalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbSwitchRoom
            // 
            this.cbSwitchRoom.FormattingEnabled = true;
            this.cbSwitchRoom.Location = new System.Drawing.Point(12, 45);
            this.cbSwitchRoom.Name = "cbSwitchRoom";
            this.cbSwitchRoom.Size = new System.Drawing.Size(90, 21);
            this.cbSwitchRoom.TabIndex = 4;
            // 
            // btnSwitchRoom
            // 
            this.btnSwitchRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSwitchRoom.Image = global::QuanLyKhachSan.Properties.Resources.Options;
            this.btnSwitchRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSwitchRoom.Location = new System.Drawing.Point(3, 15);
            this.btnSwitchRoom.Name = "btnSwitchRoom";
            this.btnSwitchRoom.Size = new System.Drawing.Size(112, 24);
            this.btnSwitchRoom.TabIndex = 6;
            this.btnSwitchRoom.Text = "Chuyển Phòng";
            this.btnSwitchRoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSwitchRoom.UseVisualStyleBackColor = true;
            this.btnSwitchRoom.Click += new System.EventHandler(this.btnSwitchRoom_Click);
            this.btnSwitchRoom.MouseLeave += new System.EventHandler(this.btnSwitchRoom_MouseLeave);
            this.btnSwitchRoom.MouseHover += new System.EventHandler(this.btnSwitchRoom_MouseHover);
            // 
            // nmDisCount
            // 
            this.nmDisCount.Location = new System.Drawing.Point(121, 46);
            this.nmDisCount.Name = "nmDisCount";
            this.nmDisCount.Size = new System.Drawing.Size(75, 20);
            this.nmDisCount.TabIndex = 4;
            this.nmDisCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nmDisCount.ValueChanged += new System.EventHandler(this.nmDisCount_ValueChanged);
            // 
            // btnGiamGia
            // 
            this.btnGiamGia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGiamGia.Location = new System.Drawing.Point(121, 15);
            this.btnGiamGia.Name = "btnGiamGia";
            this.btnGiamGia.Size = new System.Drawing.Size(75, 24);
            this.btnGiamGia.TabIndex = 5;
            this.btnGiamGia.Text = "Giảm Giá";
            this.btnGiamGia.UseVisualStyleBackColor = true;
            this.btnGiamGia.Click += new System.EventHandler(this.btnGiamGia_Click);
            this.btnGiamGia.MouseLeave += new System.EventHandler(this.btnGiamGia_MouseLeave);
            this.btnGiamGia.MouseHover += new System.EventHandler(this.btnGiamGia_MouseHover);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.ForeColor = System.Drawing.Color.Yellow;
            this.btnThanhToan.Image = global::QuanLyKhachSan.Properties.Resources.vault;
            this.btnThanhToan.Location = new System.Drawing.Point(295, 2);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(119, 70);
            this.btnThanhToan.TabIndex = 4;
            this.btnThanhToan.Text = "Thanh Toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.btnThanhToan.MouseLeave += new System.EventHandler(this.btnThanhToan_MouseLeave);
            this.btnThanhToan.MouseHover += new System.EventHandler(this.btnThanhToan_MouseHover);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.panel4.Controls.Add(this.btnAddRoom);
            this.panel4.Controls.Add(this.nmRoomCount);
            this.panel4.Controls.Add(this.btnAddServiceRoom);
            this.panel4.Controls.Add(this.cboRoom);
            this.panel4.Controls.Add(this.cboCategory);
            this.panel4.Location = new System.Drawing.Point(375, 29);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(412, 60);
            this.panel4.TabIndex = 4;
            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRoom.Image = global::QuanLyKhachSan.Properties.Resources.add16;
            this.btnAddRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddRoom.Location = new System.Drawing.Point(199, 5);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(75, 48);
            this.btnAddRoom.TabIndex = 6;
            this.btnAddRoom.Text = "Thêm Phòng";
            this.btnAddRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click_1);
            this.btnAddRoom.MouseLeave += new System.EventHandler(this.btnAddRoom_MouseLeave);
            this.btnAddRoom.MouseHover += new System.EventHandler(this.btnAddRoom_MouseHover);
            // 
            // nmRoomCount
            // 
            this.nmRoomCount.Location = new System.Drawing.Point(362, 20);
            this.nmRoomCount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.nmRoomCount.Name = "nmRoomCount";
            this.nmRoomCount.Size = new System.Drawing.Size(39, 20);
            this.nmRoomCount.TabIndex = 3;
            this.nmRoomCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnAddServiceRoom
            // 
            this.btnAddServiceRoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddServiceRoom.Image = global::QuanLyKhachSan.Properties.Resources.add16;
            this.btnAddServiceRoom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddServiceRoom.Location = new System.Drawing.Point(280, 5);
            this.btnAddServiceRoom.Name = "btnAddServiceRoom";
            this.btnAddServiceRoom.Size = new System.Drawing.Size(75, 48);
            this.btnAddServiceRoom.TabIndex = 2;
            this.btnAddServiceRoom.Text = "  Thêm DV Phòng";
            this.btnAddServiceRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddServiceRoom.UseVisualStyleBackColor = true;
            this.btnAddServiceRoom.Click += new System.EventHandler(this.btnAddRoom_Click);
            this.btnAddServiceRoom.MouseLeave += new System.EventHandler(this.btnAddServiceRoom_MouseLeave);
            this.btnAddServiceRoom.MouseHover += new System.EventHandler(this.btnAddServiceRoom_MouseHover);
            // 
            // cboRoom
            // 
            this.cboRoom.FormattingEnabled = true;
            this.cboRoom.Location = new System.Drawing.Point(9, 32);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(178, 21);
            this.cboRoom.TabIndex = 1;
            this.cboRoom.MouseLeave += new System.EventHandler(this.cboRoom_MouseLeave);
            this.cboRoom.MouseHover += new System.EventHandler(this.cboRoom_MouseHover);
            // 
            // cboCategory
            // 
            this.cboCategory.FormattingEnabled = true;
            this.cboCategory.Location = new System.Drawing.Point(9, 5);
            this.cboCategory.Name = "cboCategory";
            this.cboCategory.Size = new System.Drawing.Size(178, 21);
            this.cboCategory.TabIndex = 0;
            this.cboCategory.SelectedIndexChanged += new System.EventHandler(this.cboCategory_SelectedIndexChanged);
            this.cboCategory.MouseLeave += new System.EventHandler(this.cboCategory_MouseLeave);
            this.cboCategory.MouseHover += new System.EventHandler(this.cboCategory_MouseHover);
            // 
            // flpTable
            // 
            this.flpTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpTable.AutoScroll = true;
            this.flpTable.Location = new System.Drawing.Point(13, 28);
            this.flpTable.Name = "flpTable";
            this.flpTable.Size = new System.Drawing.Size(353, 400);
            this.flpTable.TabIndex = 5;
            this.flpTable.MouseLeave += new System.EventHandler(this.flpTable_MouseLeave);
            this.flpTable.MouseHover += new System.EventHandler(this.flpTable_MouseHover);
            // 
            // statusStripOne
            // 
            this.statusStripOne.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelOne});
            this.statusStripOne.Location = new System.Drawing.Point(0, 439);
            this.statusStripOne.Name = "statusStripOne";
            this.statusStripOne.Size = new System.Drawing.Size(825, 22);
            this.statusStripOne.TabIndex = 6;
            this.statusStripOne.Text = "statusStrip1";
            // 
            // toolStripStatusLabelOne
            // 
            this.toolStripStatusLabelOne.Name = "toolStripStatusLabelOne";
            this.toolStripStatusLabelOne.Size = new System.Drawing.Size(0, 17);
            // 
            // colorToolStripMenuItem
            // 
            this.colorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backgroundToolStripMenuItem,
            this.foregroundToolStripMenuItem});
            this.colorToolStripMenuItem.Name = "colorToolStripMenuItem";
            this.colorToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.colorToolStripMenuItem.Text = "Color";
            this.colorToolStripMenuItem.Click += new System.EventHandler(this.colorToolStripMenuItem_Click);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.backgroundToolStripMenuItem.Text = "background";
            this.backgroundToolStripMenuItem.Click += new System.EventHandler(this.backgroundToolStripMenuItem_Click);
            // 
            // foregroundToolStripMenuItem
            // 
            this.foregroundToolStripMenuItem.Name = "foregroundToolStripMenuItem";
            this.foregroundToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.foregroundToolStripMenuItem.Text = "Foreground";
            this.foregroundToolStripMenuItem.Click += new System.EventHandler(this.foregroundToolStripMenuItem_Click);
            // 
            // fTableManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cyan;
            this.ClientSize = new System.Drawing.Size(825, 461);
            this.Controls.Add(this.statusStripOne);
            this.Controls.Add(this.flpTable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(841, 476);
            this.Name = "fTableManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần Mềm Quản Lý Khách Sạn";
            this.Load += new System.EventHandler(this.fTableManager_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmDisCount)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nmRoomCount)).EndInit();
            this.statusStripOne.ResumeLayout(false);
            this.statusStripOne.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôngtintaikhoang;
        private System.Windows.Forms.ToolStripMenuItem thôngTinCáNhânToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cbSwitchRoom;
        private System.Windows.Forms.Button btnSwitchRoom;
        private System.Windows.Forms.NumericUpDown nmDisCount;
        private System.Windows.Forms.Button btnGiamGia;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nmRoomCount;
        private System.Windows.Forms.Button btnAddServiceRoom;
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.ComboBox cboCategory;
        private System.Windows.Forms.FlowLayoutPanel flpTable;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.ToolStripMenuItem chứcNăngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thanhToánToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmMónToolStripMenuItem;
        private System.Windows.Forms.Button btnSaoLuu;
        private System.Windows.Forms.ToolStripMenuItem backupAndRestoreToolStripMenuItem;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.ListView lsvBill;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.StatusStrip statusStripOne;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelOne;
        private System.Windows.Forms.ToolStripMenuItem colorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem foregroundToolStripMenuItem;
    }
}