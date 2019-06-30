using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Models.Functions
{
    public class CategoryFunction
    {
        ShoesStoreDBContext context;
        public CategoryFunction()
        {
            context = new ShoesStoreDBContext();
        }

        // 1: GetAll
        public List<Category> GetAll()
        {
            var list = context.Categories.ToList();
            return list;
        }

        // 2: GetById
        public Category GetById(int idCategory)
        {
            var entry = context.Categories.Single(item => item.idCategory == idCategory);
            return entry;
        }

        // 3: Insert
        public bool Insert(Category category)
        {
            var entry = context.Categories.Single(item => item.idCategory == category.idCategory);
            if (entry != null) return false;
            context.Categories.Add(category);
            int result = context.SaveChanges();
            return result > 0;
        }

        // 4: Update
        public bool Update(Category category)
        {
            var entry = context.Categories.Single(item => item.idCategory == category.idCategory);
            if (entry == null) return false;
            entry.name = category.name;
            entry.urlImage = category.urlImage;
            int result = context.SaveChanges();
            return result > 0;
        }

        // 5: Delete
        public bool Delete(Category category)
        {
            var entry = context.Categories.Single(item => item.idCategory == category.idCategory);
            if (entry == null) return false;
            context.Categories.Remove(entry);
            int result = context.SaveChanges();
            return result > 0;
        }
        // 6: Search
        public List<Category> Search(string searchValue)
        {
            /* Step 1: Find entry in context by using Where()*/// = context.Vendors.Where(item => (item.idVendor.ToString() == searchValue));
            var parameters = new[]
            {
                new SqlParameter {ParameterName = "searchValue", Value = searchValue },
            };

            var data = context.Categories.SqlQuery("SP_Category_Search @searchValue", parameters).ToList();
            return data;
        }
    }
}