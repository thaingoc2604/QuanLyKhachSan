using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAL
{
    public class BillDAL // lấy ra bill từ id table
    {
        private static BillDAL instance;
        public static BillDAL Instance
        {
            get { if (instance == null) instance = new BillDAL(); return BillDAL.instance; }
            private set { BillDAL.instance = value; }
        }
        private BillDAL() { }
        //thành công bill ID
        //thất bại: -1
        public int GetUncheckBillIDByTableID(int id)
        {
            DataTable data =Dataprovider.Instance.Excutequery("select * from Bill where idTable=" + id +" and status = 0");
            if(data.Rows.Count>0)
            {
                Bill bill = new Bill(data.Rows[0]);
                return bill.ID;
            }
            return -1;
        }
        public void DeleteBillByID(int id)
        {
            Dataprovider.Instance.Excutequery("delete  dbo.Bill where idTable =" + id);
        }
        public void CheckOut(int id,int discount,float totalPrice)
        {
            string query = "update dbo.Bill set dateCheckOut = GETDATE(), status = 1, " + "discount = " + discount +" ,totalPrice = "+totalPrice + " where id = " + id;
            Dataprovider.Instance.ExcuteNonquery(query);// khi check out thi phong se chuyen sang trong
        }
        public  void InsertBill (int id)
        {
            Dataprovider.Instance.ExcuteNonquery("EXEC USP_InsertBill @idTable", new object[]{ id });
        }

        public DataTable GetBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return Dataprovider.Instance.Excutequery("EXEC USP_GetListBillByDate @checkIn , @checkOut", new object[]{checkIn, checkOut });
        }
        public DataTable GetBillListByDateAndPage(DateTime checkIn, DateTime checkOut,int pageNum)
        {
            return Dataprovider.Instance.Excutequery("EXEC USP_GetListBillByDateAndPage @checkIn , @checkOut , @page", new object[] { checkIn, checkOut,pageNum });
        }

        public int GetNumBillListByDate(DateTime checkIn, DateTime checkOut)
        {
            return (int)Dataprovider.Instance.ExcuteScalar("EXEC USP_GetNumBillByDate @checkIn , @checkOut", new object[] { checkIn, checkOut });
        }
        public int GetMaxIDBill() 
        {
            try
            {
                return (int)Dataprovider.Instance.ExcuteScalar("select MAX(id) from Bill");
            }
            catch
            {
                return 1;
            }
        }
        public void InsertStartBill(int id)
        {
            Dataprovider.Instance.ExcuteNonquery("exec USP_InserStartBill @idRoom", new object[] { id });
        }
    }
}
