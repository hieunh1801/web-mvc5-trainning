using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lesson_12___Login_with_Session.Models
{
    public class AccountModel
    {
        private List<Account> accounts = new List<Account>();

        public AccountModel()
        {
            accounts.Add(new Account { Username = "acc1", Password = "123", Roles = new string[] { "superadmin", "admin", "employee" } });
            accounts.Add(new Account { Username = "acc2", Password = "123", Roles = new string[] { "admin", "employee" } });
            accounts.Add(new Account { Username = "acc3", Password = "123", Roles = new string[] { "employee" } });
        }

        public Account find(string username)
        {
            return accounts.Single(acc => acc.Username.Equals(username));
        }

        public Account login(string username, string password)
        {
            return accounts.Where(acc => acc.Username.Equals(username) && acc.Password.Equals(password)).FirstOrDefault();
        }
    }
}