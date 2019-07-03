using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicside.UriMeasure.Bussiness.Equipment
{
   public class Crc16
    {
        static ushort[] table = new ushort[256];

        public ushort ComputeChecksum(params byte[] bytes)
        {
            ushort crc = 0;
            for (int i = 0; i < bytes.Length; ++i)
            {
                byte index = (byte)(crc ^ bytes[i]);
                crc = (ushort)((crc >> 8) ^ table[index]);
            }
            return crc;
        }

        public byte[] ComputeChecksumBytes(params byte[] bytes)
        {
            ushort crc = ComputeChecksum(bytes);
            return BitConverter.GetBytes(crc);
        }

        public Crc16(Crc16Mode mode)
        {
            ushort polynomial = (ushort)mode;
            ushort value;
            ushort temp;
            for (ushort i = 0; i < table.Length; ++i)
            {
                value = 0;
                temp = i;
                for (byte j = 0; j < 8; ++j)
                {
                    if (((value ^ temp) & 0x0001) != 0)
                    {
                        value = (ushort)((value >> 1) ^ polynomial);
                    }
                    else
                    {
                        value >>= 1;
                    }
                    temp >>= 1;
                }
                table[i] = value;
            }


        }
        public enum Crc16Mode : ushort { Standard = 0xA001, CcittKermit = 0x8408 }


        public static int CRC16_MODBUS(byte[] puchMsg)
        {
            int wCRCin = 0x0000; //初值
            int wCPoly = 0x1021; //多项式
            int wChar = 0;
            int k = 0;
            int usDataLen = puchMsg.Length;
            while (usDataLen-- > 0)
            {
                wChar = puchMsg[k++];
                wCRCin ^= wChar << 8;
                for (int i = 0; i < 8; i++)
                {
                    if ((wCRCin & 0x8000) > 0)
                        wCRCin = (UInt16)((wCRCin << 1) ^ wCPoly);
                    else
                        wCRCin = (UInt16)(wCRCin << 1);
                }
            }
            return (wCRCin);
        }
    }
}
