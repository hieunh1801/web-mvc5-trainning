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
    }
}