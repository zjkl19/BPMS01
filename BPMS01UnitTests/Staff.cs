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
                no = 1644,
                password = "e10adc3949ba59abbe56e057f20f883e",
                name = "黄学漾",
                gender = 1,
                office_phone = "123456",
                mobile_phone = "123456",
                position = 1,
                job_title = 1,
                education = 1,
                hiredate = Convert.ToDateTime("2015-06-25"),

            };

            //arrange: create mock repository
            Mock<IStaffRepository> mock = new Mock<IStaffRepository>();
            mock.Setup(m => m.staff).Returns(new staff[]    {
                new staff{
                id = Guid.NewGuid(),
                no = 1743,
                password = "123456",
                name = "林迪南",
                gender = 1,
                office_phone = "123456",
                mobile_phone = "123456",
                position = 1,
                job_title = 1,
                education = 1,
                hiredate = Convert.ToDateTime("2016-07-25")

            },
                new staff{
                id = Guid.NewGuid(),
                no = 1234,
                password = "123456",
                name = "张啸",
                gender = 1,
                office_phone = "654321",
                mobile_phone = "654321",
                position = 1,
                job_title = 1,
                education = 1,
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
        [TestMethod]
        public void Can_Send_gender_ViewModel()
        {
            //arrange
            Mock<IStaffRepository> mock = new Mock<IStaffRepository>();
            mock.Setup(m => m.staff).Returns(new staff[]    {
                new staff{
                id =Guid.NewGuid(),
                no = 1743,
                password = "123456",
                name = "林迪南",
                gender = 1,
                office_phone = "123456",
                mobile_phone = "123456",
                position = 1,
                job_title = 1,
                education = 1,
                hiredate = Convert.ToDateTime("2016-07-25")

            },
            });
            //arrange: create controller
            var myController = new StaffController(mock.Object);

            //act: 
            var result = (AddStaffViewModel)myController.AddStaff().Model;

            //assert
            var p = result.gender;
            //Text = m.GetType().GetProperty("Name").ToString(),
            Assert.AreEqual(p.GetType().GetProperty("Name").ToString(), "未知");
        }

    }
}
