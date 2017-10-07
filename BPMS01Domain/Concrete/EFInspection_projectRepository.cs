using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

namespace BPMS01Domain.Concrete
{
    public class EFInspection_projectRepository: IInspection_projectRepository
    {
        private EFDbContext context = new EFDbContext();

        //全部项目信息
        public IEnumerable<inspection_project> inspection_project
        {
            get
            {
                return context.inspection_project;
            }
        }

        /// <summary>
        /// 往数据库添加项目信息
        /// </summary>
        /// <param name="fc">包含项目名称、进场时间等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>      
        [HttpPost]
        public bool AddInspection_project(FormCollection fc)
        {


            string name = Convert.ToString(fc["name"]);
            string contract_id = Convert.ToString(fc["contract_id"]);
            string bridge_id = Convert.ToString(fc["bridge_id"]);
            DateTime enter_date = Convert.ToDateTime(fc["enter_date"]);
            DateTime exit_date = Convert.ToDateTime(fc["exit_date"]);
            Decimal bridge_inspection = Convert.ToDecimal(fc["bridge_inspection"]);
            Decimal standard_price = Convert.ToDecimal(fc["standard_price"]);

            var newData = new inspection_project();

            newData.id = Guid.NewGuid().ToString("N"); //去掉短横杠
            newData.name = name;
            newData.contract_id = contract_id;
            newData.bridge_id = bridge_id;
            newData.enter_date = enter_date;
            newData.exit_date = exit_date;
            newData.bridge_inspection = bridge_inspection;
            newData.standard_price = standard_price;

            try
            {
                context.inspection_project.Add(newData);
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