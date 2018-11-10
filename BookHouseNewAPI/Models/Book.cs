using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHouseNewAPI.Models
{
    public class Book
    {
        public Book()
        {
        }
        public Book(int publisherpubId, int authorautId, int bookId, string bookName, string bookDescription, string bookImage, string bookLink, int isVip, DateTime datePublish, string autName)
        {
            PublisherpubId = publisherpubId;
            AuthorautId = authorautId;
            this.bookId = bookId;
            this.bookName = bookName;
            this.bookDescription = bookDescription;
            this.bookImage = bookImage;
            this.bookLink = bookLink;
            this.isVip = isVip;
            this.datePublish = datePublish;
            this.autName = autName;
        }

        public int PublisherpubId { get; set; }
        public int AuthorautId { get; set; }
        public int bookId { get; set; }
        public string bookName { get; set; }
        public string bookDescription { get; set; }
        public string bookImage { get; set; }
        public string bookLink { get; set; }
        public int isVip { get; set; }
        public DateTime datePublish { get; set; }
        public string autName { get; set; }
    }
}