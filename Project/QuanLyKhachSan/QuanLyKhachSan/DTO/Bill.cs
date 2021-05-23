﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan.DTO
{
    public class Bill
    {
        public Bill(int id ,DateTime? dateCheckin, DateTime? dateCheckOut, int status,int discount)
        {
            this.ID = id;
            this.dateCheckIn = dateCheckin;
            this.dateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount = discount;

           

        }
        public Bill(DataRow row )
        {
            this.ID = (int)row["id"];
            this.dateCheckIn = (DateTime?)row["DateCheckIn"];
            var dateCheckOutTemp = row["DateCheckOut"];
            if(dateCheckOutTemp.ToString() != "")
                this.dateCheckOut = (DateTime?)dateCheckOutTemp;
            this.Status = (int)row["status"];
            if(row["discount"].ToString() != "")
                this.Discount = (int)row["discount"];
        }

        private int discount;
        public int Discount 
        {
            get { return discount; }
            set { discount = value; }
        }

        private int status;
        public int Status
        {
            get { return status; }
            set { status = value; }
        }
        private DateTime? dateCheckOut;
        public DateTime? DateCheckOut
        {
            get { return dateCheckOut; }
            set { dateCheckOut = value; }
        }

        private DateTime? dateCheckIn;
        public DateTime? DateCheckIn
        {
            get { return dateCheckIn; }
            set { dateCheckIn = value; }
        }


        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }

 
    }
}
