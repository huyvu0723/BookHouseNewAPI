using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookHouseNewAPI.Models
{
    public class Account
    {
        public Account()
        {
        }
        public Account(int accId, string accUsername, string accPassword, string accFullname, decimal accWallet, DateTime accDateEndVip, string accRole)
        {
            this.accId = accId;
            this.accUsername = accUsername;
            this.accPassword = accPassword;
            this.accFullname = accFullname;
            this.accWallet = accWallet;
            this.accDateEndVip = accDateEndVip;
            this.accRole = accRole;
        }

        public int accId { get; set; }
        public string accUsername { get; set; }
        public string accPassword { get; set; }
        public string accFullname { get; set; }
        public decimal accWallet { get; set; }
        public DateTime accDateEndVip { get; set; }
        public string accRole { get; set; }
    }
}