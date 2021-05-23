    using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAL
{
    public class TableDAL
    {
        private static TableDAL instance;

        public static TableDAL Instance {

            get { if (instance == null) instance = new TableDAL(); return TableDAL.instance; }
            private set { TableDAL.instance = value;  }
                    
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;
        private TableDAL() { }

        public void SwitchTable(int id1, int id2)
        {
            Dataprovider.Instance.Excutequery("USP_SwitchTable @idTable1 , @idTable2",new object[] {id1, id2});
        }

       
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            // lấy cái table lên
            DataTable data = Dataprovider.Instance.Excutequery("USP_GetTableList");
            foreach(DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
                
            }
            return tableList;
        }
        // load dự liệu lên
        public List<Table> GetListTableRoom()
        {
            List<Table> list = new List<Table>();

            string query = "select * from TableRoom ";// lấy all thông tin trong bảng Room theo điều kiện là id mình truyền vào.
            DataTable data = Dataprovider.Instance.Excutequery(query);

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;
        }
        public Table GetDanhMucTableByID(int id)
        {
            Table table = null;

            string query = "select * from TableRoom where id = " + id;
            DataTable data = Dataprovider.Instance.Excutequery(query);//datable để lấy dữ liệu ra

            foreach (DataRow item in data.Rows)
            {
                table = new Table(item);
                return table;
            }
            return table;
        }
        public bool InsertTable(string name,string status)
        {
            string query = string.Format("insert dbo.TableRoom(name,status) values (N'{0}', N'{1}')", name, status);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }
        public bool UpdateTable(int id, string name,string status)
        {
            string query = string.Format("update dbo.TableRoom set name =N'{0}' ,status = N'{1}'  where id={2}", name,status, id);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }
        public bool DeleteTable(int idTable)
        {
            
            BillDAL.Instance.DeleteBillByID(idTable);
            string query = string.Format("delete TableRoom  where id = {0}",idTable);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }
    }

        
    
}
