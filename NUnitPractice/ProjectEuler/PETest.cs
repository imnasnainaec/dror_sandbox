using System;
using System.Collections.Generic;
using ProjectEuler.Tools;

namespace ProjectEuler
{
    // https://projecteuler.net
    
    class PETest
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            /*
            P692 test = new P692(13);
            //Console.WriteLine(test.Answer);
            //P692 test2 = new P692(100);
            long answer = test.ComputeFLS(23416728348467685);
            Console.WriteLine($"Answer: {answer}");
            */

            /*
            P622 test = new P622();
            Console.WriteLine(test.s(52));
            int[] primeList = new int[] {3, 5, 17};
            int[] powerList = new int[] {1, 1, 1};
            int target = 8;
            //Factor 2^60 - 1:
            primeList = new int[] {3, 5, 7, 11, 13, 31, 41, 61, 151, 331, 1321};
            powerList = new int[] {2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1};
            target = 60;
            Console.WriteLine(test.checkAndSumAllDivisors(primeList, powerList, target));
            */

            /*
            List<long> pF = PrimeTools.PrimeFactorization(8);
            foreach (long factor in pF) {
                Console.WriteLine(factor);
            }
            */
            /*
            List<long> pF = PrimeTools.GeneratePrimesUpTo(10000000); //And we need 8 more 0s...
            Console.WriteLine(pF.Count);
            */

            /*
            P694 test = new P694();
            Console.WriteLine(test.cubeFull(8));
            Console.WriteLine(test.S(100));
            */

            /*
            P323 test = new P323(4);
            Console.WriteLine(test.probabilityOfAtMostN(2));
            Console.WriteLine(Math.Pow(.75, 4));
            test = new P323();
            Console.WriteLine(test.expectedValueOfN());
            */

            /*
            P577 test = new P577();
            Console.WriteLine(test.H(6));
            Console.WriteLine(test.H(20));
            Console.WriteLine(test.SumOfHs(12345));
            */

            /*
            P650 test = new P650();
            //test.S(10);
            long modulo = 1000000007;
            //test.SmodM(100, modulo);
            //Console.WriteLine(test.SmodM(2000, modulo));
            //Console.WriteLine(test.DmodM(20000, modulo));
            Console.WriteLine(test.SmodM(20000, modulo));
            */
            
            /*
            string[] keywords = {"FREE", "FARE", "AREA", "REEF"};
            P679 test = new P679(keywords);
            test.InitiateWordSequences();
            int goal = 30;
            for (int i=0; i<=goal; i++)
                Console.WriteLine($"f({i}) = {test.f(i)}");
            */

            
        }
    }
}