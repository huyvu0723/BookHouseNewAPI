using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHouseNewAPI.Models
{
    public class Author
    {
        public Author()
        {
        }
        public Author(int autId, string autName, string autAvatar, DateTime autBirth)
        {
            this.autId = autId;
            this.autName = autName;
            this.autAvatar = autAvatar;
            this.autBirth = autBirth;
        }

        public int autId { get; set; }
        public string autName { get; set; }
        public string autAvatar { get; set; }
        public DateTime autBirth { get; set; }
    }
}