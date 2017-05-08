using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Index
{
    class ExtendEuclid
    {
        public static BigInteger Euclid(BigInteger a, BigInteger b)
        {
            BigInteger A = a, B = b;
            while (B != 0)
            {
                BigInteger R = A % B;
                A = B;
                B = R;
            }
            return A;
        }
       
        //public static long ExtendedEuclid(long a, long b)
        //{
        //    long A1 = 1, A2 = 0, A3 = a;
        //    long  B1 = 0, B2 = 1, B3 = b;
        //    long Q, R1, R2, R3;
        //    while (B3 != 0 && B3 != 1)
        //    {
        //        Q = A3 / B3;
        //        R1 = A1 - Q * B1;
        //        R2 = A2 - Q * B2;
        //        R3 = A3 - Q * B3;
        //        A1 = B1; A2 = B2; A3 = B3;
        //        B1 = R1; B2 = R2; B3 = R3;
        //    }
        //    return B2;
        //}
        public static KeyValuePair<BigInteger, BigInteger> ExtendedEuclid1(BigInteger a, BigInteger b)
        {
            BigInteger A1 = 1, A2 = 0, A3 = a;
            BigInteger B1 = 0, B2 = 1, B3 = b;
            BigInteger Q, R1, R2, R3;
            while (B3 != 0 && B3 != 1)
            {
                Q = A3 / B3;
                R1 = A1 - Q * B1;
                R2 = A2 - Q * B2;
                R3 = A3 - Q * B3;
                A1 = B1; A2 = B2; A3 = B3;
                B1 = R1; B2 = R2; B3 = R3;
            }
            var KeyValuePair = new KeyValuePair<BigInteger, BigInteger>(B3, B2);
            return KeyValuePair;
        }

    }
}

