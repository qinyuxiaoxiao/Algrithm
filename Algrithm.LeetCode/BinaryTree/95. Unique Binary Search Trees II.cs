using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Algrithm.LeetCode
{
    /*
        Given n, generate all structurally unique BST's (binary search trees) that store values 1...n.
        For example,
        Given n = 3, your program should return all 5 unique BST's shown below.

        1         3     3      2      1         \       /     /      / \      \          3     2     1      1   3      2         /     /       \                 \        2     1         2                 3

    */
    class UniqueBinarySearchTreesII
    {
        /// <summary>
        /// 比较考验二叉树搜索的方方面面，该函数返回基于start和end之间的数字能够创造出的所有的树，即返回所有创造出来的树集合的顶节点集合
        /// 关键突破点： 
        /// 1. 分治法，从start和end之间选取某个数字作为父节点，小于该数字的所有左边数字构成左子数，大于该数字的所有右边数字构成右子树，使用相同的步骤来构建左子树和右子树
        /// 2. 先产生左、右子树所有各自可能的集合，再将左、右子树各自可能的子树相互组合搭配以创建新的父节点
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        private static List<TreeNode> BuildBST(int start, int end)
        {
            if (start > end)
            {
                // 返回包含1个Null元素的一个列表，用于即使左、右子树其中一个为Null，也能保证遍历左、右子树的两个for嵌套循环(j, k)能够顺利进行
                return new List<TreeNode> { null };
            }

            List<TreeNode> allTrees = new List<TreeNode>();
            for (int i = start; i <= end; i++)
            {
                List<TreeNode> allLeftTrees = BuildBST(start, i - 1);
                List<TreeNode> allRightTrees = BuildBST(i + 1, end);

                for(int j = 0; j < allLeftTrees.Count; j++)
                {
                    for(int k = 0; k < allRightTrees.Count; k++)
                    {                        
                        TreeNode currentNode = new TreeNode();
                        currentNode.Value = i;
                        currentNode.Left = allLeftTrees[j];
                        currentNode.Right = allRightTrees[k];
                        allTrees.Add(currentNode);
                    }
                }
            }

            return allTrees;
        }

        static void Main(string[] args)
        {
            const int N = 3;            
            List<TreeNode> allTrees = BuildBST(1, N);

            for (int i = 0; i < allTrees.Count; i++)
            {
                var breadthFirstTraversal = TraverseBreadthFirst(allTrees[i]);
                Console.WriteLine(string.Join(", ", breadthFirstTraversal));
            }
        }

        static List<string> TraverseBreadthFirst(TreeNode topNode)
        {
            List<string> results = new List<string>();

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(topNode);
            while(queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();
                if (currentNode != null)
                {
                    results.Add(currentNode.Value.ToString());
                    queue.Enqueue(currentNode.Left);
                    queue.Enqueue(currentNode.Right);
                }
                else
                {
                    results.Add("NULL");
                }
            }

            return results;
        }
    }
}
