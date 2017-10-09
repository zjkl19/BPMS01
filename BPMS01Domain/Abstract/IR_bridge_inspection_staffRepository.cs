using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;   //FormCollection
using BPMS01Domain.Entities;

namespace BPMS01Domain.Abstract
{
    public interface IR_bridge_inspection_staffRepository
    {
        IEnumerable<r_bridge_inspection_staff> r_bridge_inspection_staff { get; }

        /// <summary>
        ///通过职工id查询职工的参与情况
        /// </summary>
        /// <param name="staff_id"><see cref="BPMS01Domain.Entities.staff.id"/></param>
        /// <returns>指定职工id的职工参与情况<see cref="join_r_bridge_inspection_staff"/></returns>
        IQueryable<join_r_bridge_inspection_staff> Query_R_bridge_inspection_staff_By_staff_id(string staff_id);

        /// <summary>
        /// 往数据库添加项目参与者信息
        /// </summary>
        /// <param name="fc">包含项目id、职工id等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        bool AddR_bridge_inspection_staff(FormCollection fc);
    }
}
