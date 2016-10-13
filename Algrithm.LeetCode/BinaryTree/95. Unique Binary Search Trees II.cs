using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CodeTest
{
    /*
        Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.
        For example,
        Given n = 3, your program should return all 5 unique BST's shown below.

        1         3     3      2      1         \       /     /      / \      \          3     2     1      1   3      2         /     /       \                 \        2     1         2                 3

    */
    class UniqueBinarySearchTreesII
    {
        private static void BuildBST(List<TreeNode> bstTs, TreeNode currentNode, int currentCount, int targetCount)
        {
        }

        static void Main(string[] args)
        {
            const int N = 4;
            bool[] flags = new bool[N];
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", new List<int>()));
        }
    }
}
