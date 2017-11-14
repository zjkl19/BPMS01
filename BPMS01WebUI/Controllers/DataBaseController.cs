using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using BPMS01Domain.Entities;

namespace BPMS01WebUI.Controllers
{
    public class DataBaseController : Controller
    {
        // GET: DataBase
        public ActionResult Index()
        {
            
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BPMSContext>());

            ViewBag.Message = "Database create successfully!";
            return View();
        }

        //Initialize basic data
        public ActionResult Initialize()
        {
            var dbContext = new BPMSContext();
            
            dbContext.staff.Add(new staff()
            {
                id = Guid.NewGuid(),
                no=1743,
                name="林迪南",
                password= "e10adc3949ba59abbe56e057f20f883e",
                gender=Convert.ToInt32(gender.male),
                office_phone="123456",
                mobile_phone="654321",
                position= Convert.ToInt32(BPMS01Domain.Entities.position.none),
                job_title=Convert.ToInt32(BPMS01Domain.Entities.job_title.assistantEngineer),
                education=Convert.ToInt32(BPMS01Domain.Entities.education.master),
                hiredate=Convert.ToDateTime("2016-07-25")
            });
            try
            {
                dbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }

            ViewBag.Message = "Database initialize successfully!";
            return View();
        }
    }
}