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

namespace QuanLyKhachSan.GUI
{
    public partial class ReportTheoMon : DockContent
    {
        public ReportTheoMon()
        {
            InitializeComponent();
        }

        private void ReportTheoMon_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DataSetChonMonAn.ChonTheoMonAn' table. You can move, or remove it, as needed.
            List<Category> listCategory = CategoryDAL.Instance.GetListCategory();
            cbtim.DataSource = listCategory;// load dữ liệu lên combo box;
            cbtim.DisplayMember = "Name";
        }

        private void btntim_Click(object sender, EventArgs e)
        {
            this.ChonTheoMonAnTableAdapter.Fill(this.DataSetChonMonAn.ChonTheoMonAn, cbtim.Text);

            this.reportViewer1.RefreshReport();
        }
    }
}
