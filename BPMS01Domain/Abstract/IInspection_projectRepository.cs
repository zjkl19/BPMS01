using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;   //FormCollection
using BPMS01Domain.Entities;

namespace BPMS01Domain.Abstract
{
    public interface IInspection_projectRepository
    {
        IEnumerable<inspection_project> inspection_project { get; }

        /// <summary>
        /// 往数据库添加项目信息
        /// </summary>
        /// <param name="fc">包含项目名称、进场时间等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        bool AddInspection_project(FormCollection fc);
    }
}
