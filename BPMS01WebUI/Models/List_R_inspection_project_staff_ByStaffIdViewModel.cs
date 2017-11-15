using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BPMS01WebUI.Models
{
    public class List_R_inspection_project_staff_ByStaffIdViewModel:R_inspection_project_staffViewModel
    {
        [ScaffoldColumn(false)]
        public string inspection_project_name { get; set; }
    }
}