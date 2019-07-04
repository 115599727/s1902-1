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
      public  extern static void imageParser([MarshalAs(UnmanagedType.LPArray)] byte[] pImgBits, int nImgWidth, int nImgHeight, IntPtr PtlPtr);

      [DllImport("clyrtnF.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        // 灰度调整接口：
        //extern "C" __declspec(dllexport) void graylevelAdjust(unsigned char* pImgBits, int nImgWidth, int nImgHeight, int len, double* result);
      extern static void graylevelAdjust([MarshalAs(UnmanagedType.LPArray)] byte[] pImgBits, int nImgWidth, int nImgHeight, int len, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] double[] result);


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

        /// <summary>
        /// 灰度调节
        /// </summary>
        /// <param name="bitmaps"></param>
        /// <param name="imgWidth"></param>
        /// <param name="imgHeight"></param>
        /// <param name="imgCount"></param>
        /// <param name="r0">图像灰度平均值</param>
        /// <param name="r1">灰度调整步数。小于零时往亮处调整，大于零时往暗处调整。</param>
        public static void GrayLevelAdjest(Byte[] bitmaps,int imgWidth,int imgHeight,int imgCount,ref double r0,ref double r1)
        {


            double[] resultdata = new double[2];


            graylevelAdjust(bitmaps, 1440, 1080, imgCount, resultdata);


            r0 = resultdata[0];
            r1 = resultdata[1];
        }
    }
}

