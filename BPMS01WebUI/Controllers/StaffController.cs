using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

using Ninject;


namespace BPMS01WebUI.Controllers
{
    public class StaffController : Controller
    {
        //职工仓库（库模式）
        private IStaffRepository repository;

        //构造函数
        public StaffController(IStaffRepository staffRepository)
        {
            this.repository = staffRepository;
        }

        // GET: Staff
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 添加职工信息
        /// </summary>
        /// <returns>ViewResult:添加职工信息的视图</returns>
        public ViewResult AddStaff()
        {
            return View();
        }

        /// <summary>
        /// 添加职工信息
        /// </summary>
        /// <param name="fc">含有职工信息的表单</param>
        /// <returns>ViewResult:添加职工信息后返回的视图</returns>
        [HttpPost]
        public ViewResult AddStaff(FormCollection fc)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddStaff(fc);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }
            return View();

        }
    }
}