using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

using Ninject;  //重要！

using BPMS01WebUI.Models;
using X.PagedList;

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
        /// 合同总览
        /// </summary>
        /// <returns>PartialView:所有合同信息的视图</returns>
        public ActionResult Index(int? page)
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

            var re = repository.contract.OrderBy(x => x.id);

            //转换为视图模型
            var query = from p in re
                        select new IndexContractViewModel
                        {
                            id = p.id,
                            no=p.no,
                            name=p.name,
                            amount=p.amount,
                            signed_data=p.signed_data,
                            deadline=p.deadline,
                            agmt_wk_cnt=p.agmt_wk_cnt,
                            project_location=p.project_location,
                            delegation_client=p.delegation_client,
                            dlg_contactperson=p.dlg_contactperson,
                            dlg_contactperson_phone=p.dlg_contactperson_phone,
                            accept_way=(accept_way)p.accept_way,
                            is_corporation_signed=(is_corporation_signed)p.is_corporation_signed,
                            is_client_signed=(is_client_signed)p.is_client_signed
                        };

            IPagedList<IndexContractViewModel> pagedList = query.ToPagedList(pageNumber, pageSize);
            return View(pagedList);
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
            return View(new AddContractViewModel());

        }


        /// <summary>
        /// 添加合同信息
        /// </summary>
        /// <param name="contract">合同信息</param>
        /// <returns>ViewResult:添加合同信息后返回的视图</returns>
        [HttpPost]
        public ViewResult AddContract(contract contract)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddContract(contract);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }

            return View(new AddContractViewModel());

        }
    }
}