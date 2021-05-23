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
    public partial class RPBill : DockContent
    {
        public RPBill()
        {
            InitializeComponent();
        }
        private DateTime checkIn;
        private DateTime checkOut;

        public DateTime CheckIn { get => checkIn; set => checkIn = value; }
        public DateTime CheckOut { get => checkOut; set => checkOut = value; }

        private void RPBill_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ReportBill.USP_GetListBillByDateOfRP' table. You can move, or remove it, as needed.
            this.USP_GetListBillByDateOfRPTableAdapter.Fill(this.ReportBill.USP_GetListBillByDateOfRP,CheckIn,CheckOut);

            this.reportViewer1.RefreshReport();
        }
    }
}
