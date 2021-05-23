﻿using System;
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
    public partial class fScreen : Form
    {
        public fScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.Opacity >0.0)
            {
                this.Opacity -= 0.05;
            }
            else
            {
                timer1.Stop();
                fLogin f = new fLogin();
                f.ShowDialog();
            }
        }

        private void fScreen_Load(object sender, EventArgs e)
        {
            timer1.Start(); 
        }
    }
}
