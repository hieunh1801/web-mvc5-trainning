using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShoesShop.Areas.Admin.Models.Entities;

namespace ShoesShop.Areas.Admin.Models.Functions
{
    public class SizeFunction
    {
        ShoesStoreDBContext context;
        public SizeFunction()
        {
            context = new ShoesStoreDBContext();
        }

        // 1: GetAll
        public List<Size> GetAll()
        {
            var list = context.Sizes.ToList();
            return list;
        }

        // 2: GetById
        public Size GetById(int idSize)
        {
            var entry = context.Sizes.Single(item => item.idSize == idSize);
            return entry;
        }

        // 3: Insert
        public bool Insert(Size size )
        {
            // Step 1: Check size exist
            var entry = context.Sizes.Single(item => item.idSize == size.idSize);
            if (entry != null) return false;

            // Step 2: Insert
            context.Sizes.Add(size);

            // Step 3: Synwith DB
            int result = context.SaveChanges();
            return result > 0;
        }

        // 4: Delete
        public bool Update(Size size)
        {
            // Step 1: Find it in database
            var entry = context.Sizes.Single(item => item.idSize == size.idSize);
            if (entry == null) return false;
            
            // Step 2: update
            entry.size1 = size.size1;
            
            // Step 3: sync
            int result = context.SaveChanges();
            return result > 0;
        }

        // 5: Delete
        public bool Delete(Size size)
        {
            // Step 1: Find in context
            var entry = context.Sizes.Single(item => item.idSize == size.idSize);
            if (entry == null) return false;

            // Step 2: Remove this in context
            context.Sizes.Remove(entry);

            // Step 3: Sync with database
            int result = context.SaveChanges();
            return result > 0;
        }
        // 6: Search

    }
}