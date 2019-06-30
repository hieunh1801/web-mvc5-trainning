using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
        public ShoesDetail GetById(int idShoesDetail)
        {
            var entry = context.ShoesDetails.Single(item => item.idShoesDetail == idShoesDetail);
            return entry;
        }        
        // 3: Insert
        public bool Insert(ShoesDetail shoesDetail) 
        {
            //var entry = context.ShoesDetails.Single(item => item.idShoesDetail == shoesDetail.idShoesDetail);
            //if (entry != null) return false;
            //context.ShoesDetails.Add(shoesDetail);
            //int result = context.SaveChanges();
            //return result > 0;
            try
            {
                var parameters = new[] {
                new SqlParameter {ParameterName = "idShoes", Value = shoesDetail.idShoes },
                new SqlParameter {ParameterName = "idColor", Value = shoesDetail.idColor },
                new SqlParameter {ParameterName = "idSize", Value = shoesDetail.idSize },
                new SqlParameter {ParameterName = "quantity", Value = shoesDetail.quantity },
                new SqlParameter {ParameterName = "urlImage", Value = shoesDetail.urlImage },
                };
                var rowsEffect = context.Database.ExecuteSqlCommand("SP_ShoesDetail_Insert @idShoes , @idColor , @idSize ,  @quantity , @urlImage ", parameters);
                return rowsEffect > 0;
            }
            catch (Exception err)
            {
                Console.WriteLine(err);
                return false;
            }
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
            if(shoesDetail.urlImage != null)
            {
                entry.urlImage = shoesDetail.urlImage;
            }
            int result = context.SaveChanges();


            return result > 0;
        }
        // 5: Delete
        public bool Delete(int idShoesDetail)
        {
            //var entry = context.ShoesDetails.Single(item => item.idShoesDetail == shoesDetail.idShoesDetail);
            //if (entry == null) return false;
            //context.ShoesDetails.Remove(entry);
            //int result = context.SaveChanges();
            //return result > 0; 
            var parameters = new[]
           {
                new SqlParameter {ParameterName = "idShoesDetail", Value = idShoesDetail },
            };

            var data = context.Database.ExecuteSqlCommand("SP_ShoesDetail_Delete @idShoesDetail", parameters);

            return data > 0;
        }
        // 6: Search
        public List<ShoesDetail> Search(string searchValue)
        {
            /* Step 1: Find entry in context by using Where()*/// = context.Vendors.Where(item => (item.idVendor.ToString() == searchValue));
            var parameters = new[]
            {
                new SqlParameter {ParameterName = "searchValue", Value = searchValue },
            };

            var data = context.ShoesDetails.SqlQuery("SP_ShoesDetail_Search @searchValue", parameters).ToList();
            return data;
        }
    }
}