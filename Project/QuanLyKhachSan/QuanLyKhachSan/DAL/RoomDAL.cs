using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAL
{
    public class RoomDAL
    {
        private static RoomDAL instance;

        public static RoomDAL Instance
        {
            get { if (instance == null)instance = new RoomDAL(); return RoomDAL.instance; }
            private set { RoomDAL.instance = value; }
        }
        private RoomDAL() { }

        public List<Room> GetRoomByCategiryID(int id)
        {
            List<Room> list = new List<Room>();

            string query = "select * from Room where idCategory = " + id; // lấy all thông tin trong bảng Room theo điều kiện là id mình truyền vào.
            DataTable data = Dataprovider.Instance.Excutequery(query);

            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                list.Add(room);
            }
            return list;
        }
        // đưa món ăn lên
        public List<Room> GetListRoom()
        {
            List<Room> list = new List<Room>();

            string query = "select * from Room ";// lấy all thông tin trong bảng Room theo điều kiện là id mình truyền vào.
            DataTable data = Dataprovider.Instance.Excutequery(query);

            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                list.Add(room);
            }
            return list;
        }
        public void DeleteRoomByID(int id)
        {
            Dataprovider.Instance.Excutequery("delete  dbo.Room where id =" + id);
        }
        public List<Room> SearchFoodByName(string names)
        {
            List<Room> list = new List<Room>();

            string query = string.Format("select * from dbo.Room where dbo.fuConvertToUnsign1(names) like N'%'+dbo.fuConvertToUnsign1(N'{0}')+'%'", names);// lấy all thông tin trong bảng Room theo điều kiện là id mình truyền vào.
            DataTable data = Dataprovider.Instance.Excutequery(query);

            foreach (DataRow item in data.Rows)
            {
                Room room = new Room(item);
                list.Add(room);
            }
            return list;
        }
        public bool InsertFoodInRoom(string name, int id,float price)
        {
            string query = string.Format("insert dbo.Room(names,idCategory,price) values (N'{0}', {1} , {2})",name, id, price);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }

        public bool UpdateFoodInRoom(int idFood ,string name, int id, float price)
        {
            string query = string.Format("update dbo.Room set names =N'{0}',idCategory = {1}, price = {2} where id={3}", name, id, price,idFood);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }
        public bool DeleteFoodInRoom(int idFood)
        {
            BillInfoDAL.Instance.DeleteBillInfoByFoodID(idFood);
            string query = string.Format("Delete dbo.Room where id ={0}",idFood);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }
    }
}
