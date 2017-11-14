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

            var option = 2;

            if(option==1)
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<BPMSContext>());
            else if(option==2)
                Database.SetInitializer(new DropCreateDatabaseAlways<BPMSContext>());

            ViewBag.Message = "Database create successfully!";
            return View();
        }

        //Initialize basic data
        public ActionResult Initialize()
        {
            var dbContext = new BPMSContext();


            var staff_ldn=dbContext.staff.Add(new staff()
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


            var contract01=dbContext.contract.Add(new contract()
            {
                  id=Guid.NewGuid(),
                  staff_id=staff_ldn.id,
                  no="HT02CB1600200",
                  name="某桥荷载试验",
                  amount=100000.00M,
                  signed_data = Convert.ToDateTime("2016-06-25"),
                  deadline=30,
                  agmt_wk_cnt="验算桥梁承载能力",
                  project_location= "莆田",
                  delegation_client="莆田市建设局",
                  dlg_contactperson="李锋",
                  dlg_contactperson_phone="123456",
                  accept_way=1,
                  is_corporation_signed=1,
                  is_client_signed=1
            });

            var bridge01 = dbContext.bridge.Add(new bridge()
            {
                id = Guid.NewGuid(),
                name="某桥",
                length=25.0,
                width=10,
                span_number=1,
                structure_type=1
            });

            var project01 = dbContext.inspection_project.Add(new inspection_project()
            {
                id = Guid.NewGuid(),
                contract_id= contract01.id,
                bridge_id= bridge01.id,
                name = "某荷载试验项目",
                enter_date= Convert.ToDateTime("2016-07-25"),
                exit_date= Convert.ToDateTime("2016-08-25"),
                inspection_type=1,
                standard_price=10000.00M
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