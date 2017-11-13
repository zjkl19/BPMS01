namespace BPMS01Domain.NewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class inspection_project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inspection_project()
        {
            r_bridge_inspection_staff = new HashSet<r_bridge_inspection_staff>();
        }

        [StringLength(32)]
        public string id { get; set; }

        [StringLength(32)]
        public string contract_id { get; set; }

        [StringLength(32)]
        public string bridge_id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public DateTime? enter_date { get; set; }

        public DateTime? exit_date { get; set; }

        [Column(TypeName = "numeric")]
        public decimal bridge_inspection { get; set; }

        [Column(TypeName = "money")]
        public decimal? standard_price { get; set; }

        public virtual bridge bridge { get; set; }

        public virtual contract contract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<r_bridge_inspection_staff> r_bridge_inspection_staff { get; set; }
    }
}
