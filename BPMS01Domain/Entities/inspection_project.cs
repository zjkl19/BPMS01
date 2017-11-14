namespace BPMS01Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("inspection_project")]
    public partial class inspection_project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public inspection_project()
        {
            r_inspection_project_staff = new HashSet<r_inspection_project_staff>();
        }

        public Guid id { get; set; }

        [Required]
        [ForeignKey("contract")]
        public Guid contract_id { get; set; }

        [Required]
        [ForeignKey("bridge")]
        public Guid bridge_id { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        /// <summary>
        /// 进场日期
        /// </summary>
        public DateTime? enter_date { get; set; }

        /// <summary>
        /// 退场日期
        /// </summary>
        public DateTime? exit_date { get; set; }

        /// <summary>
        /// 检测类型
        /// </summary>
        public int inspection_type { get; set; }

        /// <summary>
        /// 收费标准价格
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? standard_price { get; set; }

        public virtual bridge bridge { get; set; }

        public virtual contract contract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<r_inspection_project_staff> r_inspection_project_staff { get; set; }
    }
}
