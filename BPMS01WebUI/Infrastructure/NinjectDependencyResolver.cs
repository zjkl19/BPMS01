﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using Ninject;

using BPMS01Domain;
using BPMS01Domain.Abstract;
using BPMS01Domain.Concrete;

namespace BPMS01WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            //将绑定放这里
            kernel.Bind<IStaffRepository>().To<EFStaffRepository>();    //绑定staff
            kernel.Bind<IContractRepository>().To<EFContractRepository>();     //绑定contract
            kernel.Bind<IBridgeRepository>().To<EFBridgeRepository>();     //绑定bridge
            kernel.Bind<IInspection_projectRepository>().To<EFInspection_projectRepository>();     //绑定Inspection_project
            kernel.Bind<IR_inspection_project_staffRepository>().To<EFR_inspection_project_staffRepository>();     //绑定r_inspection_project_staff

        }
    }
}