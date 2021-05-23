using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QuanLyKhachSan
{

    public partial class BackupAndRestore : Form
    {
        //@"Data Source=.\SQLEXPRESS;AttachDbFileName = D:\QuanLyKhachSan1\Project\QuanLyKhachSan"
        SqlConnection conn = new SqlConnection(QuanLyKhachSan.Properties.Settings.Default.DBQuanLyKhachSanConnectionString);
        public BackupAndRestore()
        {

            InitializeComponent();
        }

        private void btnBrowseLocationBK_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                /*
                txtBackup.Text = fbd.SelectedPath;
                btnBrowseLocationBK.Enabled = true;*/
                txtBackup.Text = fbd.SelectedPath;
            }
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            /*
            conn.Open();
            String database = conn.Database.ToString();
            try
            {
                if (txtBackup.Text == string.Empty)
                {
                    MessageBox.Show("nhấn enter để backup");
                }
                else
                {
                    string q = "BACKUP DATABASE [" + database + "] TO DISK ='" + txtBackup.Text + "\\" + "Database" + "-" + DateTime.Now.ToString("YYYY-MM-dd--HH-mm-ss") + ".bak'";

                    SqlCommand scmd = new SqlCommand(q, conn);
                    scmd.ExecuteNonQuery();
                    MessageBox.Show("Backup Thành Công", "Thông Báo Trạng Thái Backup", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnBackup.Enabled = false;
                }
            }
            catch { }
            */
            DialogResult t;
            t = MessageBox.Show("Backup", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                string database = conn.Database.ToString();
                try
                {
                    if (txtBackup.Text == string.Empty)
                    {
                        MessageBox.Show("Location File Backup!!");
                    }
                    else
                    {
                        string cmd = "BACKUP DATABASE [" + database + "] TO DISK='" + txtBackup.Text + "\\" + "database_được_lưu_vào _ngày_giờ " + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".bak'";

                        using (SqlCommand command = new SqlCommand(cmd, conn))
                        {
                            if (conn.State != ConnectionState.Open)
                            {
                                conn.Open();
                            }
                            command.ExecuteNonQuery();
                            conn.Close();
                            MessageBox.Show("Data Backup Successfull !");

                        }
                    }

                }
                catch
                {

                }
            }
        }

        private void btnBrowseLocationRS_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdb = new OpenFileDialog();
            fdb.Filter = "SQL SERVER database backup files|*.bak";
            fdb.Title = "Database restore";
            if (fdb.ShowDialog() == DialogResult.OK)
            {
                txtRestore.Text = fdb.FileName;
            }
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            DialogResult t;
            t = MessageBox.Show("Restore?", "Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (t == DialogResult.Yes)
            {
                string database = conn.Database.ToString();
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }
                try
                {
                    string sqlStmt2 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand bu2 = new SqlCommand(sqlStmt2, conn);
                    bu2.ExecuteNonQuery();

                    string sqlStmt3 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='" + txtRestore.Text + "'WITH REPLACE;";
                    SqlCommand bu3 = new SqlCommand(sqlStmt3, conn);
                    bu3.ExecuteNonQuery();

                    string sqlStmt4 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                    SqlCommand bu4 = new SqlCommand(sqlStmt4, conn);
                    bu4.ExecuteNonQuery();

                    MessageBox.Show("Data Restore Sucessfull !");
                    conn.Close();



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
    }



