using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.Web.Mvc;

namespace BPMS01WebUI.Models
{
    public abstract class Inspection_projectViewModel
    {

        [ScaffoldColumn(false)]    //using System.ComponentModel.DataAnnotations;
        public Guid id { get; set; }

        [ScaffoldColumn(false)]
        public string contract_id { get; set; }
        //[ScaffoldColumn(false)]
        //public string contract_name { get; set; }

        [ScaffoldColumn(false)]
        public string bridge_id { get; set; }
        //[ScaffoldColumn(false)]
        //public string bridge_name { get; set; }

        //using System.Web.Mvc;
        //[HiddenInput]
        //public double bridge_length { get; set; }
        //[HiddenInput]
        //public double bridge_width { get; set; }
        //[HiddenInput]
        //public int bridge_structure_type { get; set; }

        [Display(Name = "项目名称")]
        public string name { get; set; }

        [Display(Name = "进场日期")]
        public Nullable<System.DateTime> enter_date { get; set; }
        [Display(Name = "退场日期")]
        public Nullable<System.DateTime> exit_date { get; set; }

        //参考AddBridgeViewModel
        [Display(Name = "桥梁检测类型")]
        [UIHint("EnumInt32")]
        public inspection_type inspection_type { get; set; }

        [Display(Name = "收费标准价格")]
        [ScaffoldColumn(false)]
        public decimal standard_price { get; set; }

    }
    public enum inspection_type
    {
        [Display(Name = "常规定期检测")]
        regularPeriod = 1,
        [Display(Name = "结构定期检测")]
        structurePeriod = 2,
        [Display(Name = "静力荷载试验")]
        staticLoad = 3,
        [Display(Name = "动力荷载试验")]
        dynamicLoad = 4
    }
}

