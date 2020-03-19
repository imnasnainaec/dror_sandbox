using System;
//using System.Collections.Generic;

namespace ProjectEuler
{
    public class P323
    {
        public int NumBits
        { get; private set; }
        
        public P323(int numBits = 32)
        {
            this.NumBits = numBits;
        }

        public double probabilityOfAtMostN(int N)
        {
            double denominator = Math.Pow(2, N);
            double numerator = denominator - 1;
            double frac = numerator/denominator;
            frac = Math.Pow(frac, this.NumBits);
            return frac;
        }

        public double expectedValueOfN()
        {
            double total = 0;
            double probA = 0;
            double probB = 0;
            double subtotal = 0;
            int i = 1;
            do {
                probA = probB;
                probB = probabilityOfAtMostN(i);
                subtotal = i*(probB - probA);
                Console.WriteLine($"i={i}; i*p={subtotal}");
                total += subtotal;
                i++;
            } while ( subtotal > 0.00000000000001);
            return total;
        }


    }
}