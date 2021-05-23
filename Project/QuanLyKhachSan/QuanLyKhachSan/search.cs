using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class search : Form
    {
        List<MonAn> monAnList = new List<MonAn>();
        List<Categoryy> categoryList = new List<Categoryy>();

        public search()
        {
            InitializeComponent();
            categoryList.Add(new Categoryy() { Id ="1", Name = "Đồ Ăn"});
            categoryList.Add(new Categoryy() { Id = "2", Name = "Canh Chua" });
            categoryList.Add(new Categoryy() { Id ="3", Name = "Canh hoi Chua"});
            categoryList.Add(new Categoryy() { Id = "4", Name = "MS" });
            categoryList.Add(new Categoryy() { Id = "5", Name = "Cơm" });


            monAnList.Add(new MonAn() { Id = "1", Name = "7up" ,IdCategory = "1"});
            monAnList.Add(new MonAn() { Id = "2", Name = "Thịt Bò Nướng", IdCategory = "1" });
            monAnList.Add(new MonAn() { Id = "3", Name = "Canh chua cá tay tượng", IdCategory = "2" });
            monAnList.Add(new MonAn() { Id = "4", Name = "Cá tay tượng chưng tương" ,IdCategory = "1"});
            monAnList.Add(new MonAn() { Id = "5", Name = "Cơm Chiên Dương Châu", IdCategory = "5" });
            monAnList.Add(new MonAn() { Id = "6", Name = "intel core  i9", IdCategory = "4" });

            LoadCategory();
            LoadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        void LoadCategory()
        {
            cbSearchCategory.DataSource = categoryList;
            cbSearchCategory.DisplayMember = "Name";
            
        }
        void LoadData()
        {
            dataGridView1.DataSource = (from m in monAnList
                                        from c in categoryList
                                        where m.IdCategory.Equals(c.Id)
                                        select new
                                        {
                                            ID = m.Id,
                                            Tên = m.Name,
                                            Category = c.Name
                                        }).ToList();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            TimKiem();
        }
        void TimKiem()
        {
            dataGridView1.DataSource = (from m in monAnList join c in categoryList on m.IdCategory equals c.Id

                                        where c.Name.Equals((cbSearchCategory.SelectedValue as Categoryy).Name)
                                        && string.IsNullOrEmpty(txtSearchName.Text) ? true : m.Name.Equals(txtSearchName.Text)
                                        select new
                                        {
                                            ID = m.Id,
                                            Tên = m.Name,
                                            Category = c.Name
                                        }).ToList();
        }
    }


    class Categoryy
    {
        private string id;
        private string name;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
    class MonAn
    {
        private string id;
        private string name;
        private string idCategory;
        public string Id { get => id; set => id = value; }
        public string IdCategory { get => idCategory; set => idCategory = value; }
        public string Name { get => name; set => name = value; }
    }
}
