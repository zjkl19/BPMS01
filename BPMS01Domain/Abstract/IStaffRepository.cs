using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection
using BPMS01Domain.Entities;

namespace BPMS01Domain.Abstract
{
    public interface IStaffRepository
    {
        //IEnumerable<staff> staff { get; }
        IEnumerable<staff> staff { get; }

        /// <summary>
        ///通过工号查询职工信息
        /// </summary>
        /// <param name="staff_no">职工工号(与数据库中的定义相关联)<see cref="staff"/></param>
        /// <returns>指定工号的职工详细信息<see cref="r_project_staff"/></returns>
        IEnumerable<staff> QueryStaffBystaff_no(int staff_no);

        /// <summary>
        ///通过职工id查询职工的参与情况
        /// </summary>
        /// <param name="staff_id"><see cref="BPMS01Domain.Entities.staff.id"/></param>
        /// <returns>指定职工id的职工参与情况<see cref="r_inspection_project_staff"/></returns>
        IQueryable<enum_staff> enum_staff { get; }


        /// <summary>
        ///往数据库中添加职工信息
        /// </summary>
        /// <param name="staff">包含职工工号，密码等在内的信息</param>
        /// <returns>true表示添加成功,false表示添加失败</returns>
        bool AddStaff(staff staff);
    }
}