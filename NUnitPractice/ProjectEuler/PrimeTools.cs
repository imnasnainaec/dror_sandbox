using System;
using System.Collections.Generic;

namespace ProjectEuler.Tools 
{
    static class PrimeTools
    {
        //https://stackoverflow.com/questions/1042902/most-elegant-way-to-generate-prime-numbers/1043002#1043002
        public static List<long> GeneratePrimesUpTo(this long n)
        {
            List<long> primes = new List<long>();
            if (n>=2) {
                primes.Add(2);
            }
            long nextPrime = 3;
            while (nextPrime <= n) {
                long sqrt = (long)Math.Sqrt(nextPrime);
                bool isPrime = true;
                for (int i = 0; (long)primes[i] <= sqrt; i++)
                {
                    if (nextPrime % primes[i] == 0) {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime) {
                    primes.Add(nextPrime);
                }
                nextPrime += 2;
            }
            return primes;
        }

        public static List<long> PrimeFactorization(this long n)
        {
            List<long> primes = GeneratePrimesUpTo((long)Math.Sqrt(n));
            List<long> factors = new List<long>();
            long quotient = n;
            int i = 0;
            while (i < primes.Count && quotient > 1) {
                while (quotient % primes[i] == 0) {
                    factors.Add(primes[i]);
                    quotient /= primes[i];
                }
                i++;
            }
            if (quotient > 1) {
                factors.Add(quotient);
            }
            return factors;
        }

        public static List<int> PrimeFactorizationPowers(this long n)
        {
            List<int> powers = new List<int>();
            List<long> factors = PrimeFactorization(n);
            int i = 0;
            int j;
            while (i < factors.Count) {
                j = i + 1;
                while (j < factors.Count && factors[i]==factors[j]) {
                    j++;
                }
                powers.Add(j - i);
                i = j;
            }
            return powers;
        }
    }
}