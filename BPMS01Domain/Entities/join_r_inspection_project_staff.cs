
//自定义“项目-职工” “扩展”模型
//添加了职工姓名、项目名称的显示
//是r_inspection_project_staff业务模型的扩展版
namespace BPMS01Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class join_r_inspection_project_staff
    {

        public Guid id { get; set; }
        public Guid inspection_project_id { get; set; }
        public string inspection_project_name { get; set; }   //add

        public Guid staff_id { get; set; }
        public int staff_no { get; set; }
        public string staff_name { get; set; }    //add

        public bool is_response { get; set; }
        public bool scene_coff { get; set; }
        public bool plan_coff { get; set; }
        public bool report_coff { get; set; }
        public bool report_check_coff { get; set; }
        public bool others_coff { get; set; }

        public Nullable<double> production_value_ratio { get; set; }
        public Nullable<double> production_value { get; set; }
    
    }
}
