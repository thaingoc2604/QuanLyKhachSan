using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using WeifenLuo.WinFormsUI.Docking;
using System.Xml;
using System.IO;

namespace QuanLyKhachSan
{
    public partial class EndcripAndDescript : Form
    {
        /*public EndcripAndDescript()
        {
            InitializeComponent();
            desObj = Rijndael.Create();
        }
        string cipherData;
        byte[] chipherbytes;
        byte[] plainbytes;
        byte[] plainbytes2;
        byte[] plainKey;

        SymmetricAlgorithm desObj;*/
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
            //Server=myServerAddress;Database=myDataBase;Trusted_Connection=True;

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
        /*private void button2_Click(object sender, EventArgs e)
{
cipherData = textBox_Plain_Text.Text;
plainbytes = Encoding.ASCII.GetBytes(cipherData);
plainKey = Encoding.ASCII.GetBytes("0123456789abcdef");
desObj.Key = plainKey;

desObj.Mode = CipherMode.CBC;
desObj.Padding = PaddingMode.PKCS7;
System.IO.MemoryStream ms = new System.IO.MemoryStream();
CryptoStream cs = new CryptoStream(ms, desObj.CreateEncryptor(), CryptoStreamMode.Write);
cs.Write(plainbytes, 0, plainbytes.Length);
cs.Close();
chipherbytes = ms.ToArray();
ms.Close();
textBox_EndCript_Text.Text = Encoding.ASCII.GetString(chipherbytes);
}

private void button1_Click(object sender, EventArgs e)
{
System.IO.MemoryStream ms1 = new System.IO.MemoryStream(chipherbytes);
CryptoStream cs1 = new CryptoStream(ms1, desObj.CreateDecryptor(), CryptoStreamMode.Read);
cs1.Read(chipherbytes, 0, chipherbytes.Length);
plainbytes2 = ms1.ToArray();
cs1.Close();
ms1.Close();

textBox_Descript_Text.Text = Encoding.ASCII.GetString(plainbytes2);
}*/
    }
}
