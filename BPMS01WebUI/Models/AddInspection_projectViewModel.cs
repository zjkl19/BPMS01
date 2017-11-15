using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

using System.Web.Mvc;

namespace BPMS01WebUI.Models
{
    public class AddInspection_projectViewModel:Inspection_projectViewModel
    {
        [DisplayName("添加项目")]    //using System.ComponentModel;

        [ScaffoldColumn(false)]    //using System.ComponentModel.DataAnnotations;
        public string id { get; set; }

        //[ScaffoldColumn(false)]
        //public string contract_id { get; set; }
        [ScaffoldColumn(false)]
        public string contract_name { get; set; }

        //[ScaffoldColumn(false)]
        //public string bridge_id { get; set; }
        [ScaffoldColumn(false)]
        public string bridge_name { get; set; }

        //using System.Web.Mvc;
        [HiddenInput(DisplayValue =false)]
        public double bridge_length { get; set; }

        [HiddenInput(DisplayValue = false)]
        public double bridge_width { get; set; }

        [HiddenInput(DisplayValue = false)]
        //[DataType(DataType.Text)]
        public structure_type bridge_structure_type { get; set; }


    }
}