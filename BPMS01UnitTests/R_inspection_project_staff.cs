using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using BPMS01Domain.Abstract;    //Mock<IStaffRepository> mock

using BPMS01Domain.Entities;    //var staff = new staff

using BPMS01WebUI.Controllers;    //var target = new StaffController(mock.Object);
using BPMS01WebUI.Models;


using Moq;

namespace BPMS01UnitTests
{
    [TestClass]
    public class R_inspection_project_staff
    {
        //参考《精通asp.net mvc5》 P252
        [TestMethod]
        public void Can_Delete_Valid_R_inspection_project_staff()
        {
            //arrage a r_inspection_project_staff 
            var r_i_s = new r_inspection_project_staff
            {
                id = new Guid(),
                inspection_project_id = new Guid(),
                staff_id = new Guid(),
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

            Mock<IInspection_projectRepository> mockInspection_project = new Mock<IInspection_projectRepository>();
            mockInspection_project.Setup(m => m.inspection_project).Returns(new inspection_project[] {
            new inspection_project{

                id = Guid.NewGuid(),
                contract_id= Guid.NewGuid(),
                bridge_id= Guid.NewGuid(),
                name = "某荷载试验项目",
                enter_date= Convert.ToDateTime("2016-07-25"),
                exit_date= Convert.ToDateTime("2016-08-25"),
                inspection_type= Convert.ToInt32(inspection_type.staticLoad),
                standard_price=10000.00M
            },
            new inspection_project {
                id = Guid.NewGuid(),
                contract_id = Guid.NewGuid(),
                bridge_id = Guid.NewGuid(),
                name = "某外观检查项目",
                enter_date = Convert.ToDateTime("2016-10-20"),
                exit_date = Convert.ToDateTime("2016-11-25"),
                inspection_type = Convert.ToInt32(inspection_type.regularPeriod),
                standard_price = 20000.00M
            }
            });

            Mock<IStaffRepository> mockStaff = new Mock<IStaffRepository>();
            mockStaff.Setup(m => m.staff).Returns(new staff[] {
            new staff{
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
            },
            new staff {
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
            }
            });

            //arrange a controller
            var target = new R_inspection_project_staffController(mockR_inspection_project_staff.Object, mockInspection_project.Object, mockStaff.Object);

            //act - delete r_inspection_project_staff
            target.DeleteR_inspection_project_staff(r_i_s.id);

            //assert
            mockR_inspection_project_staff.Verify(m => m.DeleteR_inspection_project_staff(r_i_s.id));
        }
    }
}
