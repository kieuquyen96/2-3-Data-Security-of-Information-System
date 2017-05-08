using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Index
{
    class RSA
    {
        public static BigInteger pRSA = 0, qRSA = 0;
        public static BigInteger e;
        BigInteger E = 17;
        public static BigInteger random(BigInteger x)
        {
            byte[] bytes = x.ToByteArray();
            BigInteger R;
            Random r = new Random();
            do
            {
                r.NextBytes(bytes);
                bytes[bytes.Length - 1] &= (byte)0x7F;
                R = new BigInteger(bytes);
            } while (R >= x && R < 1);

            return R;
        }
        public static bool IsSNT(BigInteger x)
        {
            BigInteger y = x - 1;
            BigInteger q = y / 2;
            BigInteger k = 1;
            while ((q & 1) == 0)
            {
                q /= 2;
                k++;
            }
            BigInteger a = random(x - 1);
            BigInteger b = BinhPhuong.Power(a, q, x);
            if (b == 1)
            {
                return true;
            }
            else
            {
                for (BigInteger i = 0; i < k; i++)
                {
                    if (b == (x - 1))
                        return true;
                    else
                        b = BinhPhuong.Power(b, 2, x);
                }
            }
            return false;
        }
        public static void timSNT()
        {
            int flag = 0;
            pRSA = 0; qRSA = 0;
            while (flag != 2)
            {
                var rng = new RNGCryptoServiceProvider();
                byte[] bytes = new byte[8];
                rng.GetBytes(bytes);

                BigInteger p = new BigInteger(bytes);
                if (IsSNT(p))
                {
                    if (pRSA == 0)
                    {
                        pRSA = p;
                        flag++;
                    }
                    else if (qRSA == 0)
                    {
                        qRSA = p;
                        flag++;
                    }
                }
            }
        }
        public static KeyValuePair<BigInteger, BigInteger> Timp_q( )
        {
            timSNT();
            while (ExtendEuclid.Euclid(pRSA, qRSA) != 1)
            {
                pRSA = 0;
                qRSA = 0;
                timSNT();
            }
            var KeyValuePair = new KeyValuePair<BigInteger, BigInteger>(pRSA, qRSA);
            return KeyValuePair;
        }
        public static BigInteger Tim_e(BigInteger p, BigInteger q) {
            BigInteger n = (p - 1)*(q - 1);
            var rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[2];
            rng.GetBytes(bytes);

            BigInteger x = new BigInteger(bytes);
            e = random(x);
            while (ExtendEuclid.Euclid(e, n) != 1) {
                e = random(x);
            }
            return e;
        
        }
        
        
    }
}
