using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medicside.UriMeasure.Bussiness.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Medicside.UriMeasure.Bussiness.Equipment.Tests
{
    [TestClass()]
    public class MorphologyEquipmentTests
    {
        [TestMethod()]
        public void MeasureTest()
        {
            MorphologyEquipment me = new MorphologyEquipment();

            Dictionary<string, string> list = me.Measure(null);
            Thread.Sleep(2000);
            Assert.IsNull(list);
        }

        [TestMethod()]
        public void SendShotTest()
        {
            MorphologyEquipment me = new MorphologyEquipment();
            me.SendShot();
        }
    }
}