using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Index
{
    class BinhPhuong
    {
        public static BigInteger Power(BigInteger x, BigInteger b, BigInteger n) {
            BigInteger y = 1, a =  x;
            do
            {
                if (b % 2 != 0)
                    y = (y * a) % n;
                b = b >> 1;
                a = (a * a) % n;
            }
            while (b > 0);
            return y;
        }

    }
}
