﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    class InfoConnect
    {
        public string ServerName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Database { get; internal set; }
    }
}
