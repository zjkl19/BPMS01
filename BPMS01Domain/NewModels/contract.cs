namespace BPMS01Domain.NewModels
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

        [StringLength(32)]
        public string id { get; set; }

        [Required]
        [StringLength(32)]
        public string staff_id { get; set; }

        [Required]
        [StringLength(13)]
        public string contract_no { get; set; }

        [Required]
        [StringLength(100)]
        public string contract_name { get; set; }

        [Column(TypeName = "money")]
        public decimal contract_amount { get; set; }

        public DateTime contract_signed_data { get; set; }

        public long contract_deadline { get; set; }

        [StringLength(500)]
        public string contract_agmt_wk_cnt { get; set; }

        [StringLength(20)]
        public string project_location { get; set; }

        [StringLength(50)]
        public string delegation_client { get; set; }

        [StringLength(50)]
        public string dlg_contactperson { get; set; }

        [StringLength(13)]
        public string dlg_contactperson_phone { get; set; }

        [StringLength(10)]
        public string accept_way { get; set; }

        public bool is_corporation_signed { get; set; }

        public bool is_client_signed { get; set; }

        public virtual staff staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<inspection_project> inspection_project { get; set; }
    }
}
