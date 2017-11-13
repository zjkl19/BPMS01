namespace BPMS01Domain.NewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("bridge")]
    public partial class bridge
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bridge()
        {
            inspection_project = new HashSet<inspection_project>();
        }

        [StringLength(32)]
        public string id { get; set; }

        [Required]
        [StringLength(100)]
        public string name { get; set; }

        public double length { get; set; }

        public double width { get; set; }

        [Column(TypeName = "numeric")]
        public decimal structure_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inspection_project> inspection_project { get; set; }
    }
}
