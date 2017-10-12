using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public class AddStaffViewModel
    {
        [DisplayName("添加职工")]    //using System.ComponentModel;

        [ScaffoldColumn(false)]    //using System.ComponentModel.DataAnnotations;
        public string id { get; set; }

        [Display(Name = "工号")]
        public int staff_no { get; set; }

        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string staff_password { get; set; }

        [Display(Name = "姓名")]
        public string staff_name { get; set; }

        [Display(Name = "性别")]  
        [UIHint("Enum")]
        [ScaffoldColumn(false)]
        public gender gender { get; set; }

        [Display(Name = "办公电话")]
        public string office_phone { get; set; }

        [Display(Name = "移动电话")]
        public string mobile_phone { get; set; }

        [Display(Name = "职位")]
        public string position { get; set; }

        [Display(Name = "职称")]
        public string job_title { get; set; }

        [Display(Name = "学历")]
        public string education { get; set; }

        [Display(Name = "入职时间")]
        public DateTime hiredate { get; set; }
    }
    public enum gender
    {
        [Display(Name = "未知")]
        unknown =0,
        [Display(Name = "男")]
        male =1,
        [Display(Name = "女")]
        female =2
    }
}