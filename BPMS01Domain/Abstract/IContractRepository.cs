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
        ///往数据库添加合同信息
        /// </summary>
        /// <param name="contract">合同信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        bool AddContract(contract contract);
    }
}