using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;   //FormCollection
using BPMS01Domain.Entities;

namespace BPMS01Domain.Abstract
{
    public interface IR_inspection_project_staffRepository
    {
        IEnumerable<r_inspection_project_staff> r_inspection_project_staff { get; }

        /// <summary>
        ///通过职工id查询职工的参与情况
        /// </summary>
        /// <param name="staff_id"><see cref="BPMS01Domain.Entities.staff.id"/></param>
        /// <returns>指定职工id的职工参与情况<see cref="r_inspection_project_staff"/></returns>
        IQueryable<join_r_inspection_project_staff> Query_R_inspection_project_staff_By_staff_id(Guid staff_id);

        /// <summary>
        /// 往数据库添加项目参与者信息
        /// </summary>
        /// <param name="r_inspection_project_staff">"桥梁检测-职工"信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        bool AddR_inspection_project_staff(r_inspection_project_staff r_inspection_project_staff);
    }
}
