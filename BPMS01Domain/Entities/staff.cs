namespace BPMS01Domain.Entities
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
            r_inspection_project_staff = new HashSet<r_inspection_project_staff>();
        }
        
        public Guid id { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required]
        public int no { get; set; }

        /// <summary>
        /// MD5���ܺ�����
        /// </summary>
        [Required]
        [StringLength(32)]
        public string password { get; set; }

        /// <summary>
        /// ְ������
        /// </summary>
        [Required]
        [StringLength(50)]
        public string name { get; set; }

        /// <summary>
        /// �Ա�
        /// </summary>
        public int gender { get; set; }

        /// <summary>
        /// �칫�绰
        /// </summary>
        [StringLength(15)]
        public string office_phone { get; set; }

        /// <summary>
        /// �ƶ��绰
        /// </summary>
        [Required]
        [StringLength(15)]
        public string mobile_phone { get; set; }

        /// <summary>
        /// ְλ
        /// </summary>
        public int position { get; set; }

        /// <summary>
        /// ְ��
        /// </summary>
        public int job_title { get; set; }

        /// <summary>
        /// ѧ��
        /// </summary>
        [Required]
        public int education { get; set; }

        /// <summary>
        /// ��ְʱ��
        /// </summary>
        public DateTime hiredate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contract> contract { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<r_inspection_project_staff> r_inspection_project_staff { get; set; }
    }
}
