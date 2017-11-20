using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;   //FormCollection
using BPMS01Domain.Entities;

namespace BPMS01Domain.Abstract
{
    public interface IBridgeRepository
    {
        IEnumerable<bridge> bridge { get; }

        /// <summary>
        /// 往数据库添加桥梁信息
        /// </summary>
        /// <param name="bridge">桥梁信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        bool AddBridge(bridge bridge);
    }
}
