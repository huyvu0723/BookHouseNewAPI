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

        public PackVip(int pvId, int bookDate, double pvCost)
        {
            this.pvId = pvId;
            this.bookDate = bookDate;
            this.pvCost = pvCost;
        }

        public int pvId { get; set; }
        public int bookDate { get; set; }
        public double pvCost { get; set; }
    }
}