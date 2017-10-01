using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using BPMS01Domain.Entities;
using System.Data.Entity;

namespace BPMS01Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<staff> staff { get; set; }
        //这里第一个Staff是模型名，第2个是数据库中的表名

        public DbSet<contract> contract { get; set; }
    }
}