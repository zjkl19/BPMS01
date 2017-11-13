namespace BPMS01Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("contract")]
    public partial class contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public contract()
        {
            inspection_project = new HashSet<inspection_project>();
        }

        public Guid id { get; set; }

        [Required]
        [ForeignKey("staff")]
        public Guid staff_id { get; set; }

        /// <summary>
        /// 合同编号
        /// </summary>
        [Required]
        [StringLength(13)]
        public string no { get; set; }

        /// <summary>
        /// 合同名称
        /// </summary>
        [Required]
        [StringLength(100)]
        public string name { get; set; }

        /// <summary>
        /// 合同金额
        /// </summary>
        [Column(TypeName = "money")]
        public decimal amount { get; set; }

        /// <summary>
        /// 签订日期
        /// </summary>
        public DateTime signed_data { get; set; }

        /// <summary>
        /// 合同期限
        /// </summary>
        public long deadline { get; set; }

        /// <summary>
        /// 约定工作内容
        /// </summary>
        [StringLength(500)]
        public string agmt_wk_cnt { get; set; }

        /// <summary>
        /// 项目地点
        /// </summary>
        [StringLength(20)]
        public string project_location { get; set; }

        /// <summary>
        /// 委托单位
        /// </summary>
        [StringLength(50)]
        public string delegation_client { get; set; }

        /// <summary>
        /// 委托单位联系人
        /// </summary>
        [StringLength(50)]
        public string dlg_contactperson { get; set; }

        /// <summary>
        /// 委托单位联系人联系电话
        /// </summary>
        [StringLength(13)]
        public string dlg_contactperson_phone { get; set; }

        /// <summary>
        /// 承接方式
        /// </summary>
        public int accept_way { get; set; }

        /// <summary>
        /// 单位是否签订
        /// </summary>
        public bool is_corporation_signed { get; set; }

        /// <summary>
        /// 客户是否签订
        /// </summary>
        public bool is_client_signed { get; set; }

        public virtual staff staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inspection_project> inspection_project { get; set; }
    }
}
