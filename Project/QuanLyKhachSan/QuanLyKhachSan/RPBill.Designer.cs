
namespace QuanLyKhachSan
{
    partial class RPBill
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
            this.USP_GetListBillByDateOfRPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ReportBill = new QuanLyKhachSan.ReportBill();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.USP_GetListBillByDateOfRPTableAdapter = new QuanLyKhachSan.ReportBillTableAdapters.USP_GetListBillByDateOfRPTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateOfRPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBill)).BeginInit();
            this.SuspendLayout();
            // 
            // USP_GetListBillByDateOfRPBindingSource
            // 
            this.USP_GetListBillByDateOfRPBindingSource.DataMember = "USP_GetListBillByDateOfRP";
            this.USP_GetListBillByDateOfRPBindingSource.DataSource = this.ReportBill;
            // 
            // ReportBill
            // 
            this.ReportBill.DataSetName = "ReportBill";
            this.ReportBill.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSetReportBill";
            reportDataSource1.Value = this.USP_GetListBillByDateOfRPBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyKhachSan.ReportBill.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
            // USP_GetListBillByDateOfRPTableAdapter
            // 
            this.USP_GetListBillByDateOfRPTableAdapter.ClearBeforeFill = true;
            // 
            // RPBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "RPBill";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RPBill";
            this.Load += new System.EventHandler(this.RPBill_Load);
            ((System.ComponentModel.ISupportInitialize)(this.USP_GetListBillByDateOfRPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReportBill)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource USP_GetListBillByDateOfRPBindingSource;
        private ReportBill ReportBill;
        private ReportBillTableAdapters.USP_GetListBillByDateOfRPTableAdapter USP_GetListBillByDateOfRPTableAdapter;
    }
}