using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BPMS01Domain.Models
{
    public class GetQuota
    {
        public double standard_product_value;  //标准产值
        
        //public double[,,] QuotaArray = new double[5, 4, 6] {

        //定额计算表格
        //请参考收费标准进行匹配
        //每一行表示每一种桥型
        protected double[,,] QuotaArray = new double[, , ] { { { 12000, 120, 30,120,30,0 },{25000, 150, 30,150,40,0 },{60000, 0, 0,0,0,30000 },{25000, 0, 0,0,0,10000 }},
                                       { { 30000, 100, 30,100,40,0 },{35000, 120, 30,120,40,0 },{65000, 0, 0,0,0,30000 },{30000, 0, 0,0,0,15000 } },
                                       { { 35000, 120, 100,120,40,0 },{50000, 150, 100,150,40,0 },{80000, 0, 0,0,0,40000 },{40000, 0, 0,0,0,20000 } },
                                       { { 50000, 120, 100,120,40,0 },{70000, 150, 100,150,40,0 },{100000, 0, 0,0,0,50000 },{60000, 0, 0,0,0,0 } },
                                       { { 120000, 150, 800,150,40,0 },{150000, 180, 800,180,40,0 },{200000, 0, 0,0,0,30 },{100000, 0, 0,0,0,0 } } };



        /// <summary>
        /// 该桥梁类主要方便用于计算产值，并无结构计算上的作用
        /// </summary>
        /// <param name="fc">包含项目id、职工id等在内的表单信息</param>
        /// <returns>添加成功返回1，否则返回0</returns>
        public double GetStdPdtValue(int bridgeStructure_type, double bridgeLength, double bridgeWidth, int bridgeNspan, int inspection_type)
        {
            var myBridge =new bridge(bridgeStructure_type, bridgeLength, bridgeWidth, bridgeNspan);
            var st = myBridge.structure_type;
            var it = inspection_type;
            var bl = myBridge.length;
            var bw = myBridge.width;
            var bns = myBridge.nspan;
            var basicFee = QuotaArray[st - 1, it - 1, 0];    //基本费用
            var blFee = QuotaArray[st - 1, it - 1, 1] * (bl > QuotaArray[st - 1, it - 1, 2] ?  bl- QuotaArray[st - 1, it - 1, 2] : 0);   //桥长累加费用
            var bwFee = QuotaArray[st - 1, it - 1, 3] * (bw > QuotaArray[st - 1, it - 1, 4] ? bw - QuotaArray[st - 1, it - 1, 4] : 0);   //桥宽累加费用
            var bnsFee = QuotaArray[st - 1, it - 1, 5] * (bns > 1 ? bns - 1 : 0);

            standard_product_value = basicFee    //基本费用
                + blFee + bwFee + bnsFee;    //累加费用

            return standard_product_value;
        }
    }

    /// <summary>
    /// 该“桥梁类”主要方便用于计算产值，并无结构计算上的作用
    /// </summary>
    public class bridge
    {
        public int  structure_type { get; set; }  //桥梁结构类型
        public double length { get; set; }  //桥梁长度
        public double width { get; set; }   //桥梁宽度
        public int nspan { get; set; }   //桥梁跨数

        public bridge(int bridgeStructure_type,double bridgeLength, double bridgeWidth, int bridgeNspan)
        {
            structure_type = bridgeStructure_type;
            length = bridgeLength;
            width = bridgeWidth;
            nspan = bridgeNspan;
        }

    }
}