using System;
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
        private static bool IsMatch(string s1, string s2, string s3, int pos1, int pos2, int pos3)
        {
            if (pos3 == s3.Length) return true;

            if (pos1 < s1.Length && s1[pos1] == s3[pos3] && IsMatch(s1, s2, s3, pos1 + 1, pos2, pos3 + 1))
            {
                return true;
            }
            else if(pos2 < s2.Length && s2[pos2] == s3[pos3] && IsMatch(s1, s2, s3, pos1, pos2 + 1, pos3 + 1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void Main(string[] args)
        {
            const string A = "aabbcc";
            const string B = "ddeeff";
            //const string AB = "ddaabbeecffc";
            //const string AB = "aabbccddeeff";
            const string AB = "addabbecceff";

            bool isMatch = false;
            if (A.Length + B.Length == AB.Length)
            {
                isMatch = IsMatch(A, B, AB, 0, 0, 0);
            }

            Console.WriteLine("String A: \t" + A);
            Console.WriteLine("String B: \t" + B);
            Console.WriteLine("String AB: \t" + AB);
            Console.WriteLine(isMatch ? "Is Match!" : "Is NOT Match!");
        }
    }
}
