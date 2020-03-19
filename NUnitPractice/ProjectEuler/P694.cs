using System;
using System.Collections.Generic;
using ProjectEuler.Tools;

namespace ProjectEuler
{
    //https://projecteuler.net/problem=694
    public class P694
    {
        public P694()
        {
        }

        public bool cubeFull(long n)
        {
            if (n<1) {
                return false;
            } else if (n==1) {
                return true;
            }

            List<long> pF = PrimeTools.PrimeFactorization(n);
            int i = 0;
            int j;
            //Console.WriteLine($"Counting duplicates, {n} has {pF.Count} prime factors.");
            while (i < pF.Count) {
                j = i + 1;
                while (j < pF.Count && pF[i]==pF[j]) {
                    j++;
                }
                
                if (j - i < 3) {
                    return false;
                } else if (j == pF.Count) {
                    return true;
                } else {
                    i = j;
                }
            }

            throw new NotImplementedException($"Determine whether {n} is cube-full.");
        }

        public long s(long n)
        {
            if (n<1) {
                return 0;
            } else if (n==1) {
                return 1;
            }

            List<int> pPowers = PrimeTools.PrimeFactorizationPowers(n);
            long count = 1;
            foreach (int power in pPowers) {
                if (power >= 3) {
                    count *= (power - 1);
                }
            }

            return count;

            //throw new NotImplementedException($"Count cube-full divisors of {n}.");
        }

        public long S(long n)
        {
            long total = 0;
            for (long i=1; i<=n; i++) {
                total += s(i);
            }

            return total;
            //throw new NotImplementedException($"Sum s(i) for i from 1 to {n}.");
        }
    }
}