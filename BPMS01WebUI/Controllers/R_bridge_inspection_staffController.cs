using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

using Ninject;  //重要！

using BPMS01WebUI.Models;

namespace BPMS01WebUI.Controllers
{
    public class R_bridge_inspection_staffController : Controller
    {
        //职工参与信息仓库（库模式）
        private IR_bridge_inspection_staffRepository repository;

        //构造函数
        public R_bridge_inspection_staffController(IR_bridge_inspection_staffRepository r_bridge_inspection_staffRepository)
        {
            this.repository = r_bridge_inspection_staffRepository;
        }


        /// <summary>
        ///通过职工id查询职工的参与情况
        /// </summary>
        /// <returns>查询界面默认视图<see cref="join_r_bridge_inspection_staff"/></returns>
        public ViewResult  Query_R_bridge_inspection_staff_By_staff_id()
        {
            ViewBag.query = 0;
            return View();
        }

        /// <summary>
        /// 提交表单中的职工id进行查询
        /// </summary>
        /// <returns>查询界面视图</returns>
        [HttpPost]
        public ViewResult Query_R_bridge_inspection_staff_By_staff_id(FormCollection fc)
        {
            ViewBag.query = 1;

            string staff_id = fc["staff_id"];
            ViewBag.staff_id = staff_id;

            return View();
        }

        /// <summary>
        ///列出指定职工id的职工项目参与情况
        /// </summary>
        /// <param name="staff_id"><see cref="BPMS01Domain.Entities.staff.id"/></param>
        /// <returns>含有职工项目参与信息的ViewResult<see cref="join_r_bridge_inspection_staff"/></returns>
        [ChildActionOnly]
        [HttpPost]
        public PartialViewResult  List_R_bridge_inspection_staff_By_staff_id(Guid staff_id)
        {
            return PartialView(repository.Query_R_bridge_inspection_staff_By_staff_id(staff_id));
        }

        /// <summary>
        /// 添加项目参与信息
        /// </summary>
        /// <returns>ViewResult:添加项目参与信息的视图</returns>
        public ViewResult AddR_bridge_inspection_staff()
        {
            return View();

        }


        /// <summary>
        /// 添加项目参与信息
        /// </summary>
        /// <param name="r_bridge_inspection_staff">"桥梁检测-职工"信息</param>
        /// <returns>ViewResult:添加添加项目参与信息后返回的视图</returns>
        [HttpPost]
        public ViewResult AddR_bridge_inspection_staff(r_bridge_inspection_staff r_bridge_inspection_staff)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddR_bridge_inspection_staff(r_bridge_inspection_staff);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }

            return View();

        }
    }
}