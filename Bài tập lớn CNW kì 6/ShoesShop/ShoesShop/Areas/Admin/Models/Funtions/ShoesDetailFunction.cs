using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Models.Functions
{
    public class ShoesDetailFunction
    {
        ShoesStoreDBContext context;
        public ShoesDetailFunction()
        {
            context = new ShoesStoreDBContext();
        }

        // 1: GetAll
        public List<ShoesDetail> GetAll()
        {
            var list = context.ShoesDetails.ToList();
            return list;
        }
        // 2: GetById
        public List<ShoesDetail> GetAllDetailById(int idShoes)
        {
            var entry = context.ShoesDetails.Where(item => item.idShoes == idShoes);
            return entry.ToList();
        }
        // 3: Insert
        public bool Insert(ShoesDetail shoesDetail) 
        {
            var entry = context.ShoesDetails.Single(item => item.idShoesDetail == shoesDetail.idShoesDetail);
            if (entry != null) return false;
            context.ShoesDetails.Add(shoesDetail);
            int result = context.SaveChanges();
            return result > 0;
        }
        // 4: Update
        public bool Update(ShoesDetail shoesDetail)
        {
            var entry = context.ShoesDetails.Single(item => item.idShoesDetail == shoesDetail.idShoesDetail);
            if (entry == null) return false;
            entry.idColor = shoesDetail.idColor;
            entry.idShoes = shoesDetail.idShoes;
            entry.idSize = shoesDetail.idSize;
            entry.quantity = shoesDetail.quantity;
            entry.urlImage = shoesDetail.urlImage;
            int result = context.SaveChanges();
            return result > 0;
        }
        // 5: Delete
        public bool Delete(ShoesDetail shoesDetail)
        {
            var entry = context.ShoesDetails.Single(item => item.idShoesDetail == shoesDetail.idShoesDetail);
            if (entry == null) return false;
            context.ShoesDetails.Remove(entry);
            int result = context.SaveChanges();
            return result > 0; 
        }
        // 6: Search
    }
}