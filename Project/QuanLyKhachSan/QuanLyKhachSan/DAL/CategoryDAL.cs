using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAL
{
    public class CategoryDAL
    {
        private static CategoryDAL instance;

        public static CategoryDAL Instance 
        {
            get { if (instance == null) instance = new CategoryDAL(); return CategoryDAL.instance; }
            private set { CategoryDAL.instance = value; }   
        }
        private CategoryDAL() { }

        public  List<Category> GetListCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from RoomCategory";
            DataTable data = Dataprovider.Instance.Excutequery(query);//datable để lấy dữ liệu ra

            foreach(DataRow item in data.Rows)
            {
                Category category= new Category(item);
                list.Add(category);
            }

            return list;
        }
        public Category GetCategoryByID(int id)
        {
            Category category = null;

            string query = "select * from RoomCategory where id = " + id;
            DataTable data = Dataprovider.Instance.Excutequery(query);//datable để lấy dữ liệu ra

            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
                return category;
            }
            return category;
        }
        public List<Category> GetListRoomCategory()
        {
            List<Category> list = new List<Category>();

            string query = "select * from RoomCategory ";// lấy all thông tin trong bảng Room theo điều kiện là id mình truyền vào.
            DataTable data = Dataprovider.Instance.Excutequery(query);

            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                list.Add(category);
            }
            return list;
        }
        public bool InsertCategory(string names)
        {
            string query = string.Format("insert dbo.RoomCategory(names) values (N'{0}')", names);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;

        }
        public bool UpdateCategory(int id, string names)
        {
            string query = string.Format("update dbo.RoomCategory set names =N'{0}'  where id={1}",names,id);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }
        public bool DeleteCategory(int id)
        {
            
            BillInfoDAL.Instance.DeleteBillInfoByFoodID(id);
            RoomDAL.Instance.DeleteRoomByID(id);
            string query = string.Format("delete RoomCategory where id = {0}", id);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }

    }
}
