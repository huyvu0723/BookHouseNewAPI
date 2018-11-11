using System;
using System.Web;

namespace BookHouseNewAPI.Models
{
    public class Bookcase
    {
        public Bookcase()
        {
        }

        public Bookcase(int bookId, int accId, int bookMark, string autName, string bookImage, string bookLink, string name, double rate, string bookDescription, int countDownload)
        {
            this.bookId = bookId;
            this.accId = accId;
            this.bookMark = bookMark;
            this.autName = autName;
            this.bookImage = bookImage;
            this.bookLink = bookLink;
            this.name = name;
            this.rate = rate;
            this.bookDescription = bookDescription;
            this.countDownload = countDownload;
        }

        public int bookId { get; set; }
        public int accId { get; set; }
        public int bookMark { get; set; }
        public String autName { get; set; }
        public String bookImage { get; set; }
        public String bookLink { get; set; }
        public String name { get; set; }
        public double rate { get; set; }
        public String bookDescription { get; set; }
        public int countDownload { get; set; }


    }
}
