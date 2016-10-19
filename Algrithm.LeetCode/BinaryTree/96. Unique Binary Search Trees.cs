using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Algrithm.LeetCode
{
    /*
        Given n, how many structurally unique BST's (binary search trees) that store values 1...n?
        For example,
        Given n = 3, there are a total of 5 unique BST's.

        1         3     3      2      1         \       /     /      / \      \          3     2     1      1   3      2         /     /       \                 \        2     1         2                 3
    */
    class UniqueBinarySearchTrees
    {
        private static int Calc(int n)
        {
            int[] counts = new int[n + 1]; 
            counts[0] = 1;  // 0代表节点为Null元素的情况，用于后续计算
            counts[1] = 1;
            counts[2] = 2;
            if (n <= 2) return counts[n];

            for(int i = 3; i <= n; i++)
            {
                int totalCount = 0;
                for(int j = 0; j <= i - 1; j++)
                {
                    totalCount += counts[j] * counts[i - 1 - j];
                }

                counts[i] = totalCount;
            }

            return counts[n];
        }

        //static void Main(string[] args)
        //{
        //    const int N = 3;

        //    Console.WriteLine(string.Format("Total unique BSTs count of numbers 1 - {0}: {1}", N, Calc(N)));
        //}
    }
}
