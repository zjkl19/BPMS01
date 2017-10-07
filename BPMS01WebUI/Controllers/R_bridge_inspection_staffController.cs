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
        /// <param name="fc">含有添加项目参与信息的表单</param>
        /// <returns>ViewResult:添加添加项目参与信息后返回的视图</returns>
        [HttpPost]
        public ViewResult AddR_bridge_inspection_staff(FormCollection fc)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddR_bridge_inspection_staff(fc);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }

            return View();

        }
    }
}