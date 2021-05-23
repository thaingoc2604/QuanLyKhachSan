using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using WeifenLuo.WinFormsUI.Docking;

namespace QuanLyKhachSan
{
    public partial class Tool : DockContent
    {
        public Tool()
        {
            InitializeComponent();
        }
        private InfoConnect info = new InfoConnect();
        private string Encode(string str)
        {
            var strEncode = "";
            for (var i = 0; i < str.Length; i++)
            {
                if (i != str.Length - 1)
                {
                    strEncode += $"{Convert.ToChar(Convert.ToInt32(str[i]) + 1)}-";
                    continue;
                }
                strEncode += $"{Convert.ToChar(Convert.ToInt32(str[i]) + 1)}";
            }

            return strEncode;
        }

        private string Uncode(string str)
        {
            if (string.IsNullOrEmpty(str)) return str;
            var listChar = str.Split('-');
            var strEncode = "";
            for (var i = 0; i < listChar.Length; i++)
                strEncode += $"{Convert.ToChar(Convert.ToInt32(Convert.ToChar(listChar[i])) - 1)}";
            return strEncode;
        }
        public void MaHoa(string serverName, string database, string uid, string password, string fileName)
        {
            if (!string.IsNullOrEmpty(uid) || !string.IsNullOrEmpty(password))
            {
                uid = Encode(uid);
                password = Encode(password);
            }

            var xtw = new XmlTextWriter(fileName, null) { Formatting = Formatting.Indented };
            xtw.WriteStartDocument();

            // write to element Connect
            xtw.WriteStartElement("Conncet");

            xtw.WriteElementString("server", serverName);
            xtw.WriteElementString("database", database);
            xtw.WriteElementString("uid", uid);
            xtw.WriteElementString("password", password);

            xtw.WriteEndElement();
            xtw.WriteEndDocument();
            xtw.Flush();
            xtw.Close();

            MessageBox.Show("Ma hoa thanh cong.\n Du lieu luu tai file mahoa.xml");
        }
        public void GiaiMa(string fileName)
        {
            var xtw = new XmlTextWriter(fileName, null) { Formatting = Formatting.Indented };
            xtw.WriteStartDocument();

            // write to element Connect
            xtw.WriteStartElement("Conncet");

            xtw.WriteElementString("server", info.ServerName);
            xtw.WriteElementString("database", info.Database);
            xtw.WriteElementString("uid", info.UserId);
            xtw.WriteElementString("password", info.Password);

            xtw.WriteEndElement();
            xtw.WriteEndDocument();
            xtw.Flush();
            xtw.Close();

            MessageBox.Show("Giai ma thanh cong.\n Du lieu luu tai file mahoa.xml");
        }
        private string ReadValueInNode(XmlTextReader xtr)
        {
            var value = "";
            while (xtr.Read())
                if (xtr.NodeType == XmlNodeType.Text)
                    return value = xtr.Value;

            return "";
        }
        private void DocChuoiKetNoi(string fileName)
        {
            if (!File.Exists(fileName))
                MessageBox.Show("file khong ton tai");
            // Đường dẫn tới file xml.
            // Tạo một đối tượng TextReader mới
            var xtr = new XmlTextReader(fileName);
            while (xtr.Read())
            {
                if (xtr.IsStartElement())
                    switch (xtr.Name)
                    {
                        case "server":
                            info.ServerName = ReadValueInNode(xtr);
                            break;
                        case "database":
                            info.Database = ReadValueInNode(xtr);
                            break;
                        case "uid":
                            info.UserId = Uncode(ReadValueInNode(xtr));
                            break;
                        case "password":
                            info.Password = Uncode(ReadValueInNode(xtr));
                            break;
                    }
            }
        }
        private void btn_MaHoa_Click(object sender, EventArgs e)
        {
            MaHoa(tbx_ServerName.Text, txtDB.Text, tbx_uid.Text, tbx_Password.Text, "mahoa.xml");
        }

        private void btnGiaiMa_Click(object sender, EventArgs e)
        {
            var open = new OpenFileDialog();
            open.Filter = "xml file (*.xml)|*.xml";
            if (open.ShowDialog() != DialogResult.OK) return;
            DocChuoiKetNoi(open.FileName);
            GiaiMa("giaima.xml");
        }
    }
}
