using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BPMS01Domain.Entities;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public abstract class ContractViewModel
    {
        //一般情况下5个1分隔
        [ScaffoldColumn(false)]
        public Guid id { get; set; }

        [ScaffoldColumn(false)]
        public Guid staff_id { get; set; }

        [Display(Name = "合同编号")]
        public string no { get; set; }

        [Display(Name = "合同名称")]
        public string name { get; set; }

        [Display(Name = "合同金额")]
        public decimal amount { get; set; }

        [Display(Name = "合同签订日期")]
        public DateTime signed_data { get; set; }

        [Display(Name = "合同期限")]
        public long deadline { get; set; }

        [Display(Name = "合同约定工作内容")]
        [DataType(DataType.MultilineText)]
        public string agmt_wk_cnt { get; set; }

        [Display(Name = "项目地点")]
        public string project_location { get; set; }

        [Display(Name = "委托单位")]
        public string delegation_client { get; set; }

        [Display(Name = "委托单位联系人")]
        public string dlg_contactperson { get; set; }

        [Display(Name = "委托单位联系人电话")]
        public string dlg_contactperson_phone { get; set; }

        [Display(Name = "承接方式")]
        [UIHint("EnumInt32")]
        public accept_way accept_way { get; set; }

        [Display(Name = "单位是否签订")]
        [UIHint("EnumInt32")]
        public is_corporation_signed is_corporation_signed { get; set; }

        [Display(Name = "客户是否签订")]
        [UIHint("EnumInt32")]
        public is_client_signed is_client_signed { get; set; }


    }

    public enum accept_way
    {
        [Display(Name = "投标")]
        bid = 1,
        [Display(Name = "委托")]
        delegation = 2,
        [Display(Name = "包干")]
        all = 3,
    }

    public enum is_corporation_signed
    {
        [Display(Name = "未知")]
        unknown = 1,
        [Display(Name = "是")]
        yes = 2,
        [Display(Name = "否")]
        no = 3,
    }

    public enum is_client_signed
    {
        [Display(Name = "未知")]
        unknown = 1,
        [Display(Name = "是")]
        yes = 2,
        [Display(Name = "否")]
        no = 3,
    }
}