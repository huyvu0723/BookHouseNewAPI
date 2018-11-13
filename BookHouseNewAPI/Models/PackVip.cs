using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHouseNewAPI.Models
{
    public class PackVip
    {
        public PackVip()
        {
        }
        public PackVip(int pvid, int bookdate, decimal pvcost)
        {
            this.pvid = pvid;
            this.bookdate = bookdate;
            this.pvcost = pvcost;
        }

        public int pvid { get; set; }
        public int bookdate { get; set; }
        public decimal pvcost { get; set; }
    }
}