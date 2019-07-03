using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Recognition
{
  public  class BitmapReader
    {
        [DllImport("clyrtnER.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        ///获取识别的细胞小图
        extern static void imageParser([MarshalAs(UnmanagedType.LPArray)] byte[] pImgBits, int nImgWidth, int nImgHeight, IntPtr PtlPtr);


        [StructLayout(LayoutKind.Sequential)]
        public struct CellImage
        {
            public int width;//小图像宽度
            public int height;//小图像高度

            public int x;//小图像在大图左上角坐标
            public int y;

            public int ntype;//类型

            public float dMetric;//暂不用
        }


        public static void TestImageParser()
        {
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
            //Mdata = Bmpdata;
            int size = Marshal.SizeOf(typeof(CellImage)) * 4000;
            byte[] ptlbytes = new byte[size];

            IntPtr pBuff = Marshal.AllocHGlobal(size);

            int result = 9;
            imageParser(Bmpdata, 1440, 1080, pBuff);

            int j = 3999;

            IntPtr pPonitor = new IntPtr(pBuff.ToInt64() + Marshal.SizeOf(typeof(CellImage)) * j);
            var p0 = (CellImage)Marshal.PtrToStructure(pPonitor, typeof(CellImage));

            Console.WriteLine(p0.width + "||" + p0.height);

            Console.WriteLine(result);
            Marshal.FreeHGlobal(pBuff);
            Console.WriteLine("OK END");
            tick = DateTime.Now.Ticks - tick;
            Console.WriteLine(DateTime.Now.ToLongTimeString());
            Console.WriteLine(tick / 10000000.0);

        }

        public List<CellImage> GetCellsBitmap(Byte[] OrginBitmap, int width, int height)
        {

            int size = Marshal.SizeOf(typeof(CellImage)) * 4000;
            IntPtr pBuff = Marshal.AllocHGlobal(size);

            imageParser(OrginBitmap, 1440, 1080, pBuff);

            int j = 3999;

            IntPtr pPonitor = new IntPtr(pBuff.ToInt64() + Marshal.SizeOf(typeof(CellImage)) * j);
            var p0 = (CellImage)Marshal.PtrToStructure(pPonitor, typeof(CellImage));

            int cellcount = p0.width;
            if (cellcount == 0)
            {//无Cell图像识别出
                return null;
            }
            if (cellcount > 0 && cellcount <= 3999)
            {
                List<CellImage> cells = new List<CellImage>(cellcount);
                for (int i = 0; i < cellcount; i++)
                {
                    IntPtr Ponitor = new IntPtr(pBuff.ToInt64() + Marshal.SizeOf(typeof(CellImage)) * i);
                    var p = (CellImage)Marshal.PtrToStructure(Ponitor, typeof(CellImage));
                    cells.Add(p);
                }
                return cells;
            }
            return null;


        }

    }
}

