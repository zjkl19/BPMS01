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
    public class ContractController : Controller
    {
        //合同仓库（库模式）
        private IContractRepository repository;

        //构造函数
        public ContractController(IContractRepository contractRepository)
        {
            this.repository = contractRepository;
        }

        /// <summary>
        /// 列出合同信息
        /// </summary>
        /// <returns>PartialView:所有合同信息的视图</returns>
        public PartialViewResult ListContract()
        {
            return PartialView(repository.contract);
        }


        /// <summary>
        /// 添加合同信息
        /// </summary>
        /// <returns>ViewResult:添加合同信息的视图</returns>
        public ViewResult AddContract()
        {
            return View();

        }

        /// <summary>
        /// 往合同模型添加职工id信息，往视图模型添加职工信息
        /// </summary>
        /// <param name="staffInfo">含有职工id，工号，姓名的信息</param>
        /// <returns>ViewResult:含有职工id，工号，姓名的信息的AddContract View</returns>
        [NonAction]
        [HttpPost]
        public ViewResult AddContract(staff staffInfo)
        {
            var myViewModel = new AddContractViewModel
            {
                staff_id = staffInfo.id,
                staff_no = staffInfo.staff_no,
                staff_name = staffInfo.staff_name
            };
            return View(myViewModel);

        }

        /// <summary>
        /// 添加合同信息
        /// </summary>
        /// <param name="fc">含有合同信息的表单</param>
        /// <returns>ViewResult:添加合同信息后返回的视图</returns>
        [HttpPost]
        public ViewResult AddContract(FormCollection fc)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddContract(fc);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }

            return View();

        }
    }
}