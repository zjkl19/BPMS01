using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

namespace BPMS01Domain.Concrete
{
    public class EFBridgeRepository : IBridgeRepository
    {
        private BPMSContext context = new BPMSContext();

        //全部桥梁信息
        public IEnumerable<bridge> bridge
        {
            get
            {
                return context.bridge;
            }
        }

        /*
        public IQueryable <enum_bridge> enum_bridge
        {  
            get
            {
                var query = from p in context.staff
                            select new enum_staff
                            {
                                id = p.id,
                                staff_no = p.no,
                                staff_password = p.password,
                                staff_name = p.name,
                                gender = (gender)(p.gender),
                                //typeof(LevelPower).GetCustomAttributes(typeof(Description), false);          
                                office_phone = p.office_phone,
                                mobile_phone = p.mobile_phone,
                                //position=(position)p.position,T
                                //job_title=(job_title)p.job_title,
                                //education=(education)p.education,
                                position = (position)(p.position),
                                job_title = (job_title)(p.job_title),
                                education = (education)(p.education),
                                hiredate = p.hiredate
                            };
                return query;
            }
        }
        */
        [HttpPost]
        public bool AddBridge(bridge bridge)
        {

            bridge.id = Guid.NewGuid(); //去掉短横杠

            try
            {
                context.bridge.Add(bridge);
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