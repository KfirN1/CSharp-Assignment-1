//Problem: The Grid Search
//Link: https://www.hackerrank.com/challenges/the-grid-search/problem

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
     * Complete the 'gridSearch' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING_ARRAY G
     *  2. STRING_ARRAY P
     */

    public static string gridSearch(List<string> G, List<string> P)
    {
        int R = G.Count;
        int C = G[0].Length;
        int r = P.Count;
        int c = P[0].Length;

        // Iterate through every possible top-left starting position in G
        for (int i = 0; i <= R - r; i++)
        {
            for (int j = 0; j <= C - c; j++)
            {
                bool found = true;

                // Check if the pattern P matches the subgrid in G
                for (int x = 0; x < r; x++)
                {
                    // Extract the substring of length 'c' starting at column 'j'
                    if (G[i + x].Substring(j, c) != P[x])
                    {
                        found = false;
                        break; // Stop checking this position immediately if there's a mismatch
                    }
                }

                if (found)
                {
                    return "YES";
                }
            }
        }

        return "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int R = Convert.ToInt32(firstMultipleInput[0]);

            int C = Convert.ToInt32(firstMultipleInput[1]);

            List<string> G = new List<string>();

            for (int i = 0; i < R; i++)
            {
                string GItem = Console.ReadLine();
                G.Add(GItem);
            }

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int r = Convert.ToInt32(secondMultipleInput[0]);

            int c = Convert.ToInt32(secondMultipleInput[1]);

            List<string> P = new List<string>();

            for (int i = 0; i < r; i++)
            {
                string PItem = Console.ReadLine();
                P.Add(PItem);
            }

            string result = Result.gridSearch(G, P);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
