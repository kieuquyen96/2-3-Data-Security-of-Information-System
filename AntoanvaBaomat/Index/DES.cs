using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Index
{
    class DES
    {
        public static String[] key;
        public static String hex2binary(String hexvalue)
        {
            return hexvalue.Aggregate(new StringBuilder(), (builder, c) =>
                    builder.Append(Convert.ToString(Convert.ToInt64(c.ToString(), 16), 2).PadLeft(4, '0'))).ToString();
        }
        public static String bin2hex(String bin)
        {
            int rest = bin.Length % 4;
            bin = bin.PadLeft(rest, '0'); //pad the length out to by divideable by 4

            string output = "";

            for (int i = 0; i <= bin.Length - 4; i += 4)
            {
                output += string.Format("{0:X}", Convert.ToByte(bin.Substring(i, 4), 2));
            }
            return output;
        }
        public static string StringToBinary(string data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (char c in data.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
            return sb.ToString();
        }
        public static string BinaryToString(string data, System.Text.Encoding encoding)
        {
            List<Byte> byteList = new List<Byte>();

            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return encoding.GetString(byteList.ToArray());
        }
        public static String string2hex(string str)
        {
            var sb = new StringBuilder();
            foreach (var t in str)
            {
                sb.Append(Convert.ToInt32(t).ToString("x"));
            }

            return sb.ToString(); 
        }


        public static String hex2string(String hexInput, System.Text.Encoding encoding)//System.Text.Encoding.UTF8
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }
        public static String HoanViKhoiTao(String s)
        {
            return "" + s[57] + s[49] + s[41] + s[33] + s[25] + s[17] + s[9] + s[1] +
                s[59] + s[51] + s[43] + s[35] + s[27] + s[19] + s[11] + s[3] +
                s[61] + s[53] + s[45] + s[37] + s[29] + s[21] + s[13] + s[5] +
                s[63] + s[55] + s[47] + s[39] + s[31] + s[23] + s[15] + s[7] +
                s[56] + s[48] + s[40] + s[32] + s[24] + s[16] + s[8] + s[0] +
                s[58] + s[50] + s[42] + s[34] + s[26] + s[18] + s[10] + s[2] +
                s[60] + s[52] + s[44] + s[36] + s[28] + s[20] + s[12] + s[4] +
                s[62] + s[54] + s[46] + s[38] + s[30] + s[22] + s[14] + s[6];
        }
        public static String HoanViKetThuc(String s)
        {
            return "" + s[39] + s[7] + s[47] + s[15] + s[55] + s[23] + s[63] + s[31] +
                s[38] + s[6] + s[46] + s[14] + s[54] + s[22] + s[62] + s[30] +
                s[37] + s[5] + s[45] + s[13] + s[53] + s[21] + s[61] + s[29] +
                s[36] + s[4] + s[44] + s[12] + s[52] + s[20] + s[60] + s[28] +
                s[35] + s[3] + s[43] + s[11] + s[51] + s[19] + s[59] + s[27] +
                s[34] + s[2] + s[42] + s[10] + s[50] + s[18] + s[58] + s[26] +
                s[33] + s[1] + s[41] + s[9] + s[49] + s[17] + s[57] + s[25] +
                s[32] + s[0] + s[40] + s[8] + s[48] + s[16] + s[56] + s[24];
        }
        public static String HoanViKhoa(String s)
        {
            return "" + s[56] + s[48] + s[40] + s[32] + s[24] + s[16] + s[8] +
                         s[0] + s[57] + s[49] + s[41] + s[33] + s[25] + s[17] +
                         s[9] + s[1] + s[58] + s[50] + s[42] + s[34] + s[26] +
                         s[18] + s[10] + s[2] + s[59] + s[51] + s[43] + s[35] +
                         s[62] + s[54] + s[46] + s[38] + s[30] + s[22] + s[14] +
                         s[6] + s[61] + s[53] + s[45] + s[37] + s[29] + s[21] +
                         s[13] + s[5] + s[60] + s[52] + s[44] + s[36] + s[28] +
                         s[20] + s[12] + s[4] + s[27] + s[19] + s[11] + s[3];
        }
        public static String NenKhoa(String s)
        {
            return "" + s[13] + s[16] + s[10] + s[23] + s[0] + s[4] + s[2] + s[27] +
                         s[14] + s[5] + s[20] + s[9] + s[22] + s[18] + s[11] + s[3] +
                         s[25] + s[7] + s[15] + s[6] + s[26] + s[19] + s[12] + s[1] +
                         s[40] + s[51] + s[30] + s[36] + s[46] + s[54] + s[29] + s[39] +
                         s[50] + s[44] + s[32] + s[47] + s[43] + s[48] + s[38] + s[55] +
                         s[33] + s[52] + s[45] + s[41] + s[49] + s[35] + s[28] + s[31];
        }
        public static void TaoKhoaDES(String k)
        {
            key = new String[17];
            k = HoanViKhoa(k);
            String kl = k.Substring(0, 28); // Lấy nửa khóa trái
            String kr = k.Substring(28, 28); // Lấy nửa khóa phải
            for (int i = 1; i <= 16; i++)
            {
                if (i == 1 || i == 2 || i == 9 || i == 16)
                {
                    kl = kl.Substring(1) + kl.Substring(0, 1);
                    kr = kr.Substring(1) + kr.Substring(0, 1);
                }
                else
                {
                    kl = kl.Substring(2) + kl.Substring(0, 2);
                    kr = kr.Substring(2) + kr.Substring(0, 2);
                }
                k = kl + kr;
                key[i] = NenKhoa(k);
            }
        }
        public static String Expand(String s)
        {
            return "" + s[31] + s[0] + s[1] + s[2] + s[3] + s[4] +
                         s[3] + s[4] + s[5] + s[6] + s[7] + s[8] +
                         s[7] + s[8] + s[9] + s[10] + s[11] + s[12] +
                         s[11] + s[12] + s[13] + s[14] + s[15] + s[16] +
                         s[15] + s[16] + s[17] + s[18] + s[19] + s[20] +
                         s[19] + s[20] + s[21] + s[22] + s[23] + s[24] +
                         s[23] + s[24] + s[25] + s[26] + s[27] + s[28] +
                         s[27] + s[28] + s[29] + s[30] + s[31] + s[0];
        }
        public static String XOR(String e, String k)
        {
            int cal;
            String result = null;
            for (int i = 0; i < 48; i++)
            {
                cal = e[i] ^ k[i];
                result += cal.ToString();
            }
            return result;
        }
        public static String Pbox(String s)
        {
            return "" + s[15] + s[6] + s[19] + s[20] + s[28] + s[11] + s[27] + s[16] +
                        s[0] + s[14] + s[22] + s[25] + s[4] + s[17] + s[30] + s[9] +
                        s[1] + s[7] + s[23] + s[13] + s[31] + s[26] + s[2] + s[8] +
                        s[18] + s[12] + s[29] + s[5] + s[21] + s[10] + s[3] + s[24];
        }
        public static String XORF(String f, String l)
        {
            int cal;
            String result = null;
            for (int i = 0; i < 32; i++)
            {
                cal = f[i] ^ l[i];
                result += cal.ToString();
            }
            return result;
        }

        #region Crypt
        public static String MaHoaDES(String p, String[] key)
        {
            String s, xor, pbox;
            String ip = HoanViKhoiTao(p);
            String[] l = new String[17];
            l[0] = ip.Substring(0, 32);
            String r = ip.Substring(32, 32);
            for (int i = 1; i <= 16; i++)
            {
                xor = XOR(Expand(r), key[i]);
                s = Sboxes.S_boxes(xor);
                pbox = Pbox(s);
                l[i] = r;
                r = XORF(pbox, l[i - 1]);
            }
            ip = r + l[16];
            ip = HoanViKetThuc(ip);
            return ip;
        }

        #endregion

        #region Decypt
        public static String GiaiMaDES(String c, String[] key)
        {
            String s, xor, pbox;
            String ip = HoanViKhoiTao(c);
            String[] r = new String[17];
            String l = ip.Substring(32, 32);
            r[16] = ip.Substring(0, 32);
            for (int i = 16; i >= 1; i--)
            {
                xor = XOR(Expand(l), key[i]);
                s = Sboxes.S_boxes(xor);
                pbox = Pbox(s);
                r[i - 1] = l;
                l = XORF(pbox, r[i]);
            }
            ip = l + r[0];
            ip = HoanViKetThuc(ip);
            return ip;
        }


        #endregion
    }
}
