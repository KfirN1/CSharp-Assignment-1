//Problem: Encryption
//Link: https://www.hackerrank.com/challenges/encryption/problem

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
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        // Remove spaces from the string
        s = s.Replace(" ", "");
        int n = s.Length;

        // Calculate rows and columns based on the square root of the length
        int rows = (int)Math.Floor(Math.Sqrt(n));
        int cols = (int)Math.Ceiling(Math.Sqrt(n));

        // Ensure the grid is large enough to hold all characters
        if (rows * cols < n)
        {
            rows = cols;
        }

        StringBuilder result = new StringBuilder();

        // Read characters column by column
        for (int c = 0; c < cols; c++)
        {
            for (int r = 0; r < rows; r++)
            {
                int index = r * cols + c;

                // Append the character if the calculated index is within string bounds
                if (index < n)
                {
                    result.Append(s[index]);
                }
            }
            // Add a space after each column is processed
            result.Append(" ");
        }

        return result.ToString().TrimEnd();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
