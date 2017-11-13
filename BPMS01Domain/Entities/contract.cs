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
        /// ��ͬ���
        /// </summary>
        [Required]
        [StringLength(13)]
        public string no { get; set; }

        /// <summary>
        /// ��ͬ����
        /// </summary>
        [Required]
        [StringLength(100)]
        public string name { get; set; }

        /// <summary>
        /// ��ͬ���
        /// </summary>
        [Column(TypeName = "money")]
        public decimal amount { get; set; }

        /// <summary>
        /// ǩ������
        /// </summary>
        public DateTime signed_data { get; set; }

        /// <summary>
        /// ��ͬ����
        /// </summary>
        public long deadline { get; set; }

        /// <summary>
        /// Լ����������
        /// </summary>
        [StringLength(500)]
        public string agmt_wk_cnt { get; set; }

        /// <summary>
        /// ��Ŀ�ص�
        /// </summary>
        [StringLength(20)]
        public string project_location { get; set; }

        /// <summary>
        /// ί�е�λ
        /// </summary>
        [StringLength(50)]
        public string delegation_client { get; set; }

        /// <summary>
        /// ί�е�λ��ϵ��
        /// </summary>
        [StringLength(50)]
        public string dlg_contactperson { get; set; }

        /// <summary>
        /// ί�е�λ��ϵ����ϵ�绰
        /// </summary>
        [StringLength(13)]
        public string dlg_contactperson_phone { get; set; }

        /// <summary>
        /// �нӷ�ʽ
        /// </summary>
        public int accept_way { get; set; }

        /// <summary>
        /// ��λ�Ƿ�ǩ��
        /// </summary>
        public bool is_corporation_signed { get; set; }

        /// <summary>
        /// �ͻ��Ƿ�ǩ��
        /// </summary>
        public bool is_client_signed { get; set; }

        public virtual staff staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inspection_project> inspection_project { get; set; }
    }
}
