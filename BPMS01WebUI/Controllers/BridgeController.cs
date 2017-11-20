using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

using BPMS01WebUI.Models;

using X.PagedList;

using Ninject;  //重要！

namespace BPMS01WebUI.Controllers
{
    public class BridgeController : Controller
    {
        //桥梁仓库（库模式）
        private IBridgeRepository repository;

        //构造函数
        public BridgeController(IBridgeRepository bridgeRepository)
        {
            this.repository = bridgeRepository;
        }

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

            var re = repository.bridge.OrderBy(x => x.id);

            //转换为视图模型
            var query = from p in re
                        select new IndexBridgeViewModel
                        {
                            name=p.name,
                            length=p.length,
                            width=p.width,
                            span_number=p.span_number,
                            structure_type=(structure_type)p.structure_type
                        };

            IPagedList<IndexBridgeViewModel> pagedList = query.ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }




        /// <summary>
        /// 列出桥梁信息
        /// </summary>
        /// <returns>PartialView:所有桥梁信息的视图</returns>
        public PartialViewResult ListBridge()
        {
            return PartialView(repository.bridge);
        }


        /// <summary>
        /// 添加桥梁信息
        /// </summary>
        /// <returns>ViewResult:添加桥梁信息的视图</returns>
        public ViewResult AddBridge()
        {
            return View(new AddBridgeViewModel());

        }

        /// <summary>
        /// 添加桥梁信息
        /// </summary>
        /// <param name="bridge">桥梁信息</param>
        /// <returns>ViewResult:添加桥梁信息后返回的视图</returns>
        [HttpPost]
        public ViewResult AddBridge(bridge bridge)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddBridge(bridge);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }

            return View(new AddBridgeViewModel());

        }
    }
}