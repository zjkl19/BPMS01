namespace BPMS01Domain.NewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class r_bridge_inspection_staff
    {
        [StringLength(32)]
        public string id { get; set; }

        [Required]
        [StringLength(32)]
        public string inspection_project_id { get; set; }

        [Required]
        [StringLength(32)]
        public string staff_id { get; set; }

        public bool is_response { get; set; }

        public bool scene_coff { get; set; }

        public bool plan_coff { get; set; }

        public bool report_coff { get; set; }

        public bool report_check_coff { get; set; }

        public bool others_coff { get; set; }

        public double? production_value_ratio { get; set; }

        public double? production_value { get; set; }

        public virtual inspection_project inspection_project { get; set; }

        public virtual staff staff { get; set; }
    }
}
