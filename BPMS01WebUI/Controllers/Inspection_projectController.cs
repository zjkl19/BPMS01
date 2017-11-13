using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;
using BPMS01Domain.Models;

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
        /// 列出项目信息
        /// </summary>
        /// <returns>PartialView:所有项目信息的视图</returns>
        public PartialViewResult ListInspection_project()
        {
            return PartialView(repository.inspection_project);
        }

        /// <summary>
        /// 计算标准产值
        /// </summary>
        /// <returns>null</returns>
        
        //改注释,补单元测试？
        [HttpPost]
        public ActionResult GetStd_pdt_value(FormCollection fc)
        {

            int bridgeStructure_type = Convert.ToInt32(fc["bridge_structure_type"]);  //桥梁结构类型
            int inspection_type = Convert.ToInt32(fc["bridge_inspection"]);           //检测类型
            double bridgeLength= Convert.ToDouble(fc["bridge_length"]);
            double bridgeWidth = Convert.ToDouble(fc["bridge_width"]);
            //int bridgeStructure_type, double bridgeLength, double bridgeWidth, int bridgeNspan, int inspection_type
            TempData["std_pdt_value"] = GetQuota.GetStdPdtValue(bridgeStructure_type, bridgeLength, bridgeWidth,1, inspection_type);
            return RedirectToAction("AddInspection_project");
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
        /// <param name="inspection_project">检测信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        [HttpPost]
        public ViewResult AddInspection_project(inspection_project inspection_project)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddInspection_project(inspection_project);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }

            return View();

        }
    }
}