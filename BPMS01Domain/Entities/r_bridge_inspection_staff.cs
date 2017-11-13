namespace BPMS01Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("r_bridge_inspection_staff")]
    public partial class r_bridge_inspection_staff
    {

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
        public bool is_response { get; set; }

        /// <summary>
        /// �ֳ�
        /// </summary>
        public bool scene_coff { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        public bool plan_coff { get; set; }

        /// <summary>
        /// ����׫д
        /// </summary>
        public bool report_coff { get; set; }

        /// <summary>
        /// ����У��
        /// </summary>
        public bool report_check_coff { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        public bool others_coff { get; set; }

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
