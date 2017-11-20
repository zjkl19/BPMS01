namespace BPMS01Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_inspection_project_staff")]
    public partial class r_inspection_project_staff
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [ForeignKey("inspection_project")]
        public Guid inspection_project_id { get; set; }

        [Required]
        [ForeignKey("staff")]
        public Guid staff_id { get; set; }

        /// <summary>
        /// �Ƿ���
        /// </summary>
        public int is_response { get; set; }

        /// <summary>
        /// �ֳ�
        /// </summary>
        public int scene_coff { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public int plan_coff { get; set; }

        /// <summary>
        /// ����׫д
        /// </summary>
        public int report_coff { get; set; }

        /// <summary>
        /// ����У��
        /// </summary>
        public int report_check_coff { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public int others_coff { get; set; }

        /// <summary>
        /// ��ֵ����
        /// </summary>
        public double? production_value_ratio { get; set; }

        /// <summary>
        /// ��ֵ
        /// </summary>
        public double? production_value { get; set; }

        public virtual inspection_project inspection_project { get; set; }

        public virtual staff staff { get; set; }
    }
}
