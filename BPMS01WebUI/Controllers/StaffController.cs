using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

using BPMS01WebUI.Models;

using X.PagedList;

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
        public ActionResult Index(int?page)
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

            var re = repository.staff.OrderBy(x => x.id);

            //转换为视图模型
            var query = from p in re
                        select new IndexStaffViewModel
                        {
                            id = p.id,
                            staff_no = p.no,
                            staff_password = p.password,    //optional
                            staff_name = p.name,
                            gender = (gender)(p.gender),
                            office_phone = p.office_phone,
                            mobile_phone = p.mobile_phone,
                            position = (position)(p.position),
                            job_title = (job_title)(p.job_title),
                            education = (education)(p.education),
                            hiredate = p.hiredate
                        };

            IPagedList<IndexStaffViewModel> pagedList = query.ToPagedList(pageNumber, pageSize);
            return View(pagedList);
        }

        /// <summary>
        /// 列出职工信息
        /// </summary>
        /// <returns>PartialView:所有职工信息的视图</returns>
        public PartialViewResult ListStaff()
        {
            return PartialView(repository.staff);
        }

        /// <summary>
        /// 添加职工信息
        /// </summary>
        /// <returns>ViewResult:添加职工信息的视图</returns>
        public ViewResult AddStaff()
        {
            //参考代码：var newData = new staff();
            return View(new AddStaffViewModel());
        }

        /// <summary>
        /// 添加职工信息
        /// </summary>
        /// <param name="fc">含有职工信息的表单</param>
        /// <returns>ViewResult:添加职工信息后返回的视图</returns>
        [HttpPost]
        public ViewResult AddStaff(staff staff)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddStaff(staff);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }
            return View(new AddStaffViewModel());

        }
    }
}