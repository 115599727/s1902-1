using Microsoft.VisualStudio.TestTools.UnitTesting;
using Medicside.UriMeasure.Bussiness.Recognition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Medicside.UriMeasure.Bussiness.Recognition.Tests
{
    [TestClass()]
    public class BitmapReaderTests
    {
        [TestMethod()]
        public void GetdCellsBitmapTest()
        {

            Bitmap bmap = new Bitmap(@"D:\分类算法库 V1.0.0.1\sample\0063.bmp");
            MemoryStream ms = new MemoryStream();

            bmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            byte[] bytes = ms.ToArray();  //byte[]   bytes=   ms.ToArray(); 这两句都可以，至于区别么，下面有解释

            ms.Close();
            //Console.WriteLine(bytes.Length.ToString());

            //Console.WriteLine(bytes.Length);
            byte[] Bmpdata = new byte[bytes.Length - 1078];
            for (int i = 0; i < 1555200; i++)
            {
                Bmpdata[i] = bytes[1078 + i];
            }

            BitmapReader reader = new BitmapReader();
            int width = 1440;
            int height = 1080;
            var cellList = reader.GetCellsBitmap(Bmpdata, width, height);

            foreach (var item in cellList)
            {
                Console.WriteLine("width:{0} height:{0}", item.width, item.height);
            }
            Console.WriteLine(cellList.Count);



            Assert.AreEqual<int>(cellList.Count, 81);

        }

        [TestMethod()]
        public void GrayLevelAdjestTest()
        {

            // IntPtr pBuff1 = Marshal.AllocHGlobal(1555200*100);
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            long tick = DateTime.Now.Ticks;
            Bitmap bmap = new Bitmap(@"D:\分类算法库 V1.0.0.1\sample\0062.bmp");
            MemoryStream ms = new MemoryStream();

            bmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);

            byte[] bytes = ms.ToArray();  //byte[]   bytes=   ms.ToArray(); 这两句都可以，至于区别么，下面有解释

            ms.Close();
            //Console.WriteLine(bytes.Length.ToString());

            //Console.WriteLine(bytes.Length);
            byte[] Bmpdata = new byte[bytes.Length - 1078];
            for (int i = 0; i < 1555200; i++)
            {
                Bmpdata[i] = bytes[1078 + i];
            }
            //bytes.CopyTo(Bmpdata,1079);
            int count = 50;

            byte[] picData = new byte[Bmpdata.Length * count];
            for (int i = 0; i < count; i++)
            {
                Array.Copy(Bmpdata, 0, picData, i * 1555200, 1555200);
            }

            double r1 = 0;
            double r2 = 0;

             BitmapReader.GrayLevelAdjest(picData, 1440, 1080, count, ref r1, ref r2);
            Assert.Fail();
        }
    }
}