using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;   //FormCollection

using BPMS01Domain.Abstract;
using BPMS01Domain.Entities;

namespace BPMS01Domain.Concrete
{
    public class EFBridgeRepository : IBridgeRepository
    {
        private BPMSContext context = new BPMSContext();

        //全部桥梁信息
        public IEnumerable<bridge> bridge
        {
            get
            {
                return context.bridge;
            }
        }


        [HttpPost]
        public bool AddBridge(bridge bridge)
        {

            bridge.id = Guid.NewGuid(); //去掉短横杠

            try
            {
                context.bridge.Add(bridge);
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