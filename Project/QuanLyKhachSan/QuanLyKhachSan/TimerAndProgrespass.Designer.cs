
namespace QuanLyKhachSan
{
    partial class TimerAndProgrespass
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.PROGRESS = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.iconButtonFB = new FontAwesome.Sharp.IconButton();
            this.iconButtonDT = new FontAwesome.Sharp.IconButton();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // PROGRESS
            // 
            this.PROGRESS.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.PROGRESS.Location = new System.Drawing.Point(55, 146);
            this.PROGRESS.Name = "PROGRESS";
            this.PROGRESS.Size = new System.Drawing.Size(393, 22);
            this.PROGRESS.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Loading";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(111, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(273, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Phần Mềm Quản Lý Khách Sạn";
            // 
            // iconButtonFB
            // 
            this.iconButtonFB.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconButtonFB.AutoSize = true;
            this.iconButtonFB.IconChar = FontAwesome.Sharp.IconChar.Facebook;
            this.iconButtonFB.IconColor = System.Drawing.Color.Black;
            this.iconButtonFB.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonFB.IconSize = 15;
            this.iconButtonFB.Location = new System.Drawing.Point(55, 71);
            this.iconButtonFB.MaximumSize = new System.Drawing.Size(24, 20);
            this.iconButtonFB.MinimumSize = new System.Drawing.Size(24, 20);
            this.iconButtonFB.Name = "iconButtonFB";
            this.iconButtonFB.Size = new System.Drawing.Size(24, 20);
            this.iconButtonFB.TabIndex = 3;
            this.iconButtonFB.UseVisualStyleBackColor = true;
            // 
            // iconButtonDT
            // 
            this.iconButtonDT.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.iconButtonDT.AutoSize = true;
            this.iconButtonDT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.iconButtonDT.IconChar = FontAwesome.Sharp.IconChar.Phone;
            this.iconButtonDT.IconColor = System.Drawing.Color.Black;
            this.iconButtonDT.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButtonDT.IconSize = 15;
            this.iconButtonDT.Location = new System.Drawing.Point(55, 99);
            this.iconButtonDT.MaximumSize = new System.Drawing.Size(24, 20);
            this.iconButtonDT.MinimumSize = new System.Drawing.Size(24, 20);
            this.iconButtonDT.Name = "iconButtonDT";
            this.iconButtonDT.Size = new System.Drawing.Size(24, 20);
            this.iconButtonDT.TabIndex = 4;
            this.iconButtonDT.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Red;
            this.textBox2.Location = new System.Drawing.Point(3, 12);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(184, 16);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Khách Sạn Phương Thái Ngọc";
            // 
            // textBox3
            // 
            this.textBox3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox3.Location = new System.Drawing.Point(85, 73);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(363, 13);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "https://www.facebook.com/profile.php?id=100007064411278";
            // 
            // textBox4
            // 
            this.textBox4.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(96, 107);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(185, 13);
            this.textBox4.TabIndex = 7;
            this.textBox4.Text = "0925321437";
            // 
            // TimerAndProgrespass
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 245);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.iconButtonDT);
            this.Controls.Add(this.iconButtonFB);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PROGRESS);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(505, 284);
            this.Name = "TimerAndProgrespass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TimerAndProgrespass";
            this.Load += new System.EventHandler(this.TimerAndProgrespass_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar PROGRESS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconButton iconButtonFB;
        private FontAwesome.Sharp.IconButton iconButtonDT;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
    }
}