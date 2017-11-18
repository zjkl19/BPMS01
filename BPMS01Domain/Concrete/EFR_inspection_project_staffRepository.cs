using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

namespace BPMS01Domain.Concrete
{
    public class EFR_inspection_project_staffRepository:IR_inspection_project_staffRepository
    {
        private BPMSContext context = new BPMSContext();

        //全部项目参与者信息
        public IEnumerable<r_inspection_project_staff> r_inspection_project_staff
        {
            get
            {
                return context.r_inspection_project_staff;
            }
        }


        [HttpPost]
        public bool AddR_inspection_project_staff(r_inspection_project_staff r_inspection_project_staff)
        {

            r_inspection_project_staff.id = Guid.NewGuid();      

            try
            {
                context.r_inspection_project_staff.Add(r_inspection_project_staff);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)

            {
                throw new Exception("数据库添加信息出现异常。");
            }

        }

        public r_inspection_project_staff DeleteR_inspection_project_staff(Guid id)
        {
            var dbEntry = context.r_inspection_project_staff.Find(id);
            if (dbEntry != null)
            {
                try
                {
                    context.r_inspection_project_staff.Remove(dbEntry);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            return dbEntry;
        }


    }
}