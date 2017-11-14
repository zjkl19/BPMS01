using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

namespace BPMS01Domain.Concrete
{
    public class EFR_inspection_project_staffRepository:IR_inspection_project_staffRepository
    {
        private BPMSContext context = new BPMSContext();

        //全部项目参与者信息
        public IEnumerable<r_inspection_project_staff> r_inspection_project_staff
        {
            get
            {
                return context.r_inspection_project_staff;
            }
        }

        //请查看接口部分注释
        public IQueryable<join_r_inspection_project_staff> Query_R_inspection_project_staff_By_staff_id(Guid staff_id)
        {
            
            var query = from p in context.inspection_project
                        join q in context.r_inspection_project_staff
                        on p.id equals q.inspection_project_id
                        where q.staff_id == staff_id
                        select new join_r_inspection_project_staff
                        {
                            
                            inspection_project_id = q.id,
                            inspection_project_name=p.name,
                            //staff_id
                            //staff_no
                            //staff_name
                            is_response=q.is_response,
                            scene_coff = q.scene_coff,
                            plan_coff = q.plan_coff,
                            report_coff = q.report_coff,
                            report_check_coff = q.report_check_coff,
                            others_coff = q.others_coff,
                            production_value_ratio = q.production_value_ratio,
                            production_value = q.production_value
                        };
            return query;
        }


        [HttpPost]
        public bool AddR_inspection_project_staff(r_inspection_project_staff r_inspection_project_staff)
        {

            r_inspection_project_staff.id = Guid.NewGuid();      

            try
            {
                context.r_inspection_project_staff.Add(r_inspection_project_staff);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)

            {
                throw new Exception("数据库添加信息出现异常。");
            }

        }


    }
}