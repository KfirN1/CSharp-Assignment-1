//Problem: Organizing Containers of Balls
//Link: https://www.hackerrank.com/challenges/organizing-containers-of-balls/problem

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
     * Complete the 'organizingContainers' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts 2D_INTEGER_ARRAY container as parameter.
     */

    public static string organizingContainers(List<List<int>> container)
    {
        int n = container.Count;

        // Arrays to store the total capacity of each container and the total count of each ball type
        long[] containerCapacities = new long[n];
        long[] ballTypeTotals = new long[n];

        // Calculate row sums (container capacities) and column sums (ball type totals)
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                containerCapacities[i] += container[i][j];
                ballTypeTotals[j] += container[i][j];
            }
        }

        // Sort both arrays to see if they perfectly match
        Array.Sort(containerCapacities);
        Array.Sort(ballTypeTotals);

        // Compare the sorted arrays
        for (int i = 0; i < n; i++)
        {
            if (containerCapacities[i] != ballTypeTotals[i])
            {
                return "Impossible";
            }
        }

        return "Possible";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> container = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
            }

            string result = Result.organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
