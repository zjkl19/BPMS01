using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

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
            return View();

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

            return View();

        }
    }
}