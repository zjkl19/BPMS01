
//�Զ��塰��Ŀ-ְ���� ����չ��ģ��
//�����ְ����������Ŀ���Ƶ���ʾ
//��r_inspection_project_staffҵ��ģ�͵���չ��
namespace BPMS01Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class join_r_inspection_project_staff
    {

        public Guid id { get; set; }
        public Guid inspection_project_id { get; set; }
        public string inspection_project_name { get; set; }   //add

        public Guid staff_id { get; set; }
        public int staff_no { get; set; }
        public string staff_name { get; set; }    //add

        public int is_response { get; set; }
        public int scene_coff { get; set; }
        public int plan_coff { get; set; }
        public int report_coff { get; set; }
        public int report_check_coff { get; set; }
        public int others_coff { get; set; }

        public Nullable<double> production_value_ratio { get; set; }
        public Nullable<double> production_value { get; set; }
    
    }
}
