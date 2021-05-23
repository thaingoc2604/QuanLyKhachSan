using QuanLyKhachSan.DAL;
using QuanLyKhachSan.DTO;
using QuanLyKhachSan.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace QuanLyKhachSan
{
    public partial class fAdmin : DockContent
    {
        BindingSource accountList = new BindingSource();
        BindingSource foodList = new BindingSource();// bindingsource sẽ hỗ trợ việc mất kết nối binding và khi có cần sữa đổi dữ liệu thì chỉ cần sửa của thằng
        BindingSource categoryList = new BindingSource();
        BindingSource tableList = new BindingSource();

        public Account loginAccount;
        // binding source và datasource thôi không cần sửa của thằng datagridview
        // tầng trên chỉ cần gán datasource của datagridview và datasource của bindingsource thôi
        // tầng dưới chỉ cần thay đổi dữ liệu của bindingsource là xong
        public fAdmin()
        {
            InitializeComponent();
            GetListAccount();
            Load();
            

        }


        // khi nhấn vào thống kê thì nó sẽ show lên thông tin hóa đơn luôn
        #region methods

        List<Room> SearchFoodByName(string name) /// tìm theo món ăn theo tên
        {
            List<Room> listFood = RoomDAL.Instance.SearchFoodByName(name);
            
            return listFood;
        }
        void Load()
        {
            dtgvTableRoom.DataSource = tableList;
            dtgvCategory.DataSource = categoryList;
            dtgvRoom.DataSource = foodList;
            dtgvAccount.DataSource = accountList;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value); // load List Bill lên luôn 
            LoadListFood();// load các dich vụ chung của tất cả các phòng.
            LoadAccount();
            AddRoomBinding();
            AddAcountBinding();
            LoadCategoryIntoCobobox(cboFoodCategory);
            LoadListRoomCategory();
            LoadListTableRoom();
            AddCategoryBinding();
            AddTableRoom();
      
        }

        void GetListAccount()
        {
            string query = "select * from dbo.Account";
            dtgvAccount.DataSource = Dataprovider.Instance.Excutequery(query);

        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);

        }
        // phương thức load list bill lên
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
           dtgvBill.DataSource = BillDAL.Instance.GetBillListByDate(checkIn, checkOut);
            
        }
        void LoadAccount()
        {
            accountList.DataSource = AccountDAL.Instance.GetListAccount();
        }
        void AddAcountBinding()
        {
            txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DisplayName", true, DataSourceUpdateMode.Never));
            nmType.DataBindings.Add(new Binding("Value", dtgvAccount.DataSource, "Type", true, DataSourceUpdateMode.Never));

        }
        void AddRoomBinding()
        {
            txtFoodName.DataBindings.Add(new Binding("Text", dtgvRoom.DataSource, "Name",true,DataSourceUpdateMode.Never));
            txtRoomID.DataBindings.Add(new Binding("Text", dtgvRoom.DataSource, "ID", true, DataSourceUpdateMode.Never));
            nmFoodPrice.DataBindings.Add(new Binding("Value", dtgvRoom.DataSource, "Price", true, DataSourceUpdateMode.Never));
            // trong C# có 1 kỹ thuật quan trong là binding
            /* giải thích câu trên: từ cái giá trị textbox foodname hãy thay đổi giá trị của thằng text bằng giá trị của thằng "name" từ nguồn là data source
             * 
             */
        }
        void AddCategoryBinding()
        {
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtCategoryID.DataBindings.Add(new Binding("Text", dtgvCategory.DataSource, "ID", true, DataSourceUpdateMode.Never));
        }
        void AddTableRoom()
        {
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTableRoom.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtTableID.DataBindings.Add(new Binding("Text", dtgvTableRoom.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtTrangThai.DataBindings.Add(new Binding("Text", dtgvTableRoom.DataSource, "Status", true, DataSourceUpdateMode.Never));


        }
        
        void LoadCategoryIntoCobobox(ComboBox cb)
        {
            cb.DataSource = CategoryDAL.Instance.GetListCategory();
            cb.DisplayMember = "Name";
        }
        void LoadListFood()
        {
            foodList.DataSource = RoomDAL.Instance.GetListRoom();
        }
        // thêm account
        void AddAccount(string userName, string displayName,int type)
        {
            if(AccountDAL.Instance.InsertAccount(userName, displayName, type))
            {
                MessageBox.Show("Thêm tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Thêm tài khoản thất bại");
            }
            LoadAccount();
        }
        // edit account
        void EditAccount(string userName, string displayName, int type)
        {
            if (AccountDAL.Instance.UpdateAccount(userName, displayName, type))
            {
                MessageBox.Show("Sửa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Sửa  tài khoản thất bại");
            }
            LoadAccount();
        }
        // Xóa Account
        void DeleteAccount(string userName)
        {
            if(loginAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Vui lòng đừng xóa tài khoản của bạn chứ !!");
                return;
            }
            if (AccountDAL.Instance.DeleteAccount(userName))
            {
                MessageBox.Show("Xóa tài khoản thành công");
            }
            else
            {
                MessageBox.Show("Xóa  tài khoản thất bại");
            }
            LoadAccount();
        }

        void ResetPass(string userName)
        {
            if (AccountDAL.Instance.ResetPassword(userName))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Đặt lại mật khẩu thất bại");
            }
        }
        #endregion

        #region event
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            LoadAccount();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string s = txtSearchFoodName.Text;
            string a = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s.ToLower());
            txtSearchFoodName.Text = a;
            foodList.DataSource = SearchFoodByName(txtSearchFoodName.Text);

        }

        private void txtRoomID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (dtgvRoom.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvRoom.SelectedCells[0].OwningRow.Cells["CategoryID"].Value;//cách lấy ra 1 Cells bất kỳ

                    Category category = CategoryDAL.Instance.GetCategoryByID(id);
                    cboFoodCategory.SelectedItem = category;
                    int index = -1;
                    int i = 0;
                    foreach (Category item in cboFoodCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cboFoodCategory.SelectedIndex = index;
                }
            }
            catch { }
        }
        // thêm món vào trong phòng
        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text;
            int categoryID = (cboFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;

            if (RoomDAL.Instance.InsertFoodInRoom(name, categoryID, price))
            {
                MessageBox.Show("Thêm món thành công");
                LoadListFood();
                if (insertFood != null)
                    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có Lỗi khi thêm thức ăn");
            }
        }

        private void btnEditRoom_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text;
            int categoryID = (cboFoodCategory.SelectedItem as Category).ID;
            float price = (float)nmFoodPrice.Value;
            int id = Convert.ToInt32(txtRoomID.Text);

            if (RoomDAL.Instance.UpdateFoodInRoom(id, name, categoryID, price))
            {
                MessageBox.Show("Sửa món thành công");
                LoadListFood();
                if (updateFood != null)
                    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có khi sửa thức ăn");
            }
        }
        // do cái Bill nó có liên kết khóa ngoại( foreign key với billinfor nên chúng ta muốn xóa bill thì phải xóa billinfo 
        //trước)
        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtRoomID.Text);

            if (RoomDAL.Instance.DeleteFoodInRoom(id))
            {
                MessageBox.Show("Xóa món thành công");
                LoadListFood();
                if (deleteFood != null)
                    deleteFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có khi xóa thức ăn");
            }
        }


        private void btnviewbill_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpFromDate.Value, dtpToDate.Value);

        }


        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add { insertFood += value; }
            remove { insertFood -= value; }
        }

        private event EventHandler deleteFood;
        public event EventHandler  DeleteFood
        {
            add { deleteFood += value; }
            remove { deleteFood -= value; }
        }

        private event EventHandler updateFood;
        public event EventHandler UptateFood
        {
            add { updateFood += value; }
            remove { updateFood -= value; }
        }
        #endregion

        private void btnShowRoom_Click(object sender, EventArgs e)
        {
            LoadListFood();// load các dịch vụ của phòng lên
        }

        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string s = txtDisplayName.Text;
            string a = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s.ToLower());
            txtDisplayName.Text = a;

            string s1 = txtUserName.Text;
            string a1 = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s1.ToLower());
            txtUserName.Text = a1;

            string userName = txtUserName.Text;
            string displayName = txtDisplayName.Text;
            int type = (int)nmType.Value;

            AddAccount(userName, displayName, type);
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            DeleteAccount(userName);
        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string s = txtDisplayName.Text;
            string a = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s.ToLower());
            txtDisplayName.Text = a;

            string s1 = txtUserName.Text;
            string a1 = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s1.ToLower());
            txtUserName.Text = a1;

            string userName = txtUserName.Text;
            string displayName = txtDisplayName.Text;
            int type = (int)nmType.Value;

            EditAccount(userName, displayName, type);
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text;
            ResetPass(userName);
        }

        private void btnFirstBillPage_Click(object sender, EventArgs e)
        {
            txtPageBill.Text = "1";
        }

        private void btnLastBillPage_Click(object sender, EventArgs e)
        {
            int sumRecord = BillDAL.Instance.GetNumBillListByDate(dtpFromDate.Value, dtpToDate.Value);

            int lastPage = sumRecord / 10;

            if (sumRecord % 10 != 0)
                lastPage++;
            txtPageBill.Text = lastPage.ToString();
        }

        private void txtPageBill_TextChanged(object sender, EventArgs e)
        {
            dtgvBill.DataSource = BillDAL.Instance.GetBillListByDateAndPage(dtpFromDate.Value, dtpToDate.Value, Convert.ToInt32(txtPageBill.Text));
        }

        private void btnPrevioursBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPageBill.Text);

            if (page > 1)
                page--;
            txtPageBill.Text = page.ToString();
        }

        private void btnNextBillPage_Click(object sender, EventArgs e)
        {
            int page = Convert.ToInt32(txtPageBill.Text);
            int sumRecord = BillDAL.Instance.GetNumBillListByDate(dtpFromDate.Value, dtpToDate.Value);

            if (page < sumRecord)
                page++;
            txtPageBill.Text = page.ToString();
        }

        private void fAdmin_Load(object sender, EventArgs e)
        {

            
        }

        private void fAdmin_Load_1(object sender, EventArgs e)
        {

           
        }


       

        void LoadListRoomCategory()
        {
            categoryList.DataSource = CategoryDAL.Instance.GetListRoomCategory();
        }
        private void btnShowCategory_Click(object sender, EventArgs e)
        {
            LoadListRoomCategory();
        }

        void LoadListTableRoom()
        {
            tableList.DataSource = TableDAL.Instance.GetListTableRoom();
        }
        private void btnShowTable_Click(object sender, EventArgs e)
        {
            LoadListTableRoom();
        }
        // them của danh mục
        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string s = txtCategoryName.Text;
            string a = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s.ToLower());
            txtCategoryName.Text = a;
            string names = txtCategoryName.Text;

            if (CategoryDAL.Instance.InsertCategory(names))
            {
                MessageBox.Show("Thêm Danh mục thành công");
                LoadListRoomCategory();
                //if (insertFood != null)
                //    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có Lỗi khi thêm Danh mục");
            }
        }
        private void btnEditCategory_Click(object sender, EventArgs e)
        {
            string s = txtCategoryName.Text;
            string a = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s.ToLower());
            txtCategoryName.Text = a;
            string name = txtCategoryName.Text;
            int id = Convert.ToInt32(txtCategoryID.Text);

            if (CategoryDAL.Instance.UpdateCategory(id, name))
            {
                MessageBox.Show("Sửa Danh mục thành công");
                LoadListRoomCategory();
                //if (updateFood != null)
                //  updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có Lỗi khi sửa Danh mục");
            }
        }
        private void btnDeleteCategory_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryID.Text);

            if (CategoryDAL.Instance.DeleteCategory(id))
            {
                MessageBox.Show("Xóa Category thành công");
                LoadListRoomCategory();
                //if (updateFood != null)
                //    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có khi Xóa Category");
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            string s = txtTableName.Text;
            string a = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s.ToLower());
            txtTableName.Text = a;

            string s1 = txtTrangThai.Text;
            string a1 = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s1.ToLower());
            txtTrangThai.Text = a1;

            string name = txtTableName.Text;
            string status = txtTrangThai.Text;
            if (TableDAL.Instance.InsertTable(name, status))
            {
                MessageBox.Show("Thêm Phòng thành công");
                LoadListTableRoom();
                //if (insertFood != null)
                //    insertFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có Lỗi khi thêm Phòng");
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            string s = txtTableName.Text;
            string a = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s.ToLower());
            txtTableName.Text = a;

            string s1 = txtTrangThai.Text;
            string a1 = new System.Globalization.CultureInfo("en-US", false).TextInfo.ToTitleCase(s1.ToLower());
            txtTrangThai.Text = a1;

            string name = txtFoodName.Text;
            string status = txtTrangThai.Text;
            int id = Convert.ToInt32(txtTableID.Text);

            if (TableDAL.Instance.UpdateTable(id, name, status))
            {
                MessageBox.Show("Sửa bàn thành công");
                LoadListTableRoom();
                //if (updateFood != null)
                //    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có khi sửa bàn");
            }

        }
       
        private void btnDeleteTable_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtTableID.Text);

            if (TableDAL.Instance.DeleteTable(id))
            {
                MessageBox.Show("Xóa Bàn thành công");
                LoadListTableRoom();
                //if (updateFood != null)
                //    updateFood(this, new EventArgs());
            }
            else
            {
                MessageBox.Show("Có  khi Xóa bàn");
            }
        }

       

        private void btnBCReport_Click(object sender, EventArgs e)
        {
            RPBill rp = new RPBill();
            rp.CheckIn = dtpFromDate.Value;
            rp.CheckOut = dtpToDate.Value;
            rp.ShowDialog();
        }

        private void btnSaoLuu_Click(object sender, EventArgs e)
        {
            /*try
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

            }*/
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            search s = new search();
            s.ShowDialog();
        }

        private void tabAdmin_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đẩy để xem xem doanh thu!";
        }

        private void tabAdmin_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnviewbill_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để Thống Kê";
        }

        private void btnviewbill_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnBCReport_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để in Báo Cáo";
        }

        private void btnBCReport_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnFirstBillPage_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Quay lạy trang đầu";
        }

        private void btnFirstBillPage_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnPrevioursBillPage_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Quay Lại";
        }

        private void btnPrevioursBillPage_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnNextBillPage_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Tiếp Theo!";
        }

        private void btnNextBillPage_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnLastBillPage_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Đến Trang Cuối";
        }

        private void btnLastBillPage_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtPageBill_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Bạn Đang Ở Trang"+txtPageBill;
        }

        private void txtPageBill_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void dtpFromDate_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Ngày Bắt Đầu";
        }

        private void dtpFromDate_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void dtpToDate_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Ngày Kết Thúc";
        }

        private void dtpToDate_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnAddRoom_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Thêm Dịch Vụ!";
        }

        private void btnAddRoom_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnDeleteRoom_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Xóa Dịch Vụ";
        }

        private void btnDeleteRoom_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnEditRoom_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Sửa Dịch Vụ";
        }

        private void btnEditRoom_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnShowRoom_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Xem Dịch Vụ";
        }

        private void btnShowRoom_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtSearchFoodName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Nhập Key cần Search";
        }

        private void txtSearchFoodName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnSearch_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Tìm";
        }

        private void btnSearch_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Tìm Theo combobox";
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void panel6_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Những trường  trong thông tin dich vụ";
        }

        private void panel6_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtRoomID_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để nhập ID!";
        }

        private void txtRoomID_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtFoodName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để nhập Tên Món!";
        }

        private void txtFoodName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void cboFoodCategory_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để nhập Loại Món Ăn !";
        }

        private void cboFoodCategory_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnAddCategory_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Thêm Danh mục";
        }

        private void btnAddCategory_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnDeleteCategory_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Xóa Danh Mục";
        }

        private void btnDeleteCategory_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnEditCategory_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Sửa Danh Mục";
        }

        private void btnEditCategory_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnShowCategory_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Xem Danh Mục";
        }

        private void btnShowCategory_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void panel11_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Các trường của Danh Mục";
        }

        private void panel11_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtCategoryID_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "ID của Danh Mục";
        }

        private void txtCategoryID_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtCategoryName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào để nhập tên Danh Mục";
        }

        private void txtCategoryName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void fAdmin_Load_2(object sender, EventArgs e)
        {
            statusStripOne.BackColor = Color.LightBlue;
        }

        private void btnAddTable_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Thêm Phòng!";
        }

        private void btnAddTable_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnDeleteTable_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Xóa Phòng";
        }

        private void btnDeleteTable_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnEditTable_MouseEnter(object sender, EventArgs e)
        {

        }

        private void btnEditTable_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Sửa Phòng";
        }

        private void btnEditTable_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnShowTable_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Xem Danh sách phòng";
        }

        private void btnShowTable_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void panel13_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Các trường trong bảng phòng";
        }

        private void panel13_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtTableID_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "ID phòng";
        }

        private void txtTableID_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtTableName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Tên Phòng";
        }

        private void txtTableName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtTrangThai_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtTrangThai_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void txtTrangThai_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Trạng thái Phòng";
        }

        private void dtgvTableRoom_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Danh Sách các phòng";
        }

        private void dtgvTableRoom_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnAddAccount_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để thêm tài khoản";
        }

        private void btnAddAccount_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnDeleteAccount_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để Xóa tài khoản";
        }

        private void btnDeleteAccount_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnEditAccount_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để sửa thông tin tài khoản";
        }

        private void btnEditAccount_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnShowAccount_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để xem thông tin các tài khoản!";
        }

        private void btnShowAccount_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void panel21_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Thông tin các trường của tài khoản";
        }

        private void panel21_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtUserName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để nhập tên tài khoản!";
        }

        private void txtUserName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void txtDisplayName_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây nhập tên hiển thị!";
        }

        private void txtDisplayName_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void btnResetPassword_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Click vào đây để đặt lại mật khẩu cho Tài khoản!";
        }

        private void btnResetPassword_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void dtgvAccount_MouseHover(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "Danh sách các tài khoản";
        }

        private void dtgvAccount_MouseLeave(object sender, EventArgs e)
        {
            toolStripStatusLabelOne.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportTheoMon f = new ReportTheoMon();
            f.ShowDialog();
        }





        /*private void btnReadXML_Click(object sender, EventArgs e)
        {
            DataSet dataset = new DataSet();
            dataset.ReadXml(@"D:\QuanLyKhachSan1\Project\QuanLyKhachSan\emp.xml");
            dtgvBill.DataSource = dataset.Tables[0];
        }

        private void btnWriteXML_Click(object sender, EventArgs e)
        {
            DataTable dt = GetDataTableFromDGV(dtgvBill);
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            ds.WriteXml(File.OpenWrite(@"d:\EmpOut.xml"));
        }

        private DataTable GetDataTableFromDGV(DataGridView dtgvBill)
        {
            var dt = new DataTable();
            foreach(DataGridViewColumn column in dtgvBill.Columns)
            {
                if(column.Visible)
                {
                    dt.Columns.Add();
                }
                object[] cellValues = new object[dtgvBill.Columns.Count];
                foreach(DataGridViewRow row in dtgvBill.Rows)
                { 
                    for(int i=0; i<row.Cells.Count;i++)
                    {
                        cellValues[i] = row.Cells[i].Value;
                    }
                    dt.Rows.Add(cellValues);
                }
                return dt;
            }
        }*/
    }
    
}
