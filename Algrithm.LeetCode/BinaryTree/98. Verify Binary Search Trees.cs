using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
        Given a binary tree, determine if it is a valid binary search tree (BST).
        Assume a BST is defined as follows:
            • The left subtree of a node contains only nodes with keys less than the node's key.
            • The right subtree of a node contains only nodes with keys greater than the node's key.
            • Both the left and right subtrees must also be binary search trees.

        Example 1:

           2           / \          1   3
        Binary tree [2,1,3], return true.

        Example 2:

           1           / \          2   3
        Binary tree [1,2,3], return false.
    */
    /// <summary>
    /// BST的特点就是，如果采用中序遍历，其节点的值是从小到大递增的
    /// 所以验证BST的关键也就是：采用中序遍历，先Left，再Self，再Right，依次判断节点的值是否符合BST要求（Left  <  Self < Right)
    /// </summary>
    class VerifyBinarySearchTrees
    {
        private static bool IsBST(TreeNode node, ref int maxValue)
        {
            // 触底
            if (node == null) return true;

            // 先验证Left
            if (!IsBST(node.Left, ref maxValue))
            {
                return false;
            }

            // 再验证Self
            if (node.Value <= maxValue)
            {
                return false;
            }
            else
            {
                /* 记录最大值 */
                maxValue = node.Value;
            }

            // 再验证Right
            return IsBST(node.Right, ref maxValue);
        }

        //static void Main(string[] args)
        //{
        //    TreeNode topNode = BuildBST();
        //    int maxValue = int.MinValue;
        //    Console.WriteLine("Is BST: " + IsBST(topNode, ref maxValue));
        //    //Console.WriteLine("Is BST: " + IsBST_NonRecursive(topNode));
        //}

        /// <summary>
        /// 测试用：构建BST，按照In-order Traversal中序遍历的方式自底向上来创建BST
        ///                     4
        ///               /           \
        ///            2                 6
        ///        /       \          /     \
        ///     1            3     5           7
        /// </summary>
        /// <returns></returns>
        private static TreeNode BuildBST()
        {
            TreeNode node1 = new TreeNode();
            node1.Value = 1;
            TreeNode node2 = new TreeNode();
            node2.Value = 2;
            TreeNode node3 = new TreeNode();
            node3.Value = 3;

            node2.Left = node1;
            node2.Right = node3;
            
            TreeNode node4 = new TreeNode();
            node4.Value = 4;

            TreeNode node5 = new TreeNode();
            node5.Value = 5;
            TreeNode node6 = new TreeNode();
            node6.Value = 6;
            TreeNode node7 = new TreeNode();
            node7.Value = 7;

            node6.Left = node5;
            node6.Right = node7;

            node4.Left = node2;
            node4.Right = node6;

            return node4;
        }

        /* 非递归版本 */
        /// <summary>
        /// 把思路转化为代码的关键： 把节点在堆栈中的入栈、出栈顺序画出来
        /// 其核心思想仍然是中序遍历，先Left，再Self，再Right
        /// </summary>
        /// <param name="topNode"></param>
        /// <returns></returns>
        private static bool IsBST_NonRecursive(TreeNode topNode)
        {
            if (topNode == null) return true;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = topNode;
            int maxValue = int.MinValue;
            while (stack.Count > 0 || current != null)
            {
                // 先Left
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                // 再Left
                TreeNode popNode = stack.Pop();
                if (popNode.Value <= maxValue)
                {
                    return false;
                }
                else
                {
                    maxValue = popNode.Value;
                }

                // 再Right
                current = popNode.Right;
            }

            return true;
        }
    }
}
