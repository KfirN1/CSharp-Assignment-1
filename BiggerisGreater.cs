//Problem: Bigger is Greater
//Link: https://www.hackerrank.com/challenges/bigger-is-greater/problem

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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string w)
    {
        char[] chars = w.ToCharArray();
        int n = chars.Length;
        int i = n - 2;

        // 1. Find the rightmost character that is smaller than its next character
        while (i >= 0 && chars[i] >= chars[i + 1])
        {
            i--;
        }

        // If no such character is found, this is the last permutation
        if (i < 0)
        {
            return "no answer";
        }

        // 2. Find the rightmost character that is greater than chars[i]
        int j = n - 1;
        while (chars[j] <= chars[i])
        {
            j--;
        }

        // 3. Swap them
        char temp = chars[i];
        chars[i] = chars[j];
        chars[j] = temp;

        // 4. Reverse the suffix to get the smallest lexicographical order
        Array.Reverse(chars, i + 1, n - i - 1);

        return new string(chars);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
