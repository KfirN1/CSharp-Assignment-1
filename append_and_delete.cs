//Problem: Append and Delete
//Link: https://www.hackerrank.com/challenges/append-and-delete/problem

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
     * Complete the 'appendAndDelete' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. STRING t
     *  3. INTEGER k
     */

    public static string appendAndDelete(string s, string t, int k)
    {
        int commonLength = 0;
        int minLength = Math.Min(s.Length, t.Length);

        //finding the length of the common prefix
        while (commonLength < minLength && s[commonLength] == t[commonLength])
        {
            commonLength++;
        }

        int minOps = (s.Length - commonLength) + (t.Length - commonLength);

        if (k >= s.Length + t.Length || (k >= minOps && (k - minOps) % 2 == 0))
        {
            return "Yes";
        }

        return "No";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string t = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.appendAndDelete(s, t, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
