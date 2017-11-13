using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

namespace BPMS01Domain.Concrete
{
    public class EFContractRepository : IContractRepository
    {
        private BPMSContext context = new BPMSContext();

        //全部合同信息
        public IEnumerable<contract> contract
        {
            get
            {
                //var query = from p in context.contract
                //           select p;
                //return query;
                return context.contract;
            }
        }


        [HttpPost]
        public bool AddContract(contract contract)
        {

            contract.id = Guid.NewGuid();
            
            try
            {
                context.contract.Add(contract);
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