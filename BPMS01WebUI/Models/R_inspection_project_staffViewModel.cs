﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public abstract class R_inspection_project_staffViewModel
    {

        [ScaffoldColumn(false)]    //using System.ComponentModel.DataAnnotations;
        public Guid id { get; set; }

        [ScaffoldColumn(false)]
        public Guid inspection_project_id { get; set; }
        //[ScaffoldColumn(false)]
        //public string inspection_project_name { get; set; }

        [ScaffoldColumn(false)]
        public Guid staff_id { get; set; }
        //[ScaffoldColumn(false)]
        //public string staff_name { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "产值比例")]
        public Nullable<double> production_value_ratio { get; set; }
        [ScaffoldColumn(false)]
        [Display(Name = "产值")]
        public Nullable<double> production_value { get; set; }

        [Display(Name = "项目负责")]
        [UIHint("EnumInt32")]
        public is_response is_response { get; set; }

        [Display(Name = "现场检测")]
        [UIHint("EnumInt32")]
        public scene_coff scene_coff { get; set; }

        [Display(Name = "方案制定")]
        [UIHint("EnumInt32")]
        public plan_coff plan_coff { get; set; }

        [Display(Name = "报告撰写")]
        [UIHint("EnumInt32")]
        public report_coff report_coff { get; set; }

        [Display(Name = "报告校核")]
        [UIHint("EnumInt32")]
        public report_check_coff report_check_coff { get; set; }

        [Display(Name = "其它")]
        [UIHint("EnumInt32")]
        public others_coff others_coff { get; set; }

    }

    public enum is_response
    {
        [Display(Name = "待定")]
        undetermined = 0,
        [Display(Name = "是")]
        yes = 1,
        [Display(Name = "否")]
        no = 2
    }
    public enum scene_coff
    {
        [Display(Name = "待定")]
        undetermined = 0,
        [Display(Name = "是")]
        yes = 1,
        [Display(Name = "否")]
        no = 2
    }
    public enum plan_coff
    {
        [Display(Name = "待定")]
        undetermined = 0,
        [Display(Name = "是")]
        yes = 1,
        [Display(Name = "否")]
        no = 2
    }
    public enum report_coff
    {
        [Display(Name = "待定")]
        undetermined = 0,
        [Display(Name = "是")]
        yes = 1,
        [Display(Name = "否")]
        no = 2
    }
    public enum report_check_coff
    {
        [Display(Name = "待定")]
        undetermined = 0,
        [Display(Name = "是")]
        yes = 1,
        [Display(Name = "否")]
        no = 2
    }
    public enum others_coff
    {
        [Display(Name = "待定")]
        undetermined = 0,
        [Display(Name = "是")]
        yes = 1,
        [Display(Name = "否")]
        no = 2
    }

}