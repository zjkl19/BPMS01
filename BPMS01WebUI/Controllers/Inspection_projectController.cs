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
using X.PagedList;

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
        /// 检测项目信息总览
        /// </summary>
        public ViewResult Index(int? page)
        {

            //第几页
            int pageNumber = page ?? 1;

            //每页显示多少条  
            int pageSize = 5;   //后期将该编码放到AppSetting里面

            //根据id排序  
            //var rs = repository.staff.OrderBy(x => x.id);

            //通过ToPagedList扩展方法进行分页  
            //IPagedList <staff> pagedList = rs.ToPagedList(pageNumber, pageSize);

            //将分页处理后的列表传给View  
            //return View(pagedList);

            var re = repository.inspection_project.OrderBy(x => x.id);

            //转换为视图模型
            var query = from p in re
                        select new IndexInspection_projectViewModel
                        {
                            name = p.name,
                            enter_date = p.enter_date,
                            exit_date = p.exit_date,
                            inspection_type = (inspection_type)(p.inspection_type),
                        };

            IPagedList<IndexInspection_projectViewModel> pagedList = query.ToPagedList(pageNumber, pageSize);
            return View(pagedList);
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
        public ActionResult GetStd_pdt_value(AddInspection_projectViewModel vm)
        {
            //int bridgeStructure_type, double bridgeLength, double bridgeWidth, int bridgeNspan, int inspection_type)
            int bridgeStructure_type = (int)vm.bridge_structure_type;  //桥梁结构类型
            int inspection_type = (int)vm.inspection_type;           //检测类型
            double bridgeLength= (double)vm.bridge_length;
            double bridgeWidth = (double)vm.bridge_width;
            int bridgeNspan = (int)vm.bridge_span_number;
            //int bridgeStructure_type, double bridgeLength, double bridgeWidth, int bridgeNspan, int inspection_type
            //TempData["std_pdt_value"] = GetQuota.GetStdPdtValue(bridgeStructure_type, bridgeLength, bridgeWidth, bridgeNspan, inspection_type);
            decimal std_pdt_value = GetQuota.GetStdPdtValue(bridgeStructure_type, bridgeLength, bridgeWidth, bridgeNspan, inspection_type);

            var newViewModel = new AddInspection_projectViewModel
            {
                contract_id=vm.contract_id,
                contract_name = vm.contract_name,
                inspection_type=vm.inspection_type,               
                bridge_id=vm.bridge_id,
                bridge_name=vm.bridge_name,
                bridge_structure_type = vm.bridge_structure_type,
                standard_price = std_pdt_value
            };

            ModelState.Clear();

            return View("AddInspection_project", newViewModel);
            //return View(newView);
            //return RedirectToAction("AddInspection_project", newViewModel);
        }

        /// <summary>
        /// 添加检测项目信息
        /// </summary>
        /// <returns>ViewResult:添加检测项目信息的视图</returns>
        public ViewResult AddInspection_project(AddInspection_projectViewModel vm)
        {
            //return View(new AddInspection_projectViewModel());
            return View(vm);

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

            return View(new AddInspection_projectViewModel());

        }
    }
}