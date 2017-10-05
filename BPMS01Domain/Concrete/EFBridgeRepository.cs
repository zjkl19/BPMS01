using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

namespace BPMS01Domain.Concrete
{
    public class EFBridgeRepository : IBridgeRepository
    {
        private EFDbContext context = new EFDbContext();

        //全部桥梁信息
        public IEnumerable<bridge> bridge
        {
            get
            {
                return context.bridge;
            }
        }

        /// <summary>
        /// 往数据库添加桥梁信息
        /// </summary>
        /// <param name="fc">包含桥梁名称、桥梁长度等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        [HttpPost]
        public bool AddBridge(FormCollection fc)
        {


            string name = Convert.ToString(fc["name"]);
            double length = Convert.ToDouble(fc["length"]);
            double width = Convert.ToDouble(fc["width"]);
            Decimal structure_type = Convert.ToDecimal(fc["structure_type"]);

            var newData = new bridge();

            newData.id = Guid.NewGuid().ToString("N"); //去掉短横杠
            newData.name = name;
            newData.length = length;
            newData.width = width;
            newData.structure_type = structure_type;

            try
            {
                context.bridge.Add(newData);
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