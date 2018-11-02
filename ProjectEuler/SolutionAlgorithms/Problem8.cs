﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SolutionAlgorithms
{
    ////
    //The four adjacent digits in the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.

    //Find the thirteen adjacent digits in the 1000-digit number that have the greatest product.What is the value of this product?
    //Solution is O(N) and takes 0.0041796 seconds

    public class Problem8: IProblem
    {
        public void SolveProblem(bool debuggingMode, bool smallTest)
        {
            int seriestSize;
            if (smallTest)
                seriestSize = 4;
            else
                seriestSize = 13;
            char[] numbers = 
         ("73167176531330624919225119674426574742355349194934" +
          "96983520312774506326239578318016984801869478851843" +
          "85861560789112949495459501737958331952853208805511" +
          "12540698747158523863050715693290963295227443043557" +
          "66896648950445244523161731856403098711121722383113" +
          "62229893423380308135336276614282806444486645238749" +
          "30358907296290491560440772390713810515859307960866" +
          "70172427121883998797908792274921901699720888093776" +
          "65727333001053367881220235421809751254540594752243" +
          "52584907711670556013604839586446706324415722155397" +
          "53697817977846174064955149290862569321978468622482" +
          "83972241375657056057490261407972968652414535100474" +
          "82166370484403199890008895243450658541227588666881" +
          "16427171479924442928230863465674813919123162824586" +
          "17866458359124566529476545682848912883142607690042" +
          "24219022671055626321111109370544217506941658960408" +
          "07198403850962455444362981230987879927244284909188" +
          "84580156166097919133875499200524063689912560717606" +
          "05886116467109405077541002256983155200055935729725" +
          "71636269561882670428252483600823257530420752963450").ToCharArray();
            int[] intArr = new int[1000];
            for (int i = 0; i < numbers.Length; i++)
            {
                intArr[i] = Convert.ToInt32(Char.GetNumericValue(numbers[i]));
            }

            if (debuggingMode)
                DebuggingMode(intArr, seriestSize);
            else
                NonDebuggingMode(intArr, seriestSize);
        }
        private void NonDebuggingMode(int[] numbers, int seriesSize)                                                    //O(N)
        {
            BigInteger max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)                //O(N)
            {
                BigInteger tempMax = numbers[i];
                for (int k = 1; k < seriesSize; k++)                //O(1)
                {
                    if (i + k < numbers.Length)
                    {
                        tempMax *= numbers[k + i];
                        if (tempMax > max)
                            max = tempMax;
                        if (tempMax == 0)
                        {
                            i = i + k;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("The answer is: {0}", max);
        }
        private void DebuggingMode(int[] numbers, int seriesSize)
        {
            BigInteger max = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                BigInteger tempMax = numbers[i];
                for (int k = 1; k < seriesSize; k++)
                {
                    if (i + k < numbers.Length)
                    {
                        tempMax *= numbers[k + i];
                        Console.WriteLine("tempMax: {0}", tempMax);
                        if (tempMax > max)
                            max = tempMax;
                        if (tempMax == 0)
                        {
                            i = i + k;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine("The answer is: {0}", max);
        }
    }
}