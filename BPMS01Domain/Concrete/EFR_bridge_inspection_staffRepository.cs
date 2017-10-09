using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

namespace BPMS01Domain.Concrete
{
    public class EFR_bridge_inspection_staffRepository:IR_bridge_inspection_staffRepository
    {
        private EFDbContext context = new EFDbContext();

        //全部项目参与者信息
        public IEnumerable<r_bridge_inspection_staff> r_bridge_inspection_staff
        {
            get
            {
                return context.r_bridge_inspection_staff;
            }
        }

        //请查看接口部分注释
        public IQueryable<join_r_bridge_inspection_staff> Query_R_bridge_inspection_staff_By_staff_id(string staff_id)
        {
            
            var query = from p in context.inspection_project
                        join q in context.r_bridge_inspection_staff
                        on p.id equals q.inspection_project_id
                        where q.staff_id == staff_id
                        select new join_r_bridge_inspection_staff
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

        /// <summary>
        /// 往数据库添加项目参与者信息
        /// </summary>
        /// <param name="fc">包含项目id、职工id等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        [HttpPost]
        public bool AddR_bridge_inspection_staff(FormCollection fc)
        {

            string inspection_project_id = Convert.ToString(fc["inspection_project_id"]);
            string staff_id = Convert.ToString(fc["staff_id"]);
            Boolean is_response = Convert.ToBoolean(fc["is_response"]);
            Boolean scene_coff = Convert.ToBoolean(fc["scene_coff"]);
            Boolean plan_coff = Convert.ToBoolean(fc["plan_coff"]);
            Boolean report_coff = Convert.ToBoolean(fc["report_coff"]);
            Boolean report_check_coff = Convert.ToBoolean(fc["report_check_coff"]);
            Boolean others_coff = Convert.ToBoolean(fc["others_coff"]);
            double production_value_ratio = Convert.ToDouble(fc["production_value_ratio"]);
            double production_value = Convert.ToDouble(fc["production_value"]);

            var newData = new r_bridge_inspection_staff();

            newData.id = Guid.NewGuid().ToString("N"); //去掉短横杠
            newData.inspection_project_id = inspection_project_id;
            newData.staff_id = staff_id;
            newData.is_response = is_response;
            newData.scene_coff = scene_coff;

            newData.plan_coff = plan_coff;
            newData.report_coff = report_coff;
            newData.report_check_coff = report_check_coff;
            newData.others_coff = others_coff;
            newData.production_value_ratio = production_value_ratio;

            newData.production_value = production_value;


            try
            {
                context.r_bridge_inspection_staff.Add(newData);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            //catch (DbEntityValidationException dbEx)

            {
                throw new Exception("数据库添加信息出现异常。");
            }

        }


    }
}