
namespace QuanLyKhachSan
{
    partial class BackupAndRestore
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBackup = new System.Windows.Forms.TextBox();
            this.btnBrowseLocationBK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRestore = new System.Windows.Forms.TextBox();
            this.btnBrowseLocationRS = new System.Windows.Forms.Button();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Location For Backup";
            // 
            // txtBackup
            // 
            this.txtBackup.Location = new System.Drawing.Point(35, 41);
            this.txtBackup.Name = "txtBackup";
            this.txtBackup.Size = new System.Drawing.Size(635, 20);
            this.txtBackup.TabIndex = 1;
            // 
            // btnBrowseLocationBK
            // 
            this.btnBrowseLocationBK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseLocationBK.BackColor = System.Drawing.Color.Cyan;
            this.btnBrowseLocationBK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseLocationBK.Location = new System.Drawing.Point(175, 67);
            this.btnBrowseLocationBK.MaximumSize = new System.Drawing.Size(155, 30);
            this.btnBrowseLocationBK.MinimumSize = new System.Drawing.Size(155, 30);
            this.btnBrowseLocationBK.Name = "btnBrowseLocationBK";
            this.btnBrowseLocationBK.Size = new System.Drawing.Size(155, 30);
            this.btnBrowseLocationBK.TabIndex = 2;
            this.btnBrowseLocationBK.Text = "Location Backup";
            this.btnBrowseLocationBK.UseVisualStyleBackColor = false;
            this.btnBrowseLocationBK.Click += new System.EventHandler(this.btnBrowseLocationBK_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(298, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Location Restore From Location Backup";
            // 
            // txtRestore
            // 
            this.txtRestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRestore.Location = new System.Drawing.Point(35, 171);
            this.txtRestore.Name = "txtRestore";
            this.txtRestore.Size = new System.Drawing.Size(635, 20);
            this.txtRestore.TabIndex = 5;
            // 
            // btnBrowseLocationRS
            // 
            this.btnBrowseLocationRS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseLocationRS.BackColor = System.Drawing.Color.Cyan;
            this.btnBrowseLocationRS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowseLocationRS.Location = new System.Drawing.Point(175, 195);
            this.btnBrowseLocationRS.MaximumSize = new System.Drawing.Size(155, 30);
            this.btnBrowseLocationRS.MinimumSize = new System.Drawing.Size(155, 30);
            this.btnBrowseLocationRS.Name = "btnBrowseLocationRS";
            this.btnBrowseLocationRS.Size = new System.Drawing.Size(155, 30);
            this.btnBrowseLocationRS.TabIndex = 6;
            this.btnBrowseLocationRS.Text = "Location Restore";
            this.btnBrowseLocationRS.UseVisualStyleBackColor = false;
            this.btnBrowseLocationRS.Click += new System.EventHandler(this.btnBrowseLocationRS_Click);
            // 
            // btnRestore
            // 
            this.btnRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRestore.BackColor = System.Drawing.Color.Cyan;
            this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.Image = global::QuanLyKhachSan.Properties.Resources.restore32;
            this.btnRestore.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRestore.Location = new System.Drawing.Point(336, 195);
            this.btnRestore.MaximumSize = new System.Drawing.Size(155, 30);
            this.btnRestore.MinimumSize = new System.Drawing.Size(155, 30);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(155, 30);
            this.btnRestore.TabIndex = 7;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBackup.BackColor = System.Drawing.Color.Cyan;
            this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.Black;
            this.btnBackup.Image = global::QuanLyKhachSan.Properties.Resources.backup32;
            this.btnBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBackup.Location = new System.Drawing.Point(336, 67);
            this.btnBackup.MaximumSize = new System.Drawing.Size(155, 30);
            this.btnBackup.MinimumSize = new System.Drawing.Size(155, 30);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(155, 30);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // BackupAndRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(689, 262);
            this.Controls.Add(this.btnRestore);
            this.Controls.Add(this.btnBrowseLocationRS);
            this.Controls.Add(this.txtRestore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.btnBrowseLocationBK);
            this.Controls.Add(this.txtBackup);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(705, 301);
            this.Name = "BackupAndRestore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BackupAndRestore";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBackup;
        private System.Windows.Forms.Button btnBrowseLocationBK;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRestore;
        private System.Windows.Forms.Button btnBrowseLocationRS;
        private System.Windows.Forms.Button btnRestore;
    }
}