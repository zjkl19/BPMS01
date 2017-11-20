using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public class AddR_inspection_project_staffViewModel:R_inspection_project_staffViewModel
    {
        //[DisplayName("添加职工参与信息")]    //using System.ComponentModel;

        [ScaffoldColumn(false)]
        public Guid inspection_project_id { get; set; }
        [ScaffoldColumn(false)]
        public string inspection_project_name { get; set; }   //add

        [ScaffoldColumn(false)]
        public Guid staff_id { get; set; }
        [ScaffoldColumn(false)]
        public string staff_name { get; set; }   //add

        //[ScaffoldColumn(false)]
        //public Nullable<double> production_value_ratio { get; set; }



    }
}