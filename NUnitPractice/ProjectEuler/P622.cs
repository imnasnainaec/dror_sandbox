using System;

namespace ProjectEuler
{
    // https://projecteuler.net/problem=692

    public class P622
    {
        public long Answer
        { get; private set; }

        public P622(int n)
        {
            
        }

        public P622() : this(0) {}

        public int s(long n)
        {
            int shuffles = 0;
            long locationOf1 = 1;
            do {
                locationOf1 *= 2;
                locationOf1 %= (n-1);
                shuffles++;
            } while (locationOf1 > 1);
            return shuffles;
        }

        public long checkAndSumAllDivisors(int[] primeFactors, int[] powers, int target, long divisor=1, long subtotal=0)
        {
            int primeCount = primeFactors.Length;
            if (primeCount>0) {
                long active = subtotal;
                int pF = primeFactors[0];
                int pow = powers[0];
                int[] extraPrimeFactors = new int[primeCount - 1];
                Array.Copy(primeFactors, 1, extraPrimeFactors, 0, primeCount - 1);
                int[] extraPowers = new int[primeCount - 1];
                Array.Copy(powers, 1, extraPowers, 0, primeCount - 1);
                long growingDivisor = divisor;
                for (int i=0; i<=pow; i++) {
                    active += checkAndSumAllDivisors(extraPrimeFactors, extraPowers, target, growingDivisor);
                    growingDivisor *= pF;
                }
                return active;
            } else {
                long deckSize = divisor + 1;
                int shufflesNeeded = s(deckSize);
                //Console.WriteLine($"s(deckSize)=s({deckSize})={shufflesNeeded}; target={target}");
                if (shufflesNeeded==target) {
                    return deckSize;
                } else {
                    return 0;
                }
            }
        }
    }
}
