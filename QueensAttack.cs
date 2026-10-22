//Problem: Queen's Attack II
//Link: https://www.hackerrank.com/challenges/queens-attack-2/problem

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
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
        // Initial maximum distances to the edge of the board in all 8 directions
        int up = n - r_q;
        int down = r_q - 1;
        int right = n - c_q;
        int left = c_q - 1;
        int upRight = Math.Min(n - r_q, n - c_q);
        int upLeft = Math.Min(n - r_q, c_q - 1);
        int downRight = Math.Min(r_q - 1, n - c_q);
        int downLeft = Math.Min(r_q - 1, c_q - 1);

        // Iterate through all obstacles
        foreach (var obs in obstacles)
        {
            int r = obs[0];
            int c = obs[1];

            // Check if the obstacle is on a valid attacking path and update the minimum distance
            if (c == c_q && r > r_q) // Up
            {
                up = Math.Min(up, r - r_q - 1);
            }
            else if (c == c_q && r < r_q) // Down
            {
                down = Math.Min(down, r_q - r - 1);
            }
            else if (r == r_q && c > c_q) // Right
            {
                right = Math.Min(right, c - c_q - 1);
            }
            else if (r == r_q && c < c_q) // Left
            {
                left = Math.Min(left, c_q - c - 1);
            }
            else if (r - r_q == c - c_q && r > r_q) // Up-Right
            {
                upRight = Math.Min(upRight, r - r_q - 1);
            }
            else if (r - r_q == c_q - c && r > r_q) // Up-Left
            {
                upLeft = Math.Min(upLeft, r - r_q - 1);
            }
            else if (r_q - r == c - c_q && r < r_q) // Down-Right
            {
                downRight = Math.Min(downRight, r_q - r - 1);
            }
            else if (r_q - r == c_q - c && r < r_q) // Down-Left
            {
                downLeft = Math.Min(downLeft, r_q - r - 1);
            }
        }

        // Return the sum of valid moves in all 8 directions
        return up + down + right + left + upRight + upLeft + downRight + downLeft;
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

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
