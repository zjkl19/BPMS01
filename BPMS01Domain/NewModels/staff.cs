namespace BPMS01Domain.NewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("staff")]
    public partial class staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public staff()
        {
            contract = new HashSet<contract>();
            r_bridge_inspection_staff = new HashSet<r_bridge_inspection_staff>();
        }
        
        [StringLength(32)]
        public Guid id { get; set; }
        //public string id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal staff_no { get; set; }

        [Required]
        [StringLength(32)]
        public string staff_password { get; set; }

        [Required]
        [StringLength(50)]
        public string staff_name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal gender { get; set; }

        [StringLength(15)]
        public string office_phone { get; set; }

        [Required]
        [StringLength(15)]
        public string mobile_phone { get; set; }

        [StringLength(10)]
        public string position { get; set; }

        [StringLength(10)]
        public string job_title { get; set; }

        [Required]
        [StringLength(10)]
        public string education { get; set; }

        public DateTime hiredate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contract> contract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<r_bridge_inspection_staff> r_bridge_inspection_staff { get; set; }
    }
}
