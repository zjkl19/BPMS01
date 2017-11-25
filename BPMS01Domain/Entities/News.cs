namespace BPMS01Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("News")]
    public partial class News
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public News()
        {
            Category = new HashSet<Category>();
        }
        
        public Guid id { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required]
        public string title { get; set; }

        /// <summary>
        /// ����
        /// </summary>
        [Required]
        public string content { get; set; }

        /// <summary>
        /// Ŀ¼
        /// </summary>
        [Required]
        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }

        /// <summary>
        /// ������id
        /// </summary>
        [Required]
        public Guid PublisherId { get; set; }

        /// <summary>
        /// ����������
        /// </summary>
        [Required]
        public string PublisherName { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [Required]
        public DateTime PublisherDate { get; set; }

        /// <summary>
        /// �޸���id
        /// </summary>
        [Required]
        public Guid ModifierId { get; set; }

        /// <summary>
        /// �޸�������
        /// </summary>
        [Required]
        public string ModifierName { get; set; }

        /// <summary>
        /// �޸�����
        /// </summary>
        [Required]
        public DateTime ModifyDate { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> Category { get; set; }


    }
}
