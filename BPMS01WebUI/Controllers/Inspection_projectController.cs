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
    public class Inspection_projectController : Controller
    {
        //检测项目仓库（库模式）
        private IInspection_projectRepository repository;

        //构造函数
        public Inspection_projectController(IInspection_projectRepository inspection_projectRepository)
        {
            this.repository = inspection_projectRepository;
        }

        /// <summary>
        /// 添加检测项目信息
        /// </summary>
        /// <returns>ViewResult:添加检测项目信息的视图</returns>
        public ViewResult AddInspection_project()
        {
            return View();

        }

        /// <summary>
        /// 往数据库添加项目信息
        /// </summary>
        /// <param name="fc">包含项目名称、进场时间等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        [HttpPost]
        public ViewResult AddInspection_project(FormCollection fc)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddInspection_project(fc);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }

            return View();

        }
    }
}