using System;
using System.Collections.Generic;
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
    }
}