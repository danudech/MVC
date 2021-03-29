using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPCoinMaster.Models
{
    public class MasterModels
    {
        public static string change { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Ref { get; set; }
        public string chkdata() {
            return null;
        }

        public string signup(DataClasses1DataContext DB) {
            var chkuser = from user in DB.wallets
                          where user.Name == UserName
                          select user;
            if (chkuser.Any()) {
                return "User is Avalible";
            }
            return "User is Avalible";
        }
    }
}