using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BPMS01Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public class AddContractViewModel:ContractViewModel
    {

        [ScaffoldColumn(false)]
        public Guid staff_id { get; set; }

        [ScaffoldColumn(false)]
        public int staff_no { get; set; }    //视图模型中额外增加的部分
        [ScaffoldColumn(false)]
        public string staff_name { get; set; }   //视图模型中额外增加的部分

        [Display(Name = "合同编号")]
        public string no { get; set; }



    }
}