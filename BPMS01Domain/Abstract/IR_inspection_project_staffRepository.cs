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
        /// 往数据库添加项目参与者信息
        /// </summary>
        /// <param name="r_inspection_project_staff">"桥梁检测-职工"信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        bool AddR_inspection_project_staff(r_inspection_project_staff r_inspection_project_staff);
    }
}
