//Problem: Non-Divisible Subset
//Link: https://www.hackerrank.com/challenges/non-divisible-subset/problem

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */

    public static int nonDivisibleSubset(int k, List<int> s)
    {
        // Array to store the count of numbers for each possible remainder (from 0 to k-1)
        int[] remainders = new int[k];

        // Count the frequencies of each remainder
        foreach (int num in s)
        {
            remainders[num % k]++;
        }

        int maxSubsetSize = 0;

        // Edge case 1: remainder 0 (numbers perfectly divisible by k)
        // We can take at most one such number
        if (remainders[0] > 0)
        {
            maxSubsetSize++;
        }

        // Iterate through the first half of the remainders array
        for (int i = 1; i <= k / 2; i++)
        {
            // Edge case 2: when k is even and we are exactly at the middle (e.g., remainder 2 for k=4)
            if (i == k - i)
            {
                if (remainders[i] > 0)
                {
                    maxSubsetSize++;
                }
            }
            else
            {
                // Take the maximum count between the two conflicting remainder groups
                maxSubsetSize += Math.Max(remainders[i], remainders[k - i]);
            }
        }

        return maxSubsetSize;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Result.nonDivisibleSubset(k, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
