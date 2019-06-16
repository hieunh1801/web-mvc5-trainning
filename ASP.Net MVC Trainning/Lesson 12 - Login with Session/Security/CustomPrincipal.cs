using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using Lesson_12___Login_with_Session.Models;

namespace Lesson_12___Login_with_Session.Security
{
    public class CustomPrincipal
    {
        public IIdentity Identity
        {
            get;
            set;
        }

        private Account Account;

        public CustomPrincipal(Account Account)
        {
            this.Account = Account;
            this.Identity = new GenericIdentity(Account.Username);
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ',' });
            return roles.Any(r => this.Account.Roles.Contains(r));
        }
    }
}