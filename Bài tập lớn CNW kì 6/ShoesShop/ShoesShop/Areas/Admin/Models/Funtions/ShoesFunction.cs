﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Models.Functions
{
    public class ShoesFunction
    {
        ShoesStoreDBContext context;
        public ShoesFunction()
        {
            context = new ShoesStoreDBContext();
        }

        // 1: GetAll
        public List<Sho> GetAll()
        {
            var list = context.Shoes.ToList();
            return list;
        }

        // 2: GetById
        public Sho GetById(int idShoes)
        {
            var shoes = context.Shoes.Single(item => item.idShoes == idShoes);
            return shoes;
        }

        // 3: Insert
        public bool Insert(Sho shoes)
        {
            var entry = context.Shoes.Single(item => item.idShoes == shoes.idShoes);
            if (entry != null) return false;
            context.Shoes.Add(shoes);
            int result = context.SaveChanges();
            return result > 0;
        }

        // 4: Update
        public bool Update(Sho shoes)
        {
            var entry = context.Shoes.Single(item => item.idShoes == shoes.idShoes);
            if (entry == null) return false;
            entry.idCategory = shoes.idCategory;
            entry.idVendor = shoes.idVendor;
            entry.name = shoes.name;
            entry.price = shoes.price;

            int result = context.SaveChanges();
            return result > 0;
        }

        // 5: Delete
        public bool Delete(Sho shoes)
        {
            var entry = context.Shoes.Single(item => item.idShoes == shoes.idShoes);
            if (entry == null) return false;
            context.Shoes.Remove(entry);
            int result = context.SaveChanges();
            return result > 0;
        }

        // 6: Search
    }
}