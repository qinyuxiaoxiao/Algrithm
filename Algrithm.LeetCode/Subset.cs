using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CodeTest
{
    class Subset
    {
        private static void GenerateSubsets(List<string> subsets, int[] candidates, string current, int position)
        {
            // postition代表从candidates中选取/不选取元素的位置，范围从0 到 candidate.Length - 1
            // 只有从头到尾当所有的元素都判断过选取/不选取后，就可以把最终的结果保存起来
            if (position == candidates.Length)
            {
                subsets.Add("[" + current + "]");
                return;
            }

            // 不选取当前position位置代表的数字
            GenerateSubsets(subsets, candidates, current, position + 1);

            // 选取当前postition位置代表的数字, 因为字符串的恒定性带来了遍历，所以不需要参考答案中的pop_back()回溯操作
            GenerateSubsets(subsets, candidates, current + candidates[position], position + 1);
        }

        //static void Main(string[] args)
        //{
        //    int[] candidates = { 1, 2, 3, 4, 5 };

        //    List<string> subsets = new List<string>();
        //    GenerateSubsets(subsets, candidates, "", 0);
        //    foreach (var subset in subsets)
        //    {
        //        Console.WriteLine(subset);
        //    }
        //}
    }
}
