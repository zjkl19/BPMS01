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
using X.PagedList;
using Moq;


namespace BPMS01WebUI.Controllers.Tests
{
    [TestClass()]
    public class Staff
    {
        [TestMethod()]
        public void IndexTest()
        {
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

            //arrange: create controller
            StaffController target = new StaffController(mock.Object);

            var result = (IPagedList<IndexStaffViewModel>)target.Index(1);

            //assert
            Assert.AreEqual(result[0].no, 1743);
        }
    }
}