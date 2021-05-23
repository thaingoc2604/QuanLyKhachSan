using FontAwesome.Sharp;
using GUI;
using QuanLyKhachSan.DAL;
using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace QuanLyKhachSan
{
    public partial class fTableManager : DockContent
    {

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set { loginAccount = value; ChangeAccount(loginAccount.Type); }
        }

        public fTableManager(Account acc)
        {

            InitializeComponent();
            var a = new WriteLog();
            a.FormWrite("Mở Form Manager thành công");
            this.LoginAccount = acc;

            LoadTable();
            LoadCategory();
            LoadComboboxTable(cbSwitchRoom);

        }


        #region Method

        void ChangeAccount(int type)
        {
            // nếu đúng tài khoản admin thì nó mới cho phép bạn bấm cào buttom Admin
            adminToolStripMenuItem.Enabled = type == 1;
            thôngtintaikhoang.Text += " (" + LoginAccount.DisplayName + ") ";
        }
        void LoadCategory()
        {
            //load catergory lên 
            List<Category> listCategory = CategoryDAL.Instance.GetListCategory();
            cboCategory.DataSource = listCategory;// load dữ liệu lên combo box;
            cboCategory.DisplayMember = "Name";
        }

        void LoadRoomListByCategoryID(int id)
        {
            List<Room> listRoom = RoomDAL.Instance.GetRoomByCategiryID(id);
            cboRoom.DataSource = listRoom;
            cboRoom.DisplayMember = "Name";
        }

        void LoadTable()        
        {
            
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAL.Instance.LoadTableList();//lấy ra table list
            foreach (Table item in tableList)
            {
                IconButton btn = new IconButton() { Width = TableDAL.TableWidth, Height = TableDAL.TableHeight };

                btn.Text = item.Name +"\n" + item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                switch (item.Status)
                {
                    case "Trống":
                        btn.BackColor = Color.Aqua;
                        break;
                    default:
                        btn.BackColor = Color.LightPink;
                        break;
                }
                flpTable.Controls.Add(btn);
            }
        }

        void ShowBill(int id)
        {
            lsvBill.Items.Clear();
            List<QuanLyKhachSan.DTO.Menu> listBillInfo = MenuDAL.Instance.GetListMenuByTable(id);
            float totalPrice = 0;
            foreach (QuanLyKhachSan.DTO.Menu item in listBillInfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.ServiceName.ToString());
                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;// cộng tất cả tiền trong cột thành tiền lại và lưu  tổng tiền trong textbox

                lsvBill.Items.Add(lsvItem);

                
            }
            CultureInfo culture = new CultureInfo("vi-VN");

            //Thread.CurrentThread.CurrentCulture = culture;

            txtTotalPrice.Text = totalPrice.ToString("c",culture);
        }

        void LoadComboboxTable(ComboBox cb)
        {
            cb.DataSource = TableDAL.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }

        #endregion

        //#region Events
        private void thanhToánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnThanhToan_Click(this, new EventArgs());
        }

        private void thêmMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnAddRoom_Click(this, new EventArgs());
        }
        private void btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            lsvBill.Tag = (sender as Button).Tag;//lưu vào table
            ShowBill(tableID); // showbill dựa  vào tableID mà tableID dựa vào sender
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile(LoginAccount);
            f.UpdateAccount += f_UpdateAccount;
            f.ShowDialog();
        }

        void f_UpdateAccount(object sender, AccountEvent e)
        {
            thôngTinCáNhânToolStripMenuItem.Text = "thông tin tài khoản (" + e.Acc.DisplayName + ")";
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            f.loginAccount = LoginAccount;
            f.InsertFood += f_InsertFood;
            f.UptateFood += f_UpdateFood;
            f.DeleteFood += f_DeleteFood;
            f.ShowDialog();
        }

        private void f_DeleteFood(object sender, EventArgs e)
        {
            LoadRoomListByCategoryID((cboCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
            LoadTable();
        }   

        private void f_UpdateFood(object sender, EventArgs e)
        {
            LoadRoomListByCategoryID((cboCategory.SelectedItem as Category).ID);
            if(lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void f_InsertFood(object sender, EventArgs e)
        {
            LoadRoomListByCategoryID((cboCategory.SelectedItem as Category).ID);
            if (lsvBill.Tag != null)
                ShowBill((lsvBill.Tag as Table).ID);
        }

        private void fTableManager_Load(object sender, EventArgs e)
        {
            
            /*SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["Ketnoi"].ConnectionString;
            try
            {
                conn.Open();
                MessageBox.Show("Kết nối Thành Công");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void nmDisCount_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGiamGia_Click(object sender, EventArgs e)
        {

        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null)
                return;// nếu khoong6 có data source thì nó không chạy nữa 
            Category selected = cb.SelectedItem as Category; // selected là category '
            id = selected.ID;

            LoadRoomListByCategoryID(id);
            

        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            // như vậy làm sao biết bàn nào đang được chọn , chúng ta có thể sử dụng tag của thằng listview
            // mõi khi click vào cái litsview sẽ có cái thêm DAL them billinfo

            Table table = lsvBill.Tag as Table; // chúng ta lấy ra cái table hiện tại

            if(table ==null)
            {
                MessageBox.Show("Hãy Chọn Phòng");
                return;
            }

            int idBill = BillDAL.Instance.GetUncheckBillIDByTableID(table.ID);// lấy ra cái idBill hiện tại
                                                                              // chúng ta kiểm tra xem coi có bill không
            int roomID = (cboRoom.SelectedItem as Room).ID;
            int count = (int)nmRoomCount.Value;
             if(idBill == -1){
                BillDAL.Instance.InsertBill(table.ID); // them bill moi 
                BillInfoDAL.Instance.InsertBillInfo(BillDAL.Instance.GetMaxIDBill() ,roomID,count); // them billinfo. nhung neu minh them cac gia tri cho billinfo vao aln luot la 1,1,1 thi dau biet
                // them cho bill nao dau
                // nhưng có một lưu ý là cái bill mà mình mới thêm vào thì nó có idbill là lớn nhất so với các phân tử trong bill
                // nên ta tạo thêm một cái hàm ten la GetMax
            }
            else
            {
                // nguoc lai bill da ton tai
                BillInfoDAL.Instance.InsertBillInfo(idBill, roomID, count);//bill da ton tai
            }
            ShowBill(table.ID);//load menu lên
            LoadTable();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            // giả sử th1 không có bill th2 bill đã thanh toán rồi , ta sẽ không làm gì hết
            // 1 ta phải lấy đc table hiện tại
            Table table = lsvBill.Tag as Table;
            // lấy id bill ra
            int idBill = BillDAL.Instance.GetUncheckBillIDByTableID(table.ID);
            // ktra idbill
            int discount = (int)nmDisCount.Value;

            double totalPrice = Convert.ToDouble(txtTotalPrice.Text.Split(',')[0]);
            double finaltotalPrice = totalPrice - (totalPrice / 100) * discount;
            if(idBill != -1)
            {
                if (MessageBox.Show(string.Format("Bạn có chắc muốn thanh toán hóa đơn cho bàn{0}\n Tổng tiền - (Tổng tiền/100)xGiảm giá = {1} - {1} / 100 x {2} = {3}", table.Name,totalPrice,discount,finaltotalPrice), "Thông Báo",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK );
                {
                    BillDAL.Instance.CheckOut(idBill, discount,(float)finaltotalPrice);
                    ShowBill(table.ID);
                    LoadTable();
                }
            }
        }

        private void btnSwitchRoom_Click(object sender, EventArgs e)
        {
            

            int id1 = (lsvBill.Tag as Table).ID;

            int id2 = (cbSwitchRoom.SelectedItem as Table).ID;

            if (MessageBox.Show(string.Format("Bạn có thật sự muốn chuyển phòng {0} qua phòng  {1}", (lsvBill.Tag as Table).Name, (cbSwitchRoom.SelectedItem as Table).Name), "thông báo",MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK);
            {
                TableDAL.Instance.SwitchTable(id1, id2);
                LoadTable();
            }
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string sqlBackup = "BACKUP DATABASE [DBQuanLyKhachSan] TO DISK='D:\\BKKKK.bak'";
                SqlConnection con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=DBQuanLyKhachSan;Integrated Security=True");
                con.Open();
                SqlCommand cmd = new SqlCommand(sqlBackup, con);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Đã backup cơ sở dữ liệu");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Backup Database");
                return;
            }
            catch (Exception ex)
            {

            }
        }

        private void btnPhucHoi_Click(object sender, EventArgs e)
        {

        }

        private void backupAndRestoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BackupAndRestore f = new BackupAndRestore();
            
            f.ShowDialog();
        }

        private void btnAddRoom_Click_1(object sender, EventArgs e)
        {
            var a = new WriteLog();
            a.ButtonWrite($"Thêm phòng thành công!!!");
            Table room =lsvBill.Tag as Table;

            if (room == null)
            {
                MessageBox.Show("Hãy chọn bàn!!!");
                return;
            }

            int idBill = BillDAL.Instance.GetUncheckBillIDByTableID(room.ID);

            int idRoom = (lsvBill.Tag as Table).ID;
            if (idBill == -1)//không có bill nào hết ;
            {
                BillDAL.Instance.InsertStartBill(room.ID);


            }
            else //Bill đã tồn tại
            {
                MessageBox.Show("Phòng này đã bắt đầu tính giờ", "Thông báo");
                return;
            }

            LoadRoomListByCategoryID(room.ID);
            
            LoadTable();
            ShowBill(room.ID);
        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAddRoom_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Thêm Phòng";
        }

        private void btnAddRoom_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnAddServiceRoom_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Thêm Dịch Vụ";
        }

        private void btnAddServiceRoom_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void cboCategory_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào để chọn Loại Món Ăn";
        }

        private void cboCategory_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void cboRoom_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Chọn Thức Ăn";
        }

        private void cboRoom_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnSwitchRoom_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào để chuyển phòng";
        }

        private void btnSwitchRoom_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnGiamGia_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để chọn giảm giá";
        }

        private void btnGiamGia_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnThanhToan_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để thanh toán";
        }

        private void btnThanhToan_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void flpTable_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Danh sách Phòng";
        }

        private void flpTable_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void lsvBill_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Danh sách món ăn của từng phòng";
        }

        private void lsvBill_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                    lsvBill.BackColor = cd.Color;

            }
        }

        private void foregroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog())
            {
                if (cd.ShowDialog() == DialogResult.OK)
                    btnAddRoom.ForeColor = cd.Color;
            }
        }
    }
}