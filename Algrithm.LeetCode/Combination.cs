using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTest
{
    class Combination
    {
        private static void Combine(List<string> combinations, int[] candidates, string current, int start, int targetLength)
        {
            if (current.Length == targetLength)
            {
                combinations.Add(current);
                return;
            }

            for (int i = start; i < candidates.Length; i++)
            {
                Combine(combinations, candidates, current + candidates[i], i + 1, targetLength);
            }
        }

        //static void Main(string[] args)
        //{
        //    int[] candidates = { 1, 2, 3, 4, 5 };
        //    const int TARGET_LENGTH = 3;

        //    List<string> combinations = new List<string>();
        //    Combine(combinations, candidates, "", 0, TARGET_LENGTH);
        //    foreach(var combination in combinations)
        //    {
        //        Console.WriteLine(combination);
        //    }
        //}
    }
}
