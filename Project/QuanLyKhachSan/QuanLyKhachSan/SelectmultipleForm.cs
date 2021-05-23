using QuanLyKhachSan.DAL;
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.GUI;
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
    public partial class SelectmultipleForm : Form
    {
        private string username;
        public string Username { get => username; set => username = value; }
        public SelectmultipleForm()
        {
            InitializeComponent();
        }
        

        private void openFormMultiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Account loginAccount = AccountDAL.Instance.GetAccountByUserName(Username);
            fLogin fad = new fLogin();
            //fad.MdiParent = this;
            fad.Show(dockPanel, DockState.Document);
        }

      

        private void fTableManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "OpenOneForm")
                {
                    isOpen = true;
                    f.Focus();
                    break;
                }

            }
            if (isOpen == false)
            {
                IsMdiContainer = true;
                Account loginAccount = AccountDAL.Instance.GetAccountByUserName(Username);
                fTableManager fad = new fTableManager(loginAccount);
                fad.MdiParent = this;
                fad.Show(dockPanel, DockState.Document);






            }
        }
        fLogin flg;
        private void fLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if(flg == null)
            {
                fLogin flg = new fLogin();
                flg.MdiParent = this;
                flg.FormClosed += new FormClosedEventHandler(flg_FormClosed);
                flg.Show(dockPanel, DockState.Document);
            }
            else
            {
                flg.Activate();
            }
        }

        private void flg_FormClosed(object sender, FormClosedEventArgs e)
        {
            flg = null;
            //throw new NotImplementedException();
        }
        RPBill rp;
        private void rPBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rp == null)
            {
                RPBill rp = new RPBill();
                rp.MdiParent = this;
                rp.FormClosed += new FormClosedEventHandler(rp_FormClosed);
                rp.Show(dockPanel, DockState.Document);
            }
            else
            {
                flg.Activate();
            }
        }

        private void rp_FormClosed(object sender, FormClosedEventArgs e)
        {
            rp = null;  
            //throw new NotImplementedException();
        }
        fAdmin fadm;
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fadm == null)
            {
                fAdmin fadm = new fAdmin();
                fadm.MdiParent = this;
                fadm.FormClosed += new FormClosedEventHandler(fadm_FormClosed);
                fadm.Show(dockPanel, DockState.Document);
            }
            else
            {
                flg.Activate();
            }
        }

        private void fadm_FormClosed(object sender, FormClosedEventArgs e)
        {
            fadm = null;
            //throw new NotImplementedException();
        }
        TimerAndProgrespass tap;
        private void timerandProgressbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tap == null)
            {
                TimerAndProgrespass tap = new TimerAndProgrespass();
                tap.MdiParent = this;
                tap.FormClosed += new FormClosedEventHandler(tap_FormClosed);
                tap.Show(dockPanel, DockState.Document);
            }
            else
            {
                flg.Activate();
            }
        }

        private void tap_FormClosed(object sender, FormClosedEventArgs e)
        {
            tap = null;
            //throw new NotImplementedException();
        }
        EndcripAndDescript ead;
        private void escriptAndDescriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ead == null)
            {
                Tool ead = new Tool();
                ead.MdiParent = this;
                ead.FormClosed += new FormClosedEventHandler(ead_FormClosed);
                ead.Show(dockPanel, DockState.Document);
            }
            else
            {
                flg.Activate();
            }
        }

        private void ead_FormClosed(object sender, FormClosedEventArgs e)
        {
            ead = null;
            //throw new NotImplementedException();
        }

        private void dockPanel1_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void reportMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ead == null)
            {
                ReportTheoMon rpm = new ReportTheoMon();
                rpm.MdiParent = this;
                rpm.FormClosed += new FormClosedEventHandler(ead_FormClosed);
                rpm.Show(dockPanel, DockState.Document);
            }
            else
            {
                flg.Activate();
            }
        }


        /*fTableManager fma;
        private void fTableManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        foreach (Form frm in this.MdiChildren)
            {
                if (!frm.Focused)
                {
                    frm.Visible = true;
                    frm.Dispose();
                }
            }


            if (fma == null)
            {
                Account loginAccount = AccountDAL.Instance.GetAccountByUserName(Username);
                fma = new fTableManager(loginAccount);
                fma.MdiParent = this;
                fma.FormClosed += new FormClosedEventHandler(fma_FormClosed);
                fma.Show();

            }
            else
            {
                fma.Activate();
            }
        }

        private void fma_FormClosed(object sender, FormClosedEventArgs e)
        {
            fma = null;
            //throw new NotImplementedException();
        }

        private void fAccountProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RPBill rb = new RPBill();
            rb.MdiParent = this;
            rb.Show();

        }*/
    }
}
