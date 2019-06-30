using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesShop.Areas.Admin.Models.Entities;
using ShoesShop.Areas.Admin.Models.Functions;

namespace ShoesShop.Areas.Admin.Models.ViewModals
{
    public class AdminProductDetailModal
    {
        public List<Sho> ListShoes { get; set; }
        public List<ShoesDetail> ListShoesDetails { get; set; }
        
        public AdminProductDetailModal()
        {
            ShoesDetailFunction shoesDetailFunction = new ShoesDetailFunction();
            ShoesFunction shoesFunction = new ShoesFunction();
            ListShoes = shoesFunction.GetAll();
            ListShoesDetails = shoesDetailFunction.GetAll();
        }

    }
}