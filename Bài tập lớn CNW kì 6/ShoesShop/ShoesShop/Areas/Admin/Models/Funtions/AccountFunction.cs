using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Models.Functions
{
    public class AccountFunction
    {
        ShoesStoreDBContext context = new ShoesStoreDBContext();
        public List<Account> GetAll()
        {
            List<Account> list = new List<Account>();
            var list1 = context.Vendors.SqlQuery("").ToList<Vendor>();
            return list;
        }

        /// <summary>
        /// Check account if it exist in Database.
        /// </summary>
        /// <param name="account"></param>
        /// <returns>if exist return true else return false</returns>
        public bool isExistAccount(Account account )
        {
            var entry = context.Accounts.Single(item => item.password == account.password && item.userName == account.userName);
            if (entry != null) return true;
            return false;
        }
        
        /// <summary>
        /// Get account from datbase
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>account if exist, null if not found</returns>
        public Account getAccountByUserNameAndPassword(string username, string password)
        {
            var entry = context.Accounts.Where(item => item.password == password && item.userName == username).FirstOrDefault<Account>(); ;
            if (entry != null) return entry;
            return null;
        }
    }
}