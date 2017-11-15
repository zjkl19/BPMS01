using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using BPMS01Domain.Entities;
using System.Collections;

using BPMS01WebUI.Models;

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
                position= Convert.ToInt32(position.none),
                job_title=Convert.ToInt32(job_title.assistantEngineer),
                education=Convert.ToInt32(education.master),
                hiredate=Convert.ToDateTime("2016-07-25")
            });

            var staff_lp = dbContext.staff.Add(new staff()
            {
                id = Guid.NewGuid(),
                no = 528,
                name = "李鹏",
                password = "e10adc3949ba59abbe56e057f20f883e",
                gender = Convert.ToInt32(gender.male),
                office_phone = "123456",
                mobile_phone = "654321",
                position = Convert.ToInt32(position.viceManager),
                job_title = Convert.ToInt32(job_title.engineer),
                education = Convert.ToInt32(education.master),
                hiredate = Convert.ToDateTime("2011-08-25")
            });

            var staff_djb = dbContext.staff.Add(new staff()
            {
                id = Guid.NewGuid(),
                no = 1891,
                name = "戴杰斌",
                password = "e10adc3949ba59abbe56e057f20f883e",
                gender = Convert.ToInt32(gender.male),
                office_phone = "123456",
                mobile_phone = "654321",
                position = Convert.ToInt32(position.none),
                job_title = Convert.ToInt32(job_title.none),
                education = Convert.ToInt32(education.undergraduate),
                hiredate = Convert.ToDateTime("2017-10-25")
            });
            var staff_wxq = dbContext.staff.Add(new staff()
            {
                id = Guid.NewGuid(),
                no = 1117,
                name = "王曦强",
                password = "e10adc3949ba59abbe56e057f20f883e",
                gender = Convert.ToInt32(gender.male),
                office_phone = "123456",
                mobile_phone = "654321",
                position = Convert.ToInt32(position.none),
                job_title = Convert.ToInt32(job_title.assistantEngineer),
                education = Convert.ToInt32(education.undergraduate),
                hiredate = Convert.ToDateTime("2012-07-20")
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
                  accept_way= Convert.ToInt32(accept_way.bid),
                  is_corporation_signed= Convert.ToInt32(is_corporation_signed.yes),
                  is_client_signed= Convert.ToInt32(is_client_signed.yes)
            });

            var contract02 = dbContext.contract.Add(new contract()
            {
                id = Guid.NewGuid(),
                staff_id = staff_lp.id,
                no = "HT02CB1600201",
                name = "某桥外观检查",
                amount = 150000.00M,
                signed_data = Convert.ToDateTime("2016-08-20"),
                deadline = 30,
                agmt_wk_cnt = "检测桥梁外观",
                project_location = "莆田",
                delegation_client = "莆田市建设局",
                dlg_contactperson = "李锋",
                dlg_contactperson_phone = "123456",
                accept_way = Convert.ToInt32(accept_way.bid),
                is_corporation_signed = Convert.ToInt32(is_corporation_signed.yes),
                is_client_signed = Convert.ToInt32(is_client_signed.yes)
            });

            //
            var bridgeArr = new ArrayList();

            //arr.Add(你的对象);

            //访问：
            //(你的类）arr[索引]
            var bridge01 = dbContext.bridge.Add(new bridge()
            {
                id = Guid.NewGuid(),
                name="莆田某桥",
                length=25.0,
                width=10,
                span_number=1,
                structure_type= Convert.ToInt32(structure_type.SimpleSupportedBeam)
            });
            bridgeArr.Add(bridge01);
            //(BPMSContext)bridgeArr[0]
            var bridge02 = dbContext.bridge.Add(new bridge()
            {
                id = Guid.NewGuid(),
                name = "福州某桥",
                length =60.0,
                width = 14,
                span_number = 2,
                structure_type = Convert.ToInt32(structure_type.Continous_Rigid_Beam)
            });
            bridgeArr.Add(bridge02);


            var project01 = dbContext.inspection_project.Add(new inspection_project()
            {
                id = Guid.NewGuid(),
                contract_id= contract01.id,
                bridge_id= bridge01.id,
                name = "某荷载试验项目",
                enter_date= Convert.ToDateTime("2016-07-25"),
                exit_date= Convert.ToDateTime("2016-08-25"),
                inspection_type= Convert.ToInt32(inspection_type.staticLoad),
                standard_price=10000.00M
            });

            var project02 = dbContext.inspection_project.Add(new inspection_project()
            {
                id = Guid.NewGuid(),
                contract_id = contract02.id,
                bridge_id = bridge02.id,
                name = "某外观检查项目",
                enter_date = Convert.ToDateTime("2016-10-20"),
                exit_date = Convert.ToDateTime("2016-11-25"),
                inspection_type = Convert.ToInt32(inspection_type.regularPeriod),
                standard_price = 20000.00M
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