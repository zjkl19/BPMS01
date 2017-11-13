using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

namespace BPMS01Domain.Concrete
{
    public class EFInspection_projectRepository: IInspection_projectRepository
    {
        private BPMSContext context = new BPMSContext();

        //全部项目信息
        public IEnumerable<inspection_project> inspection_project
        {
            get
            {
                return context.inspection_project;
            }
        }


        [HttpPost]
        public bool AddInspection_project(inspection_project inspection_project)
        {

            inspection_project.id = Guid.NewGuid();

            try
            {
                context.inspection_project.Add(inspection_project);
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