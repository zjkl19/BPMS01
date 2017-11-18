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
    public class R_inspection_project_staffController : Controller
    {
        //职工参与信息仓库（库模式）
        private IR_inspection_project_staffRepository repository;
        private IInspection_projectRepository inspectionProjectRepository;
        private IStaffRepository staffRepository;

        //构造函数
        public R_inspection_project_staffController(IR_inspection_project_staffRepository r_inspection_project_staffRepository, IInspection_projectRepository inspectionProjectRepository, IStaffRepository staffRepository)
        {
            this.repository = r_inspection_project_staffRepository;
            this.inspectionProjectRepository = inspectionProjectRepository;
            this.staffRepository = staffRepository;
        }


        /// <summary>
        ///通过职工id查询职工的参与情况
        /// </summary>
        public ViewResult  Query_R_inspection_project_staff_ByStaffId()
        {
            ViewBag.query = 0;
            return View(new Query_R_inspection_project_staff_ByStaffIdViewModel());
        }

        /// <summary>
        /// 提交表单中的职工id进行查询
        /// </summary>
        /// <returns>查询界面视图</returns>
        /*
        [HttpPost]
        public ViewResult Query_R_inspection_project_staff_ByStaffId(FormCollection fc)
        {
            ViewBag.query = 1;

            string staff_id = fc["staff_id"];
            ViewBag.staff_id = staff_id;

            return View();
        }
        */

        /// <summary>
        ///列出指定职工id的职工项目参与情况
        /// </summary>
        /// <param name="staff_id">职工id<see cref="staff.id"/></param>
        /// <param name="page">页数</param>
        /// <returns>含有职工项目参与信息的ViewResult<see cref="List_R_inspection_project_staff_ByStaffIdViewModel "/></returns>
        //[ChildActionOnly]
        //[HttpPost]
        public PartialViewResult  List_R_inspection_project_staff_ByStaffId(Query_R_inspection_project_staff_ByStaffIdViewModel vm, int? page)
        {
            var staff_id = vm.staff_id;

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


            var re01 = repository.r_inspection_project_staff.OrderBy(x => x.id);
            var re02 = inspectionProjectRepository.inspection_project.OrderBy(x => x.id);

            var query = from p in re02
                        join q in re01
                        on p.id equals q.inspection_project_id
                        where q.staff_id == staff_id
                        select new List_R_inspection_project_staff_ByStaffIdViewModel
                        {

                            inspection_project_name = p.name,
                            is_response = (is_response) q.is_response,
                            scene_coff = (scene_coff)q.scene_coff,
                            plan_coff = (plan_coff)q.plan_coff,
                            report_coff =(report_coff) q.report_coff,
                            report_check_coff = (report_check_coff)q.report_check_coff,
                            others_coff = (others_coff)q.others_coff,
                            production_value_ratio = q.production_value_ratio,
                            production_value = q.production_value
                        };

            ViewBag.sumProjects = query.Count();
            ViewBag.sumProductValue = query.Sum(p => p.production_value); 

            IPagedList<List_R_inspection_project_staff_ByStaffIdViewModel> pagedList = query.ToPagedList(pageNumber, pageSize);

            return PartialView(pagedList);
        }



        /// <summary>
        ///列出指定项目的职工项目参与情况
        /// </summary>
        /// <param name="inspection_project_id">职工工号<see cref="inspection_project.id"/></param>
        /// <returns>PartialViewResult<see cref="List_R_inspection_project_staff_ByStaffIdViewModel "/></returns>

        //[ChildActionOnly]
        //[HttpPost]

        //public PartialViewResult List_R_inspection_project_staff_ByInspection_projectId(Guid inspection_project_id)
        //AddR_inspection_project_staffViewModel
        //Guid inspection_project_id = new Guid()
        public PartialViewResult List_R_inspection_project_staff_ByInspection_projectId(AddR_inspection_project_staffViewModel vm)
        {
            //string str = "{00000000-0000-0000-0000-000000000000}";
            //var inspection_project_id = vm.inspection_project_id;

            //ref:
            //string str = "{F3006154-054B-47A7-AACC-0508688F90CF}";
            //Guid g = new Guid(str);
            var inspection_project_id = vm.inspection_project_id;

            var re01 = repository.r_inspection_project_staff;
            var re02 = staffRepository.staff;

            var query = from p in re01
                        join q in re02
                        on p.staff_id equals q.id
                        where p.inspection_project_id == inspection_project_id
                        select new List_R_inspection_project_staff_ByInspection_projectIdViewModel
                        {

                            staff_no=q.no,
                            staff_name=q.name,
                            is_response=(is_response)p.is_response,
                            scene_coff=(scene_coff)p.scene_coff,
                            plan_coff=(plan_coff)p.plan_coff,
                            report_coff=(report_coff)p.report_coff,
                            report_check_coff=(report_check_coff)p.report_check_coff,
                            others_coff=(others_coff)p.others_coff,
                            production_value_ratio=p.production_value_ratio,
                            production_value=p.production_value
                        };
            //query = null;
            return PartialView(query);
        }

        /// <summary>
        /// 添加项目参与信息
        /// </summary>
        /// <returns>ViewResult:添加项目参与信息的视图</returns>
        public ViewResult AddR_inspection_project_staff()
        {
            ViewBag.query = 0;
            return View(new AddR_inspection_project_staffViewModel());

        }


        /// <summary>
        /// 添加项目参与信息
        /// </summary>
        /// <param name="r_inspection_project_staff">"桥梁检测-职工"信息</param>
        /// <returns>ViewResult:添加添加项目参与信息后返回的视图</returns>
        [HttpPost]
        public ViewResult AddR_inspection_project_staff(r_inspection_project_staff r_inspection_project_staff)
        {
            ViewBag.message = "添加信息成功！";

            var result = repository.AddR_inspection_project_staff(r_inspection_project_staff);

            if (result == false)
            {
                ViewBag.message = "添加信息失败！";
            }

            //
            ViewBag.query = 1;
            ViewBag.inspection_project_id = r_inspection_project_staff.inspection_project_id;

            var myViewModel = new AddR_inspection_project_staffViewModel
            {
                inspection_project_id = r_inspection_project_staff.inspection_project_id
            };

            return View(myViewModel);

        }
    }
}