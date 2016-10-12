using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.Arrange
{
    /*
     * 类似于排列组合，选择了一个数字之后，剩下的位置就不能再选择该数字；
     * 下一个位置可以从剩余的候选数字中挑选任何一个数字。
     * 
     * 递归：
     * 每次为当前位置，从候选数字中选择一个数字填充，
     * 然后把该数字从候选数字中移除，
     * 接着把剩下数字交给剩下的位置，让他们自己填充
     */
    class NumberSequence
    {
        public const int NumberCount = 3;
        public static readonly List<int> Candidates = new List<int> { 1, 2, 3, 4, 5, 6 };

        private static readonly List<string> AllSequences = new List<string>();

        public static List<string> Execute()
        {
            Recursive(string.Empty, NumberCount, Candidates);
            return AllSequences;
        }

        private static void Recursive(string sequence, int count, List<int> candidates)
        {
            if (count == 0)
            {
                AllSequences.Add(sequence);
                return;
            }
            
            for (int i = 0; i < candidates.Count; i++)
            {
                string newSequence = sequence + candidates[i];
                List<int> remainedCandidates = new List<int>(candidates);
                remainedCandidates.RemoveAt(i);
                Recursive(newSequence, count - 1, remainedCandidates);
            }
        }
    }
}
