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
        private EFDbContext context = new EFDbContext();

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

        /// <summary>
        ///往数据库添加合同信息
        /// </summary>
        /// <param name="fc">包含工号、姓名等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        [HttpPost]
        public bool AddContract(FormCollection fc)
        {

            string contract_no = Convert.ToString(fc["contract_no"]);
            string contract_name = Convert.ToString(fc["contract_name"]);
            Decimal contract_amount = Convert.ToDecimal(fc["contract_amount"]);
            DateTime contract_signed_data = Convert.ToDateTime(fc["contract_signed_data"]);
            int contract_deadline = Convert.ToInt32(fc["contract_deadline"]);

            string contract_agmt_wk_cnt = Convert.ToString(fc["contract_agmt_wk_cnt"]);
            string project_location = Convert.ToString(fc["project_location"]);

            string delegation_client = Convert.ToString(fc["delegation_client"]);
            string dlg_contractperson = Convert.ToString(fc["dlg_contractperson"]);
            string dlg_contractperson_phone = Convert.ToString(fc["dlg_contractperson_phone"]);

            string staff_id = Convert.ToString(fc["staff_id"]);

            string accept_way = Convert.ToString(fc["accept_way"]);
            Boolean is_corporation_signed = Convert.ToBoolean(fc["is_corporation_signed"]);
            Boolean is_client_signed = Convert.ToBoolean(fc["is_client_signed"]);


            var newData = new contract();
 
            newData.id = Guid.NewGuid().ToString("N"); //去掉短横杠
            newData.contract_no = contract_no;
            newData.contract_name = contract_name;
            newData.contract_amount = contract_amount;
            newData.contract_signed_data = contract_signed_data;

            newData.contract_deadline = contract_deadline;
            newData.contract_agmt_wk_cnt = contract_agmt_wk_cnt;
            newData.project_location = project_location;
            newData.delegation_client = delegation_client;
            newData.dlg_contactperson = dlg_contractperson;

            newData.dlg_contactperson_phone = dlg_contractperson_phone;
            newData.staff_id = staff_id;
            newData.accept_way = accept_way;
            newData.is_corporation_signed = is_corporation_signed;
            newData.is_client_signed = is_client_signed;
           
            try
            {
                context.contract.Add(newData);
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