using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;


using System.Security.Cryptography;     //Md5加密
using System.Text;


namespace BPMS01Domain.Concrete
{
    public class EFStaffRepository:IStaffRepository
    {
        private BPMSContext context = new BPMSContext();

        //全部职工信息
        public IEnumerable<staff> staff
        {
            get
            {
                //var query = from p in context.staff
                 //           where p.staff_no == 1743
                 //           select p;
                //return query;
                return context.staff;
            }
        }

        /// <summary>
        ///通过工号查询职工信息
        /// </summary>
        /// <param name="staff_no">职工工号(与数据库中的定义相关联)<see cref="staff"/></param>
        /// <returns>指定工号的职工详细信息<see cref="staff"/></returns>
        public IEnumerable<staff> QueryStaffBystaff_no(int staff_no)
        {
            return context.staff.Where(p=>p.no==staff_no);
        }


    public bool AddStaff(staff staff)
        {
            staff.id = Guid.NewGuid(); //去掉短横杠

            byte[] result = Encoding.Default.GetBytes(staff.password);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            staff.password = BitConverter.ToString(output).Replace("-", "");
    
            try
            {
                context.staff.Add(staff);
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