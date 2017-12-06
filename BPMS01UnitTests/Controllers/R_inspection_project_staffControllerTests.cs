using Microsoft.VisualStudio.TestTools.UnitTesting;
using BPMS01WebUI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BPMS01Domain.Abstract;    //Mock<IStaffRepository> mock

using BPMS01Domain.Entities;    //var staff = new staff

using BPMS01WebUI.Controllers;    //var target = new StaffController(mock.Object);
using BPMS01WebUI.Models;


using Moq;

namespace BPMS01WebUI.Controllers.Tests
{
    [TestClass()]
    public class R_inspection_project_staffControllerTests
    {
        [TestMethod()]
        public void List_R_inspection_project_staff_ByInspection_projectIdTest()
        {
            //arrage
            
            


            var staff_ldn = new staff
            {
                id = Guid.NewGuid(),
                no = 1743,
                name = "林迪南",
                password = "e10adc3949ba59abbe56e057f20f883e",
                gender = Convert.ToInt32(gender.male),
                office_phone = "123456",
                mobile_phone = "654321",
                position = Convert.ToInt32(position.none),
                job_title = Convert.ToInt32(job_title.assistantEngineer),
                education = Convert.ToInt32(education.master),
                hiredate = Convert.ToDateTime("2016-07-25")
            };

            var staff_lp = new staff
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
            };

            Mock<IStaffRepository> mockStaff = new Mock<IStaffRepository>();
            mockStaff.Setup(m => m.staff).Returns(new staff[] {
            staff_ldn,
            staff_lp
            });


            var p1 = new inspection_project
            {

                id = Guid.NewGuid(),
                contract_id = Guid.NewGuid(),
                bridge_id = Guid.NewGuid(),
                name = "某荷载试验项目",
                enter_date = Convert.ToDateTime("2016-07-25"),
                exit_date = Convert.ToDateTime("2016-08-25"),
                inspection_type = Convert.ToInt32(inspection_type.staticLoad),
                standard_price = 10000.00M
            };

            var p2 = new inspection_project
            {
                id = Guid.NewGuid(),
                contract_id = Guid.NewGuid(),
                bridge_id = Guid.NewGuid(),
                name = "某外观检查项目",
                enter_date = Convert.ToDateTime("2016-10-20"),
                exit_date = Convert.ToDateTime("2016-11-25"),
                inspection_type = Convert.ToInt32(inspection_type.regularPeriod),
                standard_price = 20000.00M
            };

            Mock<IInspection_projectRepository> mockInspection_project = new Mock<IInspection_projectRepository>();
            mockInspection_project.Setup(m => m.inspection_project).Returns(new inspection_project[] {
            p1,
            p2
            });

            var r_i_s = new r_inspection_project_staff
            {
                id = Guid.NewGuid(),
                inspection_project_id = p1.id,
                staff_id = staff_lp.id,
                is_response = Convert.ToInt32(is_response.no),
                scene_coff = Convert.ToInt32(scene_coff.yes),
                plan_coff = Convert.ToInt32(plan_coff.yes),
                report_coff = Convert.ToInt32(report_coff.yes),
                report_check_coff = Convert.ToInt32(report_check_coff.yes),
                others_coff = Convert.ToInt32(others_coff.yes),
                production_value_ratio = 0.5,
                production_value = 10000

            };
            //arrange: create mock repository
            Mock<IR_inspection_project_staffRepository> mockR_inspection_project_staff = new Mock<IR_inspection_project_staffRepository>();
            mockR_inspection_project_staff.Setup(m => m.r_inspection_project_staff).Returns(new r_inspection_project_staff[] {

            new r_inspection_project_staff{
                id = Guid.NewGuid(),
                inspection_project_id=Guid.NewGuid(),
                staff_id=Guid.NewGuid(),
                is_response= Convert.ToInt32(is_response.no),
                scene_coff= Convert.ToInt32(scene_coff.yes),
                plan_coff= Convert.ToInt32(plan_coff.yes),
                report_coff= Convert.ToInt32(report_coff.yes),
                report_check_coff= Convert.ToInt32(report_check_coff.yes),
                others_coff= Convert.ToInt32(others_coff.yes),
                production_value_ratio=0.3,
                production_value=30000
            },

            r_i_s,

            new r_inspection_project_staff {
                id = Guid.NewGuid(),
                inspection_project_id=Guid.NewGuid(),
                staff_id=Guid.NewGuid(),
                is_response= Convert.ToInt32(is_response.yes),
                scene_coff= Convert.ToInt32(scene_coff.yes),
                plan_coff= Convert.ToInt32(plan_coff.yes),
                report_coff= Convert.ToInt32(report_coff.yes),
                report_check_coff= Convert.ToInt32(report_check_coff.yes),
                others_coff= Convert.ToInt32(others_coff.yes),
                production_value_ratio=0.3,
                production_value=30000
            }
            });



            //arrange a controller
            var target = new R_inspection_project_staffController(mockR_inspection_project_staff.Object, mockInspection_project.Object, mockStaff.Object);

            //act
            var r=(IEnumerable<List_R_inspection_project_staff_ByInspection_projectIdViewModel>)target.List_R_inspection_project_staff_ByInspection_projectId(r_i_s.inspection_project_id).Model;

            var r1 = r.ToArray();
            //assert
            
            Assert.AreEqual(r1[0].production_value_ratio,0.5);
            Assert.AreEqual(r1[0].staff_name, "李鹏");
            Assert.AreEqual(r1[0].is_response, is_response.no);
        }

    }
}
