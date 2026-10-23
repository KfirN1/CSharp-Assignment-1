//Problem: The Time in Words
//Link: https://www.hackerrank.com/challenges/the-time-in-words/problem

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
     * Complete the 'timeInWords' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. INTEGER h
     *  2. INTEGER m
     */

    public static string timeInWords(int h, int m)
    {
        string[] nums = {
        "zero", "one", "two", "three", "four", "five", "six", "seven",
        "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen",
        "fifteen", "sixteen", "seventeen", "eighteen", "nineteen", "twenty",
        "twenty one", "twenty two", "twenty three", "twenty four",
        "twenty five", "twenty six", "twenty seven", "twenty eight",
        "twenty nine"
    };

        if (m == 0)
            return $"{nums[h]} o' clock";

        string hour;
        string direction;
        int mins;

        if (m <= 30)
        {
            hour = nums[h];
            mins = m;
            direction = "past";
        }
        else
        {
            hour = nums[h % 12 + 1];
            mins = 60 - m;
            direction = "to";
        }

        if (mins == 15)
            return $"quarter {direction} {hour}";
        if (mins == 30)
            return $"half past {hour}";

        string unit = mins == 1 ? "minute" : "minutes";
        return $"{nums[mins]} {unit} {direction} {hour}";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int h = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.timeInWords(h, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
