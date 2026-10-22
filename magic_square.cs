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
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */

    public static int formingMagicSquare(List<List<int>> s)
    {
        // The 8 valid 3x3 magic squares
        int[][,] magicSquares = new int[][,]
        {
            new int[,] {{8, 1, 6}, {3, 5, 7}, {4, 9, 2}},
            new int[,] {{6, 1, 8}, {7, 5, 3}, {2, 9, 4}},
            new int[,] {{4, 9, 2}, {3, 5, 7}, {8, 1, 6}},
            new int[,] {{2, 9, 4}, {7, 5, 3}, {6, 1, 8}},
            new int[,] {{8, 3, 4}, {1, 5, 9}, {6, 7, 2}},
            new int[,] {{4, 3, 8}, {9, 5, 1}, {2, 7, 6}},
            new int[,] {{6, 7, 2}, {1, 5, 9}, {8, 3, 4}},
            new int[,] {{2, 7, 6}, {9, 5, 1}, {4, 3, 8}}
        };

        int minCost = int.MaxValue;

        // Iterate through each of the 8 possible magic squares
        for (int k = 0; k < 8; k++)
        {
            int currentCost = 0;

            // Iterate through the cells of the 3x3 matrix
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Calculate the absolute difference between the input and the current magic square
                    currentCost += Math.Abs(s[i][j] - magicSquares[k][i, j]);
                }
            }

            // Update the minimum cost if a lower cost is found
            if (currentCost < minCost)
            {
                minCost = currentCost;
            }
        }

        return minCost;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Result.formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
