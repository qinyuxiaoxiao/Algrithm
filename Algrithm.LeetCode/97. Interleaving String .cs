using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
    Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.

    For example,
    
    Given:
    s1 = "aabcc",
    s2 = "dbbca",

    When s3 = "aadbbcbcac", return true.
    When s3 = "aadbbbaccc", return false.

    */
    class InterleavingString
    {
        private static bool IsMatch_Backtracking(string s1, string s2, string s3, int pos1, int pos2, int pos3)
        {
            if (pos3 == s3.Length) return true;

            if (pos1 < s1.Length && s1[pos1] == s3[pos3] && IsMatch_Backtracking(s1, s2, s3, pos1 + 1, pos2, pos3 + 1))
            {
                return true;
            }
            else if(pos2 < s2.Length && s2[pos2] == s3[pos3] && IsMatch_Backtracking(s1, s2, s3, pos1, pos2 + 1, pos3 + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool IsMatch_DynamicProgramming(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;

            bool[,] matches = new bool[s1.Length + 1, s2.Length + 1];
            matches[0, 0] = true;

            for (int i = 1; i <= s1.Length; i++)
            {
                matches[i, 0] = s3[i - 1] == s1[i - 1] && matches[i - 1, 0];
            }

            for(int j = 1; j <= s2.Length; j ++)
            {
                matches[0, j] = s3[j - 1] == s2[j - 1] && matches[0, j - 1];
            }

            for(int i = 1; i <= s1.Length; i++)
            {
                for(int j = 1; j <= s2.Length; j++)
                {
                    matches[i, j] =
                        (s3[i + j - 1] == s1[i - 1] && matches[i - 1, j])
                        ||
                        (s3[i + j - 1] == s2[j - 1] && matches[i, j - 1]);
                }
            }

            return matches[s1.Length, s2.Length];
        }

        //static void Main(string[] args)
        //{
        //    const string A = "aabbcc";
        //    const string B = "ddeeff";
        //    //const string AB = "ddaabbeecffc";
        //    const string AB = "aabbccddeeff";
        //    //const string AB = "addabbecceff";

        //    bool isMatch = false;
        //    if (A.Length + B.Length == AB.Length)
        //    {
        //        //isMatch = IsMatch_Backtracking(A, B, AB, 0, 0, 0);
        //        isMatch = IsMatch_DynamicProgramming(A, B, AB);
        //    }

        //    Console.WriteLine("String A: \t" + A);
        //    Console.WriteLine("String B: \t" + B);
        //    Console.WriteLine("String AB: \t" + AB);
        //    Console.WriteLine(isMatch ? "Is Match!" : "Is NOT Match!");


        //    Console.WriteLine();
        //    Console.WriteLine("<Performance Competition>");
        //    Console.WriteLine();
        //    TestPerf_DynamicProgramming(A, B, AB);
        //    Console.WriteLine();
        //    TestPerf_Backtracking(A, B, AB);
        //    Console.WriteLine();
        //}

        private static void TestPerf_Backtracking(string s1, string s2, string s3)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for(int i = 0; i < 100000; i ++)
            {
                IsMatch_Backtracking(s1, s2, s3, 0, 0, 0);
            }
            sw.Stop();

            Console.WriteLine("\tBacktracking Paradigm: \t\t\t" + sw.ElapsedMilliseconds + " ms");
        }

        private static void TestPerf_DynamicProgramming(string s1, string s2, string s3)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000; i++)
            {
                IsMatch_DynamicProgramming(s1, s2, s3);
            }
            sw.Stop();

            Console.WriteLine("\tDynamic Programming Paradigm: \t\t" + sw.ElapsedMilliseconds + " ms");
        }
    }
}
