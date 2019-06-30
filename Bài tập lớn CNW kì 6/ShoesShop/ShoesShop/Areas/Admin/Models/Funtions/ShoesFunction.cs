using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            //var entry = context.Shoes.Single(item => item.idShoes == shoes.idShoes);
            //if (entry != null) return false;
            //context.Shoes.Add(shoes);
            //int result = context.SaveChanges();
            //return result > 0;
            try
            {
                var parameters = new[] {
                new SqlParameter {ParameterName = "name", Value = shoes.name },
                new SqlParameter {ParameterName = "description", Value = shoes.description },
                new SqlParameter {ParameterName = "defaultUrlImage", Value = shoes.defaultUrlImage },
                new SqlParameter {ParameterName = "idCategory", Value = shoes.idCategory },
                new SqlParameter {ParameterName = "idVendor", Value = shoes.idVendor },
                new SqlParameter {ParameterName = "price", Value = shoes.price },
                };
                var rowsEffect = context.Database.ExecuteSqlCommand("SP_Shoes_Insert @name , @description , @defaultUrlImage ,  @idCategory , @idVendor , @price", parameters);
                return rowsEffect > 0;
            } catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
               
          
        }

        // 4: Update
        public bool Update(Sho shoes)
        {
            var entry = context.Shoes.Single(item => item.idShoes == shoes.idShoes);
            if (entry == null) return false;
            entry.idCategory = shoes.idCategory;
            if(shoes.defaultUrlImage != null)
            {
                entry.defaultUrlImage = shoes.defaultUrlImage;
            }
            entry.idVendor = shoes.idVendor;
            entry.name = shoes.name;
            entry.price = shoes.price;

            int result = context.SaveChanges();
            return result > 0;
        }

        // 5: Delete
        public bool Delete(int idShoes)
        {
            //var entry = context.Shoes.Single(item => item.idShoes == idShoes);
            //if (entry == null) return false;
            //context.Shoes.Remove(entry);
            //int result = context.SaveChanges();
            var parameters = new[]
            {
                new SqlParameter {ParameterName = "idShoes", Value = idShoes },
            };

            var data = context.Database.ExecuteSqlCommand("SP_Shoes_Delete @idShoes", parameters);
            
            return data > 0;
        }

        // 6: Search
        public List<Sho> Search(string searchValue)
        {
            /* Step 1: Find entry in context by using Where()*/// = context.Vendors.Where(item => (item.idVendor.ToString() == searchValue));
            var parameters = new[]
            {
                new SqlParameter {ParameterName = "searchValue", Value = searchValue },
            };

            var data = context.Shoes.SqlQuery("SP_Shoe_Search @searchValue", parameters).ToList();
            return data;
        }
    }
}