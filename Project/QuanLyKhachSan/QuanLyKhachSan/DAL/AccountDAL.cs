using QuanLyKhachSan.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DAL
{
    public class AccountDAL
    {
        private static AccountDAL instance;

        public static AccountDAL Instance 
        {
            get { if (instance == null) instance = new AccountDAL(); return instance; }
            private set { AccountDAL.instance = value; }
        }
        private AccountDAL() { }
        public bool Login (string UserName, string Password)

        {
            /// mã hóa mật khẩu
            byte[] temp = ASCIIEncoding.ASCII.GetBytes(Password);//lấy ta được môt mảng kiểu byte từ chuỗi
            byte[] hasData = new MD5CryptoServiceProvider().ComputeHash(temp);

            string hasPass = "";
            foreach(byte item in hasData)
            {
                hasPass += item;    
            }
            //var list = hasData.ToString();
            //list.Reverse();
            

            string query = "USP_Login @userName , @passWord";
            DataTable result = Dataprovider.Instance.Excutequery(query, new object[] { UserName, hasPass });
            
            return result.Rows.Count > 0;
        }

     

        public bool UpdateAccount(string userName, string displayName,  string pass,string newPass)
        {
            int result = Dataprovider.Instance.ExcuteNonquery("exec USP_UpdateAccount @userName , @displayName , @password , @newPassword",new object[] {userName,displayName,pass,newPass});
            return result > 0;
        }

        public DataTable GetListAccount()
        {
            return Dataprovider.Instance.Excutequery("select * from Account");
        }
        public Account GetAccountByUserName(string userName)
        {
            DataTable data = Dataprovider.Instance.Excutequery("select * from account where userName = '" + userName + "'");
            
            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }

        public bool InsertAccount(string name,string displayName,int type)
        {
            string query = string.Format("insert dbo.Account(UserName,DisplayName,type,password) values (N'{0}',N'{1}' , {2},{3})", name, displayName, type, "3244185981728979115075721453575112");
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }

        public bool UpdateAccount(string name, string displaName, int type)
        {
            string query = string.Format("update dbo.Account set DisplayName = N'{1}', Type = {2} where UserName=N'{0}'", name, displaName, type);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }
        public bool DeleteAccount(string name)
        {
            string query = string.Format("Delete dbo.Account where UserName =N'{0}'", name);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }
        public bool ResetPassword(string name)
        {
            string query = string.Format("update dbo.Account  set password = N'3244185981728979115075721453575112' where UserName =N'{0}'", name);
            int result = Dataprovider.Instance.ExcuteNonquery(query);

            return result > 0;
        }
    }

}
