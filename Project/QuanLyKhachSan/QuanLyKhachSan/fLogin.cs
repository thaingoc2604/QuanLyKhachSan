using GUI;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
namespace QuanLyKhachSan
{
    public partial class fLogin : DockContent
    {
        public fLogin()
        {
            InitializeComponent();
            var a = new WriteLog();
            a.FormWrite("Mở Form Main");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
           
            string userName = txtUserName.Text;
            string Password = txtPassWord.Text;
            if (Login(userName, Password))
            {
                var a = new WriteLog();
                a.ButtonWrite($"Đã đăng nhập hệ thống!!!");
                // fTableManager f = new fTableManager(loginAccount);
                TimerAndProgrespass t = new TimerAndProgrespass();
                this.Hide();
                t.Username = txtUserName.Text;

                // có 2 cách để truyền tài khoản này qua bên kia 
                // cách 1: lấy tài khoản ngay bên này luôn
                ///cách 2 qua bên kia lấy, bên đây chúng ta chỉ lấy id thôi
                t.ShowDialog();
               // this.Show();
            }
            else
            {
                MessageBox.Show("sai tai khoản hoặc mật khẩu");
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
                Application.Exit();
            else
            {
                fLogin f = new fLogin();
                f.ShowDialog();
            }
        }

        bool Login (string UserName, string Password)
        {
            return AccountDAL.Instance.Login(UserName,Password);
        }

        private void fLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Control == true && e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
            if (e.Control == true && e.KeyCode == Keys.Escape)
            {
                btnExit.PerformClick();
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            this.lblTime.Text = datetime.ToString();
        }

        private void fLogin_Load(object sender, EventArgs e)
        {
           
            timer1.Start();
            statusStripOne.BackColor = Color.LightBlue;
        }

        private void txtUserName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Bạn nhập tên đăng nhập là: " + txtUserName.Text;
        }

        private void txtUserName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtPassWord_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Nhấn vào đây để nhập Password!";
        }

        private void btnLogin_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click or Enter to Login";
        }

        private void btnLogin_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click or Esc to Exit";
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                    btnLogin.BackColor = cd.Color;
                        
            }
        }

        private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                    btnLogin.ForeColor = cd.Color;
            }
        }
    }
}
