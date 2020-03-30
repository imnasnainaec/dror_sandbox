using System;
using System.Collections.Generic;
using ProjectEuler.Tools;

namespace ProjectEuler
{
    //https://projecteuler.net/problem=650
    public class P650
    {
        public P650()
        {  }

        public long B(int n)
        {
            long product = 1;
            for (int i=n; i>=2; i--) {
                int power = 2*i - n - 1;
                if (power > 0) {
                    product *= (long)Math.Pow(i, power);
                } else if (power < 0) {
                    product /= (long)Math.Pow(i, -power);
                }
            }
            return product;
            //throw new NotImplementedException($"Compute product of binomial numbers {n}-choose-k.");
        }

        public int[] BPrimeFactorization(int n)
        {
            int[] powers = new int[n+1];
            List<long> pieceFactorization;
            for (int i=n; i>=2; i--) {
                int power = 2*i - n - 1;
                pieceFactorization = PrimeTools.PrimeFactorization(i);
                foreach (long factor in pieceFactorization) {
                    powers[factor] += power;
                }
            }
            return powers;
        }
        
        public long D(int n)
        {
            int[] b = BPrimeFactorization(n);
            long d = 1;
            for (int factor=2; factor<b.Length; factor++) {
                if (b[factor] > 0) {
                    d *= ((long)Math.Pow(factor, b[factor] + 1) - 1)/(factor - 1);
                }
            }
            return d;
        }
        /*
            long b = B(n);
            //Console.WriteLine($"B({n}) = {b}.");
            List<long> primeFactorization = PrimeTools.PrimeFactorization(b);
            List<long> factors = PrimeTools.PrimeFactorizationFactors(primeFactorization);
            List<int> powers = PrimeTools.PrimeFactorizationPowers(primeFactorization);
            long d = 1;
            long fac;
            int pow;
            for (int i=0; i<factors.Count; i++) {
                fac = factors[i];
                pow = powers[i];
                Console.WriteLine($"{fac}^{pow}.");
                d *= ((long)Math.Pow(fac, pow + 1) - 1)/(fac - 1);
            }
            return d;
            //throw new NotImplementedException($"Compute sum of divisors of B({n}).");
        }
        */
        
        public long S(int n)
        {
            long s = 0;
            long d;
            for (int i=1; i<=n; i++) {
                d = D(i);
                //Console.WriteLine(d);
                s += d;
            }
            return s;
            //throw new NotImplementedException($"Compute sum of D(k) for k=1..{n}.");
        }

        public long DmodM(int n, long m)
        { 
            int[] b = BPrimeFactorization(n);
            long d = 1;
            for (int factor=2; factor<b.Length; factor++) {
                if (b[factor] > 0) {
                    //d *= (PrimeTools.PowModP(factor, b[factor] + 1, m*(factor - 1)) - 1)/(factor - 1);
                    d *= ((long)System.Numerics.BigInteger.ModPow(factor, b[factor] + 1, m*(factor - 1)) - 1)/(factor - 1);
                    d %= m;
                }
            }
            return d;
        }
        
        public long SmodM(int n, long m, int checkpoint = 1000)
        {
            long s = 0;
            long d;
            for (int i=1; i<=n; i++) {
                d = DmodM(i, m);
                //Console.WriteLine(d);
                s += d;
                //s %= m;
                if (i % checkpoint == 0) {
                    Console.WriteLine($"D({i}) mod {m} = {d}.");
                    s %= m;
                }
            }
            return s;
            //throw new NotImplementedException($"Compute S({n}) modulo {m}.");
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