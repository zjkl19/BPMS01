namespace BPMS01Domain.Entities
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

        public Guid id { get; set; }

        /// <summary>
        /// 桥梁名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string name { get; set; }

        /// <summary>
        /// 桥梁长度
        /// </summary>
        [Required]
        public double length { get; set; }

        /// <summary>
        /// 桥梁宽度
        /// </summary>
        [Required]
        public double width { get; set; }

        /// <summary>
        /// 结构形式
        /// </summary>
        [Required]
        public int structure_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inspection_project> inspection_project { get; set; }
    }
}
