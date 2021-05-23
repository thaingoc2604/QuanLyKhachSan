using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace QuanLyKhachSan
{
    public partial class SearchNC : Form
    {
        public SearchNC()
        {
            InitializeComponent();
        }

       // string connSTR = @"Data Source=DESKTOP-OEKB8CR\SQLEXPRESS;Initial Catalog=DBQuanLyKhachSan;Integrated Security=True"
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-OEKB8CR\SQLEXPRESS;Initial Catalog=DBQuanLyKhachSan;Integrated Security=True");


        List<xaydungdieukien> listDieukien = new List<xaydungdieukien>();
        private void btnThemDieuKien_Click(object sender, EventArgs e)
        {
            string orAnd = this.cboOrAnd.Text;
            string Feild = this.cboField.Text;
            string Operator = this.cboOperrator.Text;
            string inputsearching = this.cboInput.Text;
            xaydungdieukien themmoidieukien = new xaydungdieukien(orAnd,Feild,Operator,inputsearching);
            listDieukien.Add(themmoidieukien);

            var listdieukienQuery = listDieukien.ToList();
            var listQueryBinding = new BindingList<xaydungdieukien>(listDieukien);
            this.dtgvQuerydieukien.DataSource = listQueryBinding;
        }

        private void bntTimKiem_Click(object sender, EventArgs e)
        {
            string resultQuery=  "SELECT * FROM Room WHERE";
            string orAnd = this.cboOrAnd.Text;
            string Feild = this.cboField.Text;
            string Operator = this.cboOperrator.Text;
            string inputsearching = this.cboInput.Text;
            for ( int i = 0; i< listDieukien.Count; i++)
            {
                
                resultQuery +=listDieukien[i].motDieuKien(orAnd, Feild, Operator, inputsearching);
            }
            MessageBox.Show("" + resultQuery);

           // SqlCommand cmd = new SqlCommand(resultQuery, connection);
         
            
            
        }
    }
}
