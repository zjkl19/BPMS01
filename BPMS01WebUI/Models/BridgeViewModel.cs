using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public abstract class BridgeViewModel
    {

        [ScaffoldColumn(false)]    //using System.ComponentModel.DataAnnotations;
        public string id { get; set; }

        [Display(Name="桥梁名称")]
        public string name { get; set; }

        [Display(Name = "桥梁总长")]
        public double length { get; set; }

        [Display(Name = "桥梁宽度")]
        public double width { get; set; }

        [Display(Name = "桥梁跨数")]
        public int span_number { get; set; }


        //[Display(Name = "结构类型"), EnumDataType(typeof(Type))]
        //[UIHint("Enum")]
        //public structure_type structure_type { get; set; }
        [Display(Name = "结构类型")]
        [UIHint("EnumInt32")]
        public structure_type structure_type { get; set; }


    }

    public enum structure_type
    {
        [Display(Name = "简支梁、板桥")]
        SimpleSupportedBeam = 1,
        [Display(Name = "石拱桥、圬工拱桥")]
        Arch = 2,
        [Display(Name = "连续梁桥、连续刚构桥")]
        Continous_Rigid_Beam = 3,
        [Display(Name = "钢管混凝土拱桥、钢筋混凝土拱桥")]
        CFST_RC = 4,
        [Display(Name = "悬索桥、斜拉桥")]
        Suspension_CableStayed = 5,
    }

}