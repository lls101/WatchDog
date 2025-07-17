using System;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace WatchDog
{
    public class Package : IDisposable
    {
        #region Constructors
        public Package()
        {
            _buf = new byte[1024 * 100];
            _step = 0;
        }

        public Package(byte[] src, int lens)
        {
            _buf = new byte[1024 * 100];
            _step = 0;
            Array.Copy(src, 0, _buf, _step, lens);
            fill_lens = lens;
        }

        public void Dispose()
        {
            _step = 0;
            _buf = null;
        }

        public void Clear()
        {
            _step = 0;
        }

        //public object Clone()
        //{
        //    using (MemoryStream stream = new MemoryStream())
        //    {
        //        if (this.GetType().IsSerializable)
        //        {
        //            BinaryFormatter formatter = new BinaryFormatter();
        //            formatter.Serialize(stream, this);
        //            stream.Position = 0;
        //            return formatter.Deserialize(stream);
        //        }
        //        return null;
        //    }
        //}

        public void lens()
        {
            ushort w = (ushort)(Length - 11);

            byte b1 = (byte)w;
            byte b2 = (byte)(w >> 8);

            _buf[7] = b1;
            _buf[8] = b2;
        }

        public void sums()
        {
            ushort w = (ushort)(Length - 11);

            byte sum = 0;
            for (int i = 4; i < 4 + w + 5; i++)
            {
                sum += _buf[i];
            }
            _buf[9 + w] = sum;
        }

        //public bool check_iec_sum(byte crc)
        //{
        //    ushort w = (ushort)(fill_lens - 11);

        //    byte sum = 0;
        //    for (int i = 4; i < w + 5; i++)
        //    {
        //        sum += _buf[i];
        //    }
        //    return sum == crc;
        //}
        #endregion

        #region push
        public void push(byte b)
        {
            _buf[_step] = b;
            _step++;
        }

        public void push(byte[] datas, int length)
        {
            Array.Copy(datas, 0, _buf, _step, length);
            _step += length;
        }

        public void push(byte[] datas)
        {
            push(datas, datas.Length);
        }

        public void push(ushort w)
        {
            byte b1 = (byte)w;
            byte b2 = (byte)(w >> 8);
            push(b1);
            push(b2);
        }

        public void push(uint i)
        {
            byte b1 = (byte)i;
            byte b2 = (byte)(i >> 8);
            byte b3 = (byte)(i >> 16);
            byte b4 = (byte)(i >> 24);
            push(b1);
            push(b2);
            push(b3);
            push(b4);
        }

        public void push(ulong l)
        {
            byte b1 = (byte)l;
            byte b2 = (byte)(l >> 8);
            byte b3 = (byte)(l >> 16);
            byte b4 = (byte)(l >> 24);
            byte b5 = (byte)(l >> 32);
            byte b6 = (byte)(l >> 40);
            byte b7 = (byte)(l >> 48);
            byte b8 = (byte)(l >> 56);
            push(b1);
            push(b2);
            push(b3);
            push(b4);
            push(b5);
            push(b6);
            push(b7);
            push(b8);
        }

        /// <summary>
        /// 字符串长度不能超过255
        /// </summary>
        public void push(string value)
        {
            byte[] bArr = ToBytes(value);
            push((byte)bArr.Length);
            push(bArr, bArr.Length);
        }

        public void push(string s, int len)
        {
            byte[] pack = Encoding.UTF8.GetBytes(s);
            for (int i = 0; i < len; i++)
            {
                if (i < pack.Length)
                {
                    push(pack[i]);
                }
                else
                {
                    push((byte)0x00);
                }
            }
        }

        public void push_ustr(string s)
        {
            byte[] pack = Encoding.Default.GetBytes(s);
            for (int i = 0; i < pack.Length; i++)
            {
                push(pack[i]);
            }
        }

        public void push(System.Net.IPAddress ip)
        {
            byte[] bArr = ip.GetAddressBytes();
            push((byte)bArr.Length);
            push(bArr);
        }
        #endregion

        #region parse
        public byte parseByte()
        {
            return _buf[_step++];
        }

        public byte[] parseBytes(int length)
        {
            byte[] bArr = new byte[length];
            System.Array.Copy(_buf, _step, bArr, 0, length);
            _step += length;
            return bArr;
        }

        public ushort parseShort()
        {
            byte b1 = parseByte();
            byte b2 = parseByte();
            return (ushort)((ushort)b1 | (ushort)b2 << 8);
        }

        public uint parseInt()
        {
            byte b1 = parseByte();
            byte b2 = parseByte();
            byte b3 = parseByte();
            byte b4 = parseByte();

            return (uint)((uint)b1 | (uint)b2 << 8 | (uint)b3 << 16 | (uint)b4 << 24);
        }

        public ulong parseLong()
        {
            byte b1 = parseByte();
            byte b2 = parseByte();
            byte b3 = parseByte();
            byte b4 = parseByte();
            byte b5 = parseByte();
            byte b6 = parseByte();
            byte b7 = parseByte();
            byte b8 = parseByte();

            return (ulong)((ulong)b1 | (ulong)b2 << 8 | (ulong)b3 << 16 | (ulong)b4 << 24 |
                (ulong)b5 << 32 | (ulong)b6 << 40 | (ulong)b7 << 48 | (ulong)b8 << 56);
        }

        public string parseString()
        {
            byte len = parseByte();
            byte[] bArr = parseBytes(len);
            return ToString(bArr);
        }

        public string parseString(int len)
        {
            System.Diagnostics.Debug.Assert(len < 1000);

            int realSize = len;

            byte[] dst = new byte[len + 2];
            Array.Clear(dst, 0, len + 2);

            for (int i = 0; i < len; i++)
            {
                byte tmp = parseByte();
                dst[i] = tmp;

                if (realSize == len)
                {
                    if (tmp == 0x00)
                    {
                        realSize = i;
                    }
                }
            }

            string s = Encoding.UTF8.GetString(dst, 0, realSize);
            return s;
        }

        public void parseSkip(int length)
        {
            _step += length;
        }

        public System.Net.IPAddress parseIPAddress()
        {
            System.Net.IPAddress ipaddress;

            byte b = parseByte();
            if (b == 4)
            {
                object[] objArr = new object[] {  parseByte(),
                                                  parseByte(),
                                                  parseByte(),
                                                  parseByte() };
                ipaddress = System.Net.IPAddress.Parse(String.Format("{0}.{1}.{2}.{3}", objArr));
            }
            else if (b == 6)
            {
                object[] objArr2 = new object[] { parseByte(),
                                                  parseByte(),
                                                  parseByte(),
                                                  parseByte(),
                                                  parseByte(),
                                                  parseByte() };
                ipaddress = System.Net.IPAddress.Parse(String.Format("{0}.{1}.{2}.{3}.{4}.{5}", objArr2));
            }
            else
            {
                throw new Exception("目前只支持IPV4和IPV6两种IP！");
            }
            return ipaddress;
        }


        #endregion

        #region Members
        private byte[] _buf = null;
        private int _step = 0;

        private int fill_lens = 0;

        public int Length
        {
            get
            {
                return _step;
            }
        }

        public byte[] Buffer
        {
            get
            {
                return _buf;
            }
        }

        public bool Empty
        {
            get
            {
                return Length >= fill_lens;
            }
        }
        #endregion

        #region key convert
        public byte[] ToBytes(string value)
        {
            return System.Text.Encoding.Default.GetBytes(value);
        }

        public string ToString(byte[] value)
        {
            return System.Text.Encoding.Default.GetString(value);
        }

        public static ushort LoWord(int dwValue)
        {
            return (ushort)dwValue;
        }

        public static ushort HiWord(int dwValue)
        {
            return (ushort)(dwValue >> 16);
        }

        public static byte LoByte(ushort wValue)
        {
            return (byte)wValue;
        }

        public static byte HiByte(ushort wValue)
        {
            return (byte)(wValue >> 8);
        }

        public static uint MakeLong(ushort lowPart, ushort highPart)
        {
            return (uint)(((uint)lowPart) | (uint)(highPart << 16));
        }

        public static ushort MakeWord(byte lowPart, byte highPart)
        {
            return (ushort)(((ushort)lowPart) | (ushort)(highPart << 8));
        }

        public static byte bcd2hex(byte bcd)
        {
            return (byte)(((bcd / 10) << 4) | (bcd % 10));
        }

        public static short bcd2hex(short bcd)
        {
            short shift = 0xFF;
            short result = 0;
            for (int count = 0; count < 4; count++)
            {
                var value = bcd2hex((byte)((bcd & shift << (8 * count)) >> (8 * count)));
                result *= 100;
                result += value;
            }
            return result;
        }

        public static int bcd2hex(int bcd)
        {
            int shift = 0xFF;
            int result = 0;
            for (int count = 0; count < 4; count++)
            {
                var value = bcd2hex((byte)((bcd & shift << (8 * count)) >> (8 * count)));
                result *= 100;
                result += value;
            }
            return result;
        }

        public static long bcd2hex(long bcd)
        {
            long shift = 0xFF;
            long result = 0;
            for (int count = 0; count < 8; count++)
            {
                var value = bcd2hex((byte)((bcd & shift << (8 * count)) >> (8 * count)));
                result *= 100;
                result += value;
            }
            return result;
        }

        public static byte hex2bcd(byte hex)
        {
            byte n = hex;
            byte bcd = 0;
            byte shiftNum = 0;

            while (n > 0)
            {
                bcd |= (byte)((n % 10) << shiftNum);
                shiftNum += 4;
                n /= 10;
            }

            return bcd;
        }

        public static short hex2bcd(short hex)
        {
            short n = hex;
            short bcd = 0;
            int shiftNum = 0;

            while (n > 0)
            {
                bcd |= (short)((n % 10) << shiftNum);
                shiftNum += 4;
                n /= 10;
            }

            return bcd;
        }

        public static int hex2bcd(int hex)
        {
            int n = hex;
            int bcd = 0;
            int shiftNum = 0;

            while (n > 0)
            {
                bcd |= (int)((n % 10) << shiftNum);
                shiftNum += 4;
                n /= 10;
            }

            return bcd;
        }

        public static long hex2bcd(long hex)
        {
            long n = hex;
            long bcd = 0;
            int shiftNum = 0;

            while (n > 0)
            {
                bcd |= (long)((n % 10) << shiftNum);
                shiftNum += 4;
                n /= 10;
            }

            return bcd;
        }

        public static int GetUTF8Length(string str)
        {
            return System.Text.Encoding.UTF8.GetByteCount(str);
        }
        #endregion
    }
}
