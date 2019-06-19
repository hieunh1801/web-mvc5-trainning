using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Security
{
    public class CustomAdminPrincipal : IPrincipal
    {
        public IIdentity Identity
        {
            get;
            set;
        }

        private Account Account;

        public CustomAdminPrincipal(Account Account)
        {
            this.Account = Account;
            this.Identity = new GenericIdentity(Account.userName);
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.role.Contains(r));
        }
    }
}