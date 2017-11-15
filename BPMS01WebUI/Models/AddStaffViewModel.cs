using System;
using System.ComponentModel.DataAnnotations;
namespace BPMS01WebUI.Models
{
    public class AddStaffViewModel:StaffViewModel
    {
        //覆写示例
        /*
        [ScaffoldColumn(true)]
        public Guid id { get; set; }
        */

        //顺序调整，插入示例
        /*
        [Display(Name = "工号")]
        [DataType(DataType.Text)]
        public int staff_no { get; set; }

        [Display(Name = "Guid")]
        [ScaffoldColumn(true)]
        public Guid id { get; set; }

        [Display(Name = "密码")]
        [DataType(DataType.Password)]
        public string staff_password { get; set; }
        */
    }
   
}