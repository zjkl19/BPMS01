using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public class AddBridgeViewModel
    {
        [DisplayName("添加桥梁名")]    //using System.ComponentModel;

        [ScaffoldColumn(false)]    //using System.ComponentModel.DataAnnotations;
        public string id { get; set; }

        [Display(Name="桥梁名称")]
        public string name { get; set; }

        [Display(Name = "桥梁总长")]
        public double length { get; set; }

        [Display(Name = "桥梁宽度")]
        public double width { get; set; }


        //[Display(Name = "结构类型"), EnumDataType(typeof(Type))]
        //[UIHint("Enum")]
        //public structure_type structure_type { get; set; }
        [ScaffoldColumn(false)]
        public decimal structure_type { get; set; }


    }
    /*
    //依据桥梁检测收费标准制定    
    public enum structure_type
    {
        //下划线表示“或”
        SimpleSupportedBeam = 1,   //简支梁、板桥
        Arch = 2,    //石拱桥、圬工拱桥
        Continous_Rigid_Beam = 3,    //连续梁桥、连续刚构桥
        CFST_RC = 4,    //钢管混凝土拱桥、钢筋混凝土拱桥
        Suspension_CableStayed = 5    //悬索桥、斜拉桥
    }
    */

}