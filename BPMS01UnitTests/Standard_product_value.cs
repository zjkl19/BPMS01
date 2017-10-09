using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BPMS01Domain.Models;

namespace BPMS01UnitTests
{
    [TestClass]
    public class Standard_product_value
    {
        [TestMethod]
        public void TestStdPdtValue()
        {
            //arrange
            int bridgeStructure_type = 2;

            int inspection_type = 2;

            double bridgeLength = 35;
            double bridgeWidth = 42;
            int bridgeNspan = 2;


            var GQ = new GetQuota();

            //action
            var std_pdt_price = GQ.GetStdPdtValue(bridgeStructure_type, bridgeLength, bridgeWidth, bridgeNspan, inspection_type);

            double key=35000+120*(35-30)+120*(42-40)+0*(2 - 1);    //答案
            //assert
            Assert.AreEqual(std_pdt_price, key);
        }
    }
}
