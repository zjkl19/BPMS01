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
        [DataType(DataType.Text)]
        public int staff_no { get; set; }

        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string staff_password { get; set; }

        [Display(Name = "姓名")]
        [DataType(DataType.Text)]
        public string staff_name { get; set; }

        [Display(Name = "性别")]  
        [UIHint("EnumInt32")]
        public gender gender { get; set; }

        [Display(Name = "办公电话")]
        [DataType(DataType.PhoneNumber)]
        public string office_phone { get; set; }

        [Display(Name = "移动电话")]
        [DataType(DataType.PhoneNumber)]
        public string mobile_phone { get; set; }

        [Display(Name = "职位")]
        [UIHint("EnumInt32")]
        public position position { get; set; }

        [Display(Name = "职称")]
        [UIHint("EnumInt32")]
        public job_title job_title { get; set; }

        [Display(Name = "学历")]
        [UIHint("EnumInt32")]
        public education education { get; set; }

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

    public enum position
    {
        [Display(Name = "无")]
        none = 0,
        [Display(Name = "室副主任")]
        viceManager = 1,
        [Display(Name = "室主任")]
        manager = 2,
        [Display(Name = "副所长")]
        viceChief = 3,
        [Display(Name = "所长")]
        chief = 4
    }

    public enum job_title
    {
        [Display(Name = "无")]
        none = 0,
        [Display(Name = "助理工程师")]
        assistantEngineer = 1,
        [Display(Name = "工程师")]
        engineer = 2,
        [Display(Name = "高级工程师")]
        advanceEngineer = 3,
        [Display(Name = "教授级高工")]
        proAdvEngineer = 4
    }

    public enum education
    {
        [Display(Name = "高中及以下")]
        highSchool = 0,
        [Display(Name = "专科")]
        college = 1,
        [Display(Name = "本科")]
        undergraduate = 2,
        [Display(Name = "研究生")]
        master = 3,
        [Display(Name = "博士")]
        doctor = 4
    }
}