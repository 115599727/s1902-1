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
            ///尿检测操作
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

        [TestMethod()]
        public void CameraConnctionTestTest()
        {
            MorphologyEquipment me = new MorphologyEquipment();
            Assert.IsTrue(me.CameraConnctionTest());
        }

        [TestMethod()]
        public void EquipmentPortIsConnectedTest()
        {
            MorphologyEquipment me = new MorphologyEquipment();
            Assert.IsTrue(me.EquipmentPortIsConnected());
        }

        [TestMethod()]
        public void EquipmentAdjectGrayLeveTest()
        {

            MorphologyEquipment me = new MorphologyEquipment();
            for (int i = 0; i < 10; i++)
            {
                me.EquipmentAdjectGrayLeve();
                Thread.Sleep(1000);
            }


            Assert.IsTrue(true);


        }
        MorphologyEquipment me = new MorphologyEquipment();
        [TestMethod()]
        public void CheckResultTest()
        {

            Assert.IsTrue(me.CheckResult());

        }

        [TestMethod()]
        public void GetFlashVTest()
        {
            var t = me.FlashGetVol();
            Assert.IsTrue(t == 2222);
        }

        [TestMethod()]
        public void FlashAddVolTest()
        {
            bool r = me.FlashAddVol(42);
            Assert.IsTrue(r);
        }

        [TestMethod()]
        public void FlashDecVolTest()
        {
            bool r = me.FlashDecVol(42);
            Assert.IsTrue(r);
        }

        [TestMethod()]
        public void FlashSetVolTest()
        {
            bool r = me.FlashSetVol(1706);
            Assert.IsTrue(r);
        }

        [TestMethod()]
        public void EquResetTest()
        {
            var r = me.EquReset();
            Assert.IsTrue(r);
        }

        [TestMethod()]
        public void EquipmentSetupTest()
        {
            var r = me.EquipmentSetup();
            Assert.IsTrue(r);
        }

        [TestMethod()]
        public void EquipmentblankMeasureTest()
        {
            var r = me.EquipmentblankMeasure();
            Assert.IsTrue(r);
        }
    }
}