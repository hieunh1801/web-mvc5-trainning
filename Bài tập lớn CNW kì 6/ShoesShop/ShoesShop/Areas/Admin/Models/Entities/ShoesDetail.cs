namespace ShoesShop.Areas.Admin.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoesDetail")]
    public partial class ShoesDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShoesDetail()
        {
            Carts = new HashSet<Cart>();
        }

        [Key]
        public int idShoesDetail { get; set; }

        public int? idColor { get; set; }

        public int? idShoes { get; set; }

        public int? idSize { get; set; }

        public int? quantity { get; set; }

        [Column(TypeName = "ntext")]
        public string urlImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cart> Carts { get; set; }

        public virtual Color Color { get; set; }

        public virtual Sho Sho { get; set; }

        public virtual Size Size { get; set; }
    }
}
