namespace ShoesShop.Areas.Admin.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ShoesStoreDBContext : DbContext
    {
        public ShoesStoreDBContext()
            : base("name=ShoesStoreDBContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Sho> Shoes { get; set; }
        public virtual DbSet<ShoesDetail> ShoesDetails { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
