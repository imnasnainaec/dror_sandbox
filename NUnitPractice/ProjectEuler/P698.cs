using System;
//using System.Collections.Generic;
//using ProjectEuler.Tools;

namespace ProjectEuler
{
    //https://projecteuler.net/problem=698
    public class P698
    {
        public P698()
        {  }

        public long F(long n)
        {
            throw new NotImplementedException($"Find the {n}-th 123 number.");
        }

        /* //Oops, Convert.ToString requires a power-of-two base.
        public string ternaryString(long n)
        {
            return Convert.ToString(n, 3);
        }

        public string ternary123String(long n)
        {
            string numString = ternaryString(n-1);
            numString = numString.Replace('2', '3');
            numString = numString.Replace('1', '2');
            numString = numString.Replace('0', '1');
            return numString;
        }
        */
    }

}