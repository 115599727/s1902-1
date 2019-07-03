using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medicside.UriMeasure.Bussiness.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Equipment.Tests
{
    [TestClass()]
    public class PortControlHelperTests
    {
        [TestMethod()]
        public void GetComPortsTest()
        {
            var strArr= PortControlHelper.GetComPorts();
            Assert.IsTrue(strArr.Length > 0);
        }
    }
}