﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;


using System.Security.Cryptography;     //Md5加密
using System.Text;

namespace BPMS01Domain.Concrete
{
    public class EFStaffRepository:IStaffRepository
    {
        private EFDbContext context = new EFDbContext();

        //全部职工信息
        public IEnumerable<staff> staff
        {
            get
            {
                //var query = from p in context.staff
                 //           where p.staff_no == 1743
                 //           select p;
                //return query;
                return context.staff;
            }
        }

        /// <summary>
        ///通过工号查询职工信息
        /// </summary>
        /// <param name="staff_no">职工工号(与数据库中的定义相关联)<see cref="staff"/></param>
        /// <returns>指定工号的职工详细信息<see cref="staff"/></returns>
        public IEnumerable<staff> QueryStaffBystaff_no(int staff_no)
        {
            return context.staff.Where(p=>p.staff_no==staff_no);
        }

        public IQueryable<enum_staff> enum_staff 
        {
            get
            {
                var query = from p in context.staff
                            select new enum_staff
                            {
                                id = p.id,
                                staff_no = 1633,
                                staff_password = p.staff_password,
                                staff_name = p.staff_name,
                                gender = (gender)(p.gender),
                                //typeof(LevelPower).GetCustomAttributes(typeof(Description), false);          
                                office_phone = p.office_phone,
                                mobile_phone = p.mobile_phone,
                                //position=(position)p.position,T
                                //job_title=(job_title)p.job_title,
                                //education=(education)p.education,
                                position = (position)(1),
                                job_title = (job_title)(1),
                                education = (education)(2),
                                hiredate = p.hiredate
                            };
                return query;
            }
        }
    

    /// <summary>
    ///往数据库中添加职工信息
    /// </summary>
    /// <param name="staff">包含职工工号，密码等在内的信息</param>
    /// <returns>true表示添加成功,false表示添加失败</returns>
    public bool AddStaff(staff staff)
        {
            staff.id = Guid.NewGuid().ToString("N"); //去掉短横杠

            MD5 md5 = MD5.Create(); //实例化一个md5对像
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(staff.staff_password));//加密后是一个字节类型的数组

            staff.staff_password = "";

            //字符串拼接
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                staff.staff_password = staff.staff_password + bytes[i].ToString("x2");
                //sb.Append(bytes[i]);
            }

            try
            {
                context.staff.Add(staff);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            //catch (DbEntityValidationException dbEx)
            {
                throw new Exception("数据库添加信息出现异常。");     
            }
        }

    }
}