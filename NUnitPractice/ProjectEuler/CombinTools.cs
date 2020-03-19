using System;
//using System.Collections.Generic;

namespace ProjectEuler.Tools 
{
    static class CombinTools
    {
        public static long TriangleNumber(this long n)
        {
            if (n<=0) {
                return 0;
            } else {
                return (n*(n+1))/2;
            }
        }
    }
}