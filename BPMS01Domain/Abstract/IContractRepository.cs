using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection
using BPMS01Domain.Entities;

namespace BPMS01Domain.Abstract
{
    public interface IContractRepository
    {
        IEnumerable<contract> contract { get; }

        /// <summary>
        /// 往数据库添加合同信息
        /// </summary>
        /// <param name="fc">包含合同编号、合同名称等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        bool AddContract(FormCollection fc);
    }
}