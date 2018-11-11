using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHouseNewAPI.Models
{
    public class Category
    {
        public Category()
        {
        }
        public Category(int catId, string catName, string catParent)
        {
            this.catId = catId;
            this.catName = catName;
            this.catParent = catParent;
        }

        public int catId { get; set; }
        public string catName { get; set; }
        public string catParent { get; set; }
    }
}