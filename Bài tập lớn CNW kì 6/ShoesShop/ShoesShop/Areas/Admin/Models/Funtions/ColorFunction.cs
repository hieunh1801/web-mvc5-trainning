using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Models.Functions
{
    public class ColorFunction
    {
        ShoesStoreDBContext context = new ShoesStoreDBContext();

        public List<Color> GetAll()
        {
            var list = context.Colors.ToList();
            return list;
        }

        public List<Color> GetColorsById(int idColor)
        {
            var list = context.Colors.Where(item => item.idColor == idColor);
            return list.ToList();
        }

        public bool Insert (Color color)
        {
            return true;
        }
        // 6. Search
        public List<Color> Search(string searchValue)
        {
            /* Step 1: Find entry in context by using Where()*/// = context.Vendors.Where(item => (item.idVendor.ToString() == searchValue));
            var parameters = new[]
            {
                new SqlParameter {ParameterName = "searchValue", Value = searchValue },
            };

            var data = context.Colors.SqlQuery("SP_Color_Search @searchValue", parameters).ToList();
            return data;
        }
    }
}