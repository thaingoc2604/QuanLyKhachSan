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

namespace QuanLyKhachSan
{
    public partial class fAccountProfile : Form
    {
        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(LoginAccount); }
        }

        public fAccountProfile(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(Account acc)
        {
            txtUserName.Text = LoginAccount.UserName;
            txtDisplayName.Text = loginAccount.DisplayName;
        }
        // hàm này được tạo ra để thêm khi nhấn nút cập nhật thì gọi tới nó
        void UpdateAccountInfo()
        {
            string displayName = txtDisplayName.Text;
            string password = txtPassWord.Text;
            string newpass = txtNewPass.Text;
            string reentePass = txtReEnterPass.Text;
            string userName = txtUserName.Text;

            if (!newpass.Equals(reentePass))//Equals có nghĩa là nó không có giống
            {
                MessageBox.Show("vui lòng nhập lại mật khẩu mới");
            }
            else
            {
                if (AccountDAL.Instance.UpdateAccount(userName, displayName, password, newpass))
                {
                    MessageBox.Show("Cập nhật thành công");
                    if (updateAccount != null)
                        updateAccount(this, new AccountEvent(AccountDAL.Instance.GetAccountByUserName(userName)));
                }
                else
                {
                    MessageBox.Show("vui lòng điền mật khẩu");
                }
            }
        }

        private event EventHandler<AccountEvent> updateAccount;
        public event EventHandler<AccountEvent>  UpdateAccount
        {
            add { updateAccount += value; }
            remove { updateAccount -= value; }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.Yes)
                Application.Exit();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string s = txtUserName.Text;
            string a = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s.ToLower());
            txtUserName.Text = a;

            string s1 = txtDisplayName.Text;
            string a1 = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s1.ToLower());
            txtDisplayName.Text = a1;

            string s2 = txtPassWord.Text;
            string a2 = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s2.ToLower());
            txtPassWord.Text = a2;

            string s3 = txtNewPass.Text;
            string a3 = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s3.ToLower());
            txtNewPass.Text = a3;

            string s4 = txtReEnterPass.Text;
            string a4 = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s4.ToLower());
            txtReEnterPass.Text = a4;
            //khi nhấn nút cập nhật thì sẽ gọi 1 hàm voi update
            UpdateAccountInfo();
        }

        private void fAccountProfile_Load(object sender, EventArgs e)
        {
            statusStripOne.BackColor = Color.LightBlue;
        }

        private void txtUserName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để nhập tên đăng nhập";
        }

        private void txtUserName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtDisplayName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để nhập tên hiển thị";
        }

        private void txtDisplayName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtPassWord_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để nhập mật khẩu";
        }

        private void txtPassWord_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtNewPass_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để nhập mật khẩu mới";
        }

        private void txtNewPass_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtReEnterPass_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để nhập lại mật khẩu";
        }

        private void txtReEnterPass_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnUpdate_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào button để cập nhật Account!";
        }

        private void btnUpdate_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnExit_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để thoát!";
        }

        private void btnExit_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }
    }
    public class AccountEvent:EventArgs
    {
        private Account acc;

        public Account Acc
        {
            get { return acc; }
            set { acc = value; }
        }
        public AccountEvent( Account acc)
        {
            this.Acc = acc;
        }
    }
}
