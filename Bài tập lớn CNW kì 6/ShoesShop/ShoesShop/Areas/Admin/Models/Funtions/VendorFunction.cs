using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Models.Functions
{
    public class VendorFunction
    {
        ShoesStoreDBContext context;

        public VendorFunction()
        {
            context = new ShoesStoreDBContext();
        }

        public List<Vendor> GetAll()
        {
            var list = context.Vendors.ToList();
            return list;
        }

        public Vendor GetByID(int id)
        {
            Vendor item = new Vendor();
            item = context.Vendors.Find(id);
            return item;
        }

        public Vendor GetByString(string strValue)
        {
            Vendor item = new Vendor();
            return item;
        }

        public bool Insert(Vendor vendor)
        {
            /* Step 1: Check if vendor exist */
            Vendor entry = context.Vendors.Find(vendor.idVendor);
            if (entry != null) return false;

            /* Step 2: Add to context */
            context.Vendors.Add(vendor);

            /* Step 3: Sync context with database */
            int result = context.SaveChanges();
            return result > 0;
        }

        public bool Delete(Vendor vendor)
        {
            /* Step 1: Find entry in context */
            Vendor entry = context.Vendors.Find(vendor.idVendor);
            if (entry == null) return false;

            /* Step 2: Remove this entry in context */
            context.Vendors.Remove(entry);

            /* Step 3: Sync context with database */
            int result = context.SaveChanges();
            return result > 0;
        }
        
        public bool Update(Vendor vendor)
        {
            /* Step 1: Find entry in context by using Single()*/
            Vendor entry = context.Vendors.Single(item => item.idVendor == vendor.idVendor);
            
            /* Step 2: Update this entry in context */
            entry.name = vendor.name;
            entry.address = vendor.address;
            entry.phoneNumber = vendor.phoneNumber;

            int result = context.SaveChanges();
            return result > 0;
        }

        public List<Vendor> Search(string searchValue)
        {
            /* Step 1: Find entry in context by using Where()*/// = context.Vendors.Where(item => (item.idVendor.ToString() == searchValue));
            HashSet<Vendor> list = new HashSet<Vendor>();
            foreach(string str in searchValue.Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries))
            {
                foreach (Vendor v in context.Vendors.Where(vd => vd.ToString().Contains(str)))
                    list.Add(v);
            }
            return list.ToList();
        }

    }
}