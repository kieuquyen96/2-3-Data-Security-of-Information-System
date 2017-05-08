using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Index
{
    class A51
    {
        public static bool[] X;
        public static bool[] Y;
        public static bool[] Z;
        public static BitArray banro;

        //Hàm major lấy bit chiếm đa số
        public static bool maj(bool x8, bool y10, bool z10)
        {
            int dem = 0;
            if (x8 == true) dem++;
            if (y10 == true) dem++;
            if (z10 == true) dem++;
            if (dem >= 2) 
                return true;
            return false;
        }

        //Hàm quay X
        public static bool[] QuayX(bool[] x)
        {
            bool t = x[13] ^ x[16] ^ x[17] ^ x[18];
            for (int i = 18; i > 0; i--)
                x[i] = x[i - 1];
            x[0] = t;
            return x;
        }

        //Hàm quay Y
        public static bool[] QuayY(bool[] y)
        {
            bool t = y[20] ^ y[21];
            for (int i = 21; i > 0; i--)
                y[i] = y[i - 1];
            y[0] = t;
            return y;
        }

        //Hàm quay Z
        public static bool[] QuayZ(bool[] z)
        {
            bool t = z[7] ^ z[20] ^ z[21] ^ z[22];
            for (int i = 22; i > 0; i--)
                z[i] = z[i - 1];
            z[0] = t;
            return z;
        }

        //Hàm sinh số ngẫu nhiên
        public static bool[] SinhSoNgauNhien()
        {
            bool m = true;
            bool[] bit = new bool[banro.Length];
            for (int i = 0; i < banro.Length; i++)
            {
                m = maj(X[8], Y[10], Z[10]);
                if (X[8] == m) X = QuayX(X);
                if (Y[10] == m) Y = QuayY(Y);
                if (Z[10] == m) Z = QuayZ(Z);
                bit[i] = X[18] ^ Y[21] ^ Z[22];
            }
            return bit;
        }
        public static string SinhKhoa(int lenght)
        {
            string S = "";
            Random ran = new Random();
            for (int i = 0; i < lenght; i++)
                S += (ran.Next(2));
            return S;
        }
        public static bool[] string2bool(string S)
        {
            bool[] bit = new bool[S.Length];
            for (int i = 0; i < S.Length; i++)
            {
                if (S[i] == '0') bit[i] = false;
                else bit[i] = true;
            }
            return bit;
        }
        //Chuuyển một mảng bit sang mảng byte
        public static byte[] BitArr2ByteArr(BitArray bits)
        {
            byte[] ret = new byte[bits.Length / 8];
            bits.CopyTo(ret, 0);
            return ret;
        }
        // Hàm mã hóa
        public static BitArray MaHoa()
        {
            BitArray khoa = new BitArray(SinhSoNgauNhien());
            for (int i = 0; i < banro.Length; i++)
            {
                banro[i] ^= khoa[i];
            }
            return banro;
        }
        
    }
}
