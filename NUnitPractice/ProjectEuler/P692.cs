using System;

namespace ProjectEuler
{
    // https://projecteuler.net/problem=692

    public class P692
    {
        public long Answer
        { get; private set; }

        public P692(int n)
        {
            if (n > 0) {
                Answer = G(n);
            }
        }

        public P692() : this(0)
        {
        }

        public long G(int n)
        {
            long total = 0;
            int subtotal;
            for (int k=1; k<=n; k++) {
                subtotal = H(k);
                Console.WriteLine(subtotal);
                total += subtotal;
            }

            return total;
        }

        public long ComputeFLS(long cap)
        {
            long la = 0;
            long ltemp;
            long lb = 1;
            long fa = 1;
            long fb = 1;
            long ftemp;
            long sa = 0;
            long sb = 1;
            long stemp;
            while (lb < cap) {
                ltemp = la + lb + 1;
                la = lb;
                lb = ltemp;
                ftemp = fa + fb;
                fa = fb;
                fb = ftemp;
                stemp = sa + sb + ftemp;
                sa = sb;
                sb = stemp;
                Console.WriteLine($"count={lb}; fib={fb}; sum={sb}.");
            }

            if (lb==cap) {
                return sb;
            } else if ((la + 1)==cap) {
                return sa + fb;
            } else {
                throw new NotImplementedException("More work needed.");
            }

        }

        public int H(int n)
        {
            if (n < 1) {
                return 0;
            }

            int oneThirdOfN = n/3;
            for (int take=1; take<=oneThirdOfN; take++) {
                    bool giveOpponentSuccess = HaveWin(n - take, take*2);
                    if (!giveOpponentSuccess) {
                        return take;
                    }
            }

            return n;
            //throw new NotImplementedException("Implement lowest winning number determination.");
        }

        
        public bool HaveWin(int n, int max_take)
        {
            if (n<1 || max_take<1) {
                return false;
            } else if (max_take >= n) {
                return true;
            } else {
                for (int take=1; take<=max_take; take++) {
                    bool giveOpponentSuccess = HaveWin(n - take, take*2);
                    if (!giveOpponentSuccess) {
                        return true;
                    }
                }
                return false;
            }            
            //throw new NotImplementedException("Determine if win condition exists.");
        }
        
    }
}
