using System;
using ProjectEuler.Tools;

namespace ProjectEuler
{
    //https://projecteuler.net/problem=577
    public class P577
    {
        public P577()
        {
        }

        public long H(int n) {
            long total = 0;
            for (int i=1; i<=n/3; i++) {
                total += i*CombinTools.TriangleNumber(n + 1 - 3*i);
            }
            return total;
            //throw new NotImplementedException($"Count reguar hexagons in triangle lattice with side length {n}.");
        }

        public long SumOfHs(int N) {
            long total = 0;
            for (int i=3; i<=N; i++) {
                total += H(i);
            }
            return total;
        }

    }
}