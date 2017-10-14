using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using BPMS01Domain.Abstract;    //Mock<IStaffRepository> mock

using BPMS01Domain.Entities;    //var staff = new staff

using BPMS01WebUI.Controllers;    //var target = new StaffController(mock.Object);
using BPMS01WebUI.Models;

using Moq;

namespace BPMS01UnitTests
{
    [TestClass]
    public class Staff
    {
        [TestMethod]
        public void Can_Call_Addstaff()
        {
            //arrange: create a new staff
            var stf = new staff
            {
                //id = Guid.NewGuid().ToString("N"),
                //AddStaff方法中自动生成id
                staff_no = 1644,
                staff_password = "e10adc3949ba59abbe56e057f20f883e",
                staff_name = "黄学漾",
                gender = 1,
                office_phone = "123456",
                mobile_phone = "123456",
                position = "检测员",
                job_title = "工程师",
                education = "博士",
                hiredate = Convert.ToDateTime("2015-06-25")

            };

            //arrange: create mock repository
            Mock<IStaffRepository> mock = new Mock<IStaffRepository>();
            mock.Setup(m => m.staff).Returns(new staff[]    {
                new staff{
                id = "4562c49835d44f7a861f49af4593d6dc",
                staff_no = 1743,
                staff_password = "123456",
                staff_name = "林迪南",
                gender = 1,
                office_phone = "123456",
                mobile_phone = "123456",
                position = "检测员",
                job_title = "工程师",
                education = "研究生",
                hiredate = Convert.ToDateTime("2016-07-25")

            },
                new staff{
                id = "7a876d66c9a54558b37ce2037bc1fb23",
                staff_no = 1234,
                staff_password = "123456",
                staff_name = "张啸",
                gender = 1,
                office_phone = "654321",
                mobile_phone = "654321",
                position = "检测员",
                job_title = "工程师",
                education = "本科",
                hiredate = Convert.ToDateTime("2014-07-25")

            }
            });
            //   new staff { })

            //arrange: create controller
            StaffController target = new StaffController(mock.Object);

            //act: add staff
            target.AddStaff(stf);

            //assert: ensure the add method is for the correct object
            mock.Verify(m => m.AddStaff(stf));
        }

    }
}
