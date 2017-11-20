using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public class ListPdtRatioAndValueViewModel
    {
        [Display(Name = "产值比例")]
        public Nullable<double> production_value_ratio { get; set; }
        [Display(Name = "产值")]
        public Nullable<double> production_value { get; set; }
    }
}