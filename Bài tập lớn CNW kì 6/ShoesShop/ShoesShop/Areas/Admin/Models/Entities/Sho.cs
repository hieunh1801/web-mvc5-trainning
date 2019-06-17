namespace ShoesShop.Areas.Admin.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sho
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sho()
        {
            ShoesDetails = new HashSet<ShoesDetail>();
        }

        [Key]
        public int idShoes { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Column(TypeName = "ntext")]
        public string description { get; set; }

        [Column(TypeName = "ntext")]
        public string defaultUrlImage { get; set; }

        public int? idCategory { get; set; }

        public int? idVendor { get; set; }

        public double? price { get; set; }

        public virtual Category Category { get; set; }

        public virtual Vendor Vendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoesDetail> ShoesDetails { get; set; }
    }
}
