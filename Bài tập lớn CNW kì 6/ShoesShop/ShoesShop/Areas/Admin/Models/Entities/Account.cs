namespace ShoesShop.Areas.Admin.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Account()
        {
            Customers = new HashSet<Customer>();
        }

        [Key]
        public int idAccount { get; set; }

        [StringLength(50)]
        [Required]
        [MinLength(3)]
        [MaxLength(10)]
        public string userName { get; set; }

        [StringLength(50)]
        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string password { get; set; }

        [StringLength(20)]
        public string role { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
