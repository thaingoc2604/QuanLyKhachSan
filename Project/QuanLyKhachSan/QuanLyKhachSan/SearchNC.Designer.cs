
namespace QuanLyKhachSan
{
    partial class SearchNC
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
            this.cboOrAnd = new System.Windows.Forms.ComboBox();
            this.cboField = new System.Windows.Forms.ComboBox();
            this.cboOperrator = new System.Windows.Forms.ComboBox();
            this.cboInput = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnThemDieuKien = new System.Windows.Forms.Button();
            this.dtgvQuerydieukien = new System.Windows.Forms.DataGridView();
            this.bntTimKiem = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuerydieukien)).BeginInit();
            this.SuspendLayout();
            // 
            // cboOrAnd
            // 
            this.cboOrAnd.FormattingEnabled = true;
            this.cboOrAnd.Items.AddRange(new object[] {
            "",
            "OR",
            "AND"});
            this.cboOrAnd.Location = new System.Drawing.Point(72, 323);
            this.cboOrAnd.Name = "cboOrAnd";
            this.cboOrAnd.Size = new System.Drawing.Size(70, 21);
            this.cboOrAnd.TabIndex = 0;
            // 
            // cboField
            // 
            this.cboField.FormattingEnabled = true;
            this.cboField.Items.AddRange(new object[] {
            "names",
            "prices"});
            this.cboField.Location = new System.Drawing.Point(169, 323);
            this.cboField.Name = "cboField";
            this.cboField.Size = new System.Drawing.Size(83, 21);
            this.cboField.TabIndex = 1;
            // 
            // cboOperrator
            // 
            this.cboOperrator.FormattingEnabled = true;
            this.cboOperrator.Items.AddRange(new object[] {
            "Equal",
            "Containt",
            "Not containt"});
            this.cboOperrator.Location = new System.Drawing.Point(279, 323);
            this.cboOperrator.Name = "cboOperrator";
            this.cboOperrator.Size = new System.Drawing.Size(121, 21);
            this.cboOperrator.TabIndex = 2;
            // 
            // cboInput
            // 
            this.cboInput.FormattingEnabled = true;
            this.cboInput.Location = new System.Drawing.Point(432, 324);
            this.cboInput.Name = "cboInput";
            this.cboInput.Size = new System.Drawing.Size(219, 21);
            this.cboInput.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(433, 290);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "nhập từ khóa cần tìm";
            // 
            // btnThemDieuKien
            // 
            this.btnThemDieuKien.Location = new System.Drawing.Point(679, 323);
            this.btnThemDieuKien.Name = "btnThemDieuKien";
            this.btnThemDieuKien.Size = new System.Drawing.Size(100, 21);
            this.btnThemDieuKien.TabIndex = 5;
            this.btnThemDieuKien.Text = "thêm điều kiện";
            this.btnThemDieuKien.UseVisualStyleBackColor = true;
            this.btnThemDieuKien.Click += new System.EventHandler(this.btnThemDieuKien_Click);
            // 
            // dtgvQuerydieukien
            // 
            this.dtgvQuerydieukien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvQuerydieukien.Location = new System.Drawing.Point(64, 25);
            this.dtgvQuerydieukien.Name = "dtgvQuerydieukien";
            this.dtgvQuerydieukien.Size = new System.Drawing.Size(626, 184);
            this.dtgvQuerydieukien.TabIndex = 6;
            // 
            // bntTimKiem
            // 
            this.bntTimKiem.Location = new System.Drawing.Point(291, 372);
            this.bntTimKiem.Name = "bntTimKiem";
            this.bntTimKiem.Size = new System.Drawing.Size(180, 48);
            this.bntTimKiem.TabIndex = 7;
            this.bntTimKiem.Text = "Tìm Kiếm";
            this.bntTimKiem.UseVisualStyleBackColor = true;
            this.bntTimKiem.Click += new System.EventHandler(this.bntTimKiem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "toán tử so sánh";
            // 
            // SearchNC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bntTimKiem);
            this.Controls.Add(this.dtgvQuerydieukien);
            this.Controls.Add(this.btnThemDieuKien);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboInput);
            this.Controls.Add(this.cboOperrator);
            this.Controls.Add(this.cboField);
            this.Controls.Add(this.cboOrAnd);
            this.Name = "SearchNC";
            this.Text = "SearchNC";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvQuerydieukien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboOrAnd;
        private System.Windows.Forms.ComboBox cboField;
        private System.Windows.Forms.ComboBox cboOperrator;
        private System.Windows.Forms.ComboBox cboInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThemDieuKien;
        private System.Windows.Forms.DataGridView dtgvQuerydieukien;
        private System.Windows.Forms.Button bntTimKiem;
        private System.Windows.Forms.Label label2;
    }
}