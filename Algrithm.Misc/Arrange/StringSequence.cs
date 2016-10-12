using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.Arrange
{
    /*
     * 类似于排列组合，选择了一个字符之后，剩下的位置就不能再选择该字符；
     * 下一个位置可以从剩余的候选字符中挑选任何一个字符。
     * 
     * 递归：
     * 每次为当前位置，从候选字符中选择一个字符填充，
     * 然后把该字符从候选字符中移除，
     * 接着把剩下字符交给剩下的位置，让他们自己填充
     */
    class StringSequence
    {
        public static readonly string Input = "abcdef";
        private static readonly List<string> AllSequences = new List<string>();

        public static List<string> Execute()
        {
            Recursive(new StringBuilder(), Input);
            return AllSequences;
        }

        private static void Recursive(StringBuilder sb, string restUnselected)
        {
            //Console.WriteLine("Rest: " + restUnselected);

            if (restUnselected.Length == 1)
            {
                sb.Append(restUnselected);
                AllSequences.Add(sb.ToString());
                // Console.WriteLine("Get a new sequence ======>    " + sb.ToString() + Environment.NewLine);
                return;
            }

            for (int i = 0; i < restUnselected.Length; i++)
            {
                int previousLength = sb.Length;
                sb.Append(restUnselected[i]);

                //Console.WriteLine("Added: " + restUnselected[i]);

                Recursive(sb, restUnselected.Remove(i, 1));              
                sb.Remove(previousLength, sb.Length - previousLength);
            }

        }
    }
}
