using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.DAL;
using WeifenLuo.WinFormsUI.Docking;

namespace QuanLyKhachSan
{
   
    public partial class TimerAndProgrespass : DockContent
    {
        private string username;
        public TimerAndProgrespass()
        {
            InitializeComponent();
            if (PROGRESS.Enabled == true)
            {
                PROGRESS.Enabled = false;

                timer1.Start();
            }
            else
            {
                PROGRESS.Enabled = true;

                timer1.Stop();
            }
        }

        public string Username { get => username; set => username = value; }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Account loginAccount = AccountDAL.Instance.GetAccountByUserName(Username);
            //fTableManager frm = new fTableManager(loginAccount);
            PROGRESS.Increment(1);
            label1.Text = "Loading " + PROGRESS.Value.ToString() + "%";
            if (PROGRESS.Value == PROGRESS.Maximum)
            {
                timer1.Enabled = false;
                this.Hide();
                //frm.ShowDialog();
                SelectmultipleForm smf = new SelectmultipleForm();
                smf.Username = username;
                smf.ShowDialog();
            }


        }

        private void TimerAndProgrespass_Load(object sender, EventArgs e)
        {

        }
    }
}
