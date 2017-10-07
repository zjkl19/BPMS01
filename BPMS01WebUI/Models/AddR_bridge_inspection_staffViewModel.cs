using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public class AddR_bridge_inspection_staffViewModel
    {
        [DisplayName("添加职工参与信息")]    //using System.ComponentModel;

        [ScaffoldColumn(false)]    //using System.ComponentModel.DataAnnotations;
        public string id { get; set; }

        [ScaffoldColumn(false)]
        public string inspection_project_id { get; set; }
        [ScaffoldColumn(false)]
        public string inspection_project_name { get; set; }

        [ScaffoldColumn(false)]
        public string staff_id { get; set; }
        [ScaffoldColumn(false)]
        public string staff_name { get; set; }

        [Display(Name = "产值比例")]
        public Nullable<double> production_value_ratio { get; set; }
        [Display(Name = "产值")]
        public Nullable<double> production_value { get; set; }

        [Display(Name = "项目负责")]
        [ScaffoldColumn(false)]
        public bool is_response { get; set; }
        [Display(Name = "现场检测")]
        [ScaffoldColumn(false)]
        public bool scene_coff { get; set; }
        [Display(Name = "方案制定")]
        [ScaffoldColumn(false)]
        public bool plan_coff { get; set; }
        [Display(Name = "报告撰写")]
        [ScaffoldColumn(false)]
        public bool report_coff { get; set; }
        [Display(Name = "报告校核")]
        [ScaffoldColumn(false)]
        public bool report_check_coff { get; set; }
        [Display(Name = "其它")]
        [ScaffoldColumn(false)]
        public bool others_coff { get; set; }

    }
}