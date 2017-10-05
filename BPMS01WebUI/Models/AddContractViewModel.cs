using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BPMS01Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public class AddContractViewModel
    {
        //一般情况下5个1分隔
        public string id { get; set; }

        public string staff_id { get; set; }

        public decimal staff_no { get; set; }    //视图模型中额外增加的部分
        public string staff_name { get; set; }   //视图模型中额外增加的部分

        public string contract_no { get; set; }
        public string contract_name { get; set; }
        public decimal contract_amount { get; set; }

        //[DataType(DataType.Date)]
        public DateTime contract_signed_data { get; set; }
        public long contract_deadline { get; set; }
        public string contract_agmt_wk_cnt { get; set; }
        public string project_location { get; set; }
        public string delegation_client { get; set; }

        public string dlg_contactperson { get; set; }
        public string dlg_contactperson_phone { get; set; }
        public string accept_way { get; set; }
        public bool is_corporation_signed { get; set; }
        public bool is_client_signed { get; set; }


    }
}