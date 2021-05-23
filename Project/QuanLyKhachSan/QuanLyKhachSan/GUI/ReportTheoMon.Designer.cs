
namespace QuanLyKhachSan.GUI
{
    partial class ReportTheoMon
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ChonTheoMonAnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetChonMonAn = new QuanLyKhachSan.GUI.DataSetChonMonAn();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.cbtim = new System.Windows.Forms.ComboBox();
            this.btntim = new System.Windows.Forms.Button();
            this.ChonTheoMonAnTableAdapter = new QuanLyKhachSan.GUI.DataSetChonMonAnTableAdapters.ChonTheoMonAnTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ChonTheoMonAnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetChonMonAn)).BeginInit();
            this.SuspendLayout();
            // 
            // ChonTheoMonAnBindingSource
            // 
            this.ChonTheoMonAnBindingSource.DataMember = "ChonTheoMonAn";
            this.ChonTheoMonAnBindingSource.DataSource = this.DataSetChonMonAn;
            // 
            // DataSetChonMonAn
            // 
            this.DataSetChonMonAn.DataSetName = "DataSetChonMonAn";
            this.DataSetChonMonAn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.DocumentMapWidth = 30;
            reportDataSource1.Name = "ChonTheoMon";
            reportDataSource1.Value = this.ChonTheoMonAnBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan.GUI.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(27, 163);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(742, 240);
            this.reportViewer1.TabIndex = 0;
            // 
            // cbtim
            // 
            this.cbtim.FormattingEnabled = true;
            this.cbtim.Location = new System.Drawing.Point(267, 47);
            this.cbtim.Name = "cbtim";
            this.cbtim.Size = new System.Drawing.Size(121, 21);
            this.cbtim.TabIndex = 1;
            // 
            // btntim
            // 
            this.btntim.Location = new System.Drawing.Point(429, 47);
            this.btntim.Name = "btntim";
            this.btntim.Size = new System.Drawing.Size(75, 23);
            this.btntim.TabIndex = 2;
            this.btntim.Text = "Tìm";
            this.btntim.UseVisualStyleBackColor = true;
            this.btntim.Click += new System.EventHandler(this.btntim_Click);
            // 
            // ChonTheoMonAnTableAdapter
            // 
            this.ChonTheoMonAnTableAdapter.ClearBeforeFill = true;
            // 
            // ReportTheoMon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btntim);
            this.Controls.Add(this.cbtim);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReportTheoMon";
            this.Text = "ReportTheoMon";
            this.Load += new System.EventHandler(this.ReportTheoMon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ChonTheoMonAnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetChonMonAn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ChonTheoMonAnBindingSource;
        private DataSetChonMonAn DataSetChonMonAn;
        private System.Windows.Forms.ComboBox cbtim;
        private System.Windows.Forms.Button btntim;
        private DataSetChonMonAnTableAdapters.ChonTheoMonAnTableAdapter ChonTheoMonAnTableAdapter;
    }
}