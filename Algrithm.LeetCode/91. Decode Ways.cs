using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
    A message containing letters from A-Z is being encoded to numbers using the following mapping:

    'A' -> 1    'B' -> 2    ...    'Z' -> 26
    Given an encoded message containing digits, determine the total number of ways to decode it.
    For example,
    Given encoded message "12", it could be decoded as "AB" (1 2) or "L" (12).
    The number of ways decoding "12" is 2.
    */
    class DecodeWays
    {
        private static int Calc(string code)
        {
            if (code == null || code.Length == 0) return 0;
            if (code.Length == 1) return 1;

            int[] ways = new int[code.Length + 1];
            ways[0] = 1; // 注意，ways[0]应当初始化为1，而不是0，即空字符串认为是1种有效的情况，这纯粹为了数学计算，虽然实际上空字符串应该代表无效的code
            ways[1] = 1;
            for(int i = 2; i < ways.Length; i++)
            {
                int codePos = i - 1;
                // 如果为当前为0
                if (code[codePos] == '0')
                {
                    ways[i] = ways[i - 2];
                }
                // 如果前1位数字为0
                else if (code[codePos - 1] == '0')
                {
                    ways[i] = ways[i - 1];
                }
                // 如果2位数超出最大的Z字母的数值26
                else if ((code[codePos - 1] - '0') * 10 + (code[codePos] - '0') > 26)
                {
                    ways[i] = ways[i - 1];
                }
                else
                {
                    ways[i] = ways[i - 1] + ways[i - 2];
                }
            }

            return ways.Last();
        }

        static void Main(string[] args)
        {
            const string CODE1 = "12";
            const string CODE2 = "12213";
            const string CODE3 = "14545";
            const string CODE4 = "20101020";
            const string CODE5 = "227";
            const string CODE6 = "226";
            Console.WriteLine(string.Format("Ways of '{0}' is: {1}", CODE1, Calc(CODE1)));
            Console.WriteLine(string.Format("Ways of '{0}' is: {1}", CODE2, Calc(CODE2)));
            Console.WriteLine(string.Format("Ways of '{0}' is: {1}", CODE3, Calc(CODE3)));
            Console.WriteLine(string.Format("Ways of '{0}' is: {1}", CODE4, Calc(CODE4)));
            Console.WriteLine(string.Format("Ways of '{0}' is: {1}", CODE5, Calc(CODE5)));
            Console.WriteLine(string.Format("Ways of '{0}' is: {1}", CODE6, Calc(CODE6)));
        }

    }
}
