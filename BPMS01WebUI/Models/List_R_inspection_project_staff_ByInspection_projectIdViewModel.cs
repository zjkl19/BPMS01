using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public class List_R_inspection_project_staff_ByInspection_projectIdViewModel:R_inspection_project_staffViewModel
    {
        /// <summary>
        /// 工号
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "工号")]
        public int staff_no { get; set; }
        /// <summary>
        /// 职工姓名
        /// </summary>
        [ScaffoldColumn(false)]
        [Display(Name = "姓名")]
        public string staff_name { get; set; }
    }
}