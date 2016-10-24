using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
        Given a binary tree, check whether it is a mirror of itself (ie, symmetric around its center).
        For example, this binary tree [1,2,2,3,4,4,3] is symmetric:
            1
           / \
          2   2
         / \ / \
        3  4 4  3
        But the following [1,2,2,null,3,null,3] is not:
            1
           / \
          2   2
           \   \
           3    3
        Note:
        Bonus points if you could solve it both recursively and iteratively.
    */
    class SymmetricTree
    {
        /// <summary>
        /// 广度优先
        /// 需要包容null，需要更多存储空间
        /// </summary>
        /// <param name="topNode"></param>
        /// <returns></returns>
        private static bool IsSymmetric_BFS(TreeNode topNode)
        {
            if (topNode == null || (topNode.Left == null && topNode.Right == null)) return true;

            // 用List作为双向链表
            List<TreeNode> nodes = new List<TreeNode>();
            nodes.Add(topNode);
            int index = 0;
            int level = 0;
            bool isAllNull = false;
            while (!isAllNull)
            {
                isAllNull = true;
                int levelCount = (int)Math.Pow(2, level); // 每层的元素个数都是2的n次方（包括null节点）
                for (int i = 0; i < levelCount; i++)
                {
                    if (i < levelCount / 2)
                    {
                        if (nodes[index + i] == null && nodes[index + levelCount - i - 1] != null
                            || nodes[index + i] != null && nodes[index + levelCount - i - 1] == null)                            
                        {
                            return false;
                        }

                        if (nodes[index + i] != null && nodes[index + levelCount - i - 1] != null
                            && nodes[index + i].Value != nodes[index + levelCount - i - 1].Value)
                        {
                            return false;
                        }

                    }

                    if (nodes[index + i] != null)
                    {
                        nodes.Add(nodes[index + i].Left);
                        nodes.Add(nodes[index + i].Right);

                        if (isAllNull)
                        {
                            isAllNull = nodes[index + i].Left == null && nodes[index + i].Right == null;
                        }
                    }
                    else
                    {
                        // null不能忽略，否则判断是否对称时有可能漏判
                        nodes.Add(null);
                        nodes.Add(null);
                    }
                }

                level += 1;
                index += levelCount;
            }

            return true;
        }

        /// <summary>
        /// 相当优雅
        /// 关键点：递归时每次传入的leftNode和rightNode都是同一层中处于对称位置的两个节点
        /// </summary>
        /// <param name="leftNode"></param>
        /// <param name="rightNode"></param>
        /// <returns></returns>
        private static bool IsSymmetric_Recursive(TreeNode leftNode, TreeNode rightNode)
        {            
            if (leftNode == null && rightNode == null) return true;
            if (leftNode == null && rightNode != null || leftNode != null && rightNode == null) return false;
            if (leftNode.Value != rightNode.Value) return false;

            if (!IsSymmetric_Recursive(leftNode.Left, rightNode.Right)) return false;
            if (!IsSymmetric_Recursive(leftNode.Right, rightNode.Left)) return false;

            return true;
        }

        private static bool IsSymmetric_Iterative(TreeNode topNode)
        {
            if (topNode == null || topNode.Left == null && topNode.Right == null) return true;

            Stack<TreeNode> leftStack = new Stack<TreeNode>();
            Stack<TreeNode> rightStack = new Stack<TreeNode>();
            leftStack.Push(topNode.Left);
            rightStack.Push(topNode.Right);

            while(leftStack.Count > 0)
            {
                TreeNode leftNode = leftStack.Pop();
                TreeNode rightNode = rightStack.Pop();
                if (leftNode == null && rightNode == null) continue;

                if (leftNode == null && rightNode != null || leftNode != null && rightNode == null) return false;
                if (leftNode.Value != rightNode.Value) return false;

                // 保持对称压栈: 左左子，左右子，右右子，右左子
                leftStack.Push(leftNode.Left);
                leftStack.Push(leftNode.Right);
                rightStack.Push(rightNode.Right);
                rightStack.Push(rightNode.Left);
            }

            return true;
        }


        //static void Main(string[] args)
        //{
        //    TreeNode topNode = BuildSymmetricTree();
        //    Console.WriteLine("Is Symmetric Tree: " + IsSymmetric_BFS(topNode));
        //    Console.WriteLine("Is Symmetric Tree: " + IsSymmetric_Recursive(topNode, topNode));
        //    Console.WriteLine("Is Symmetric Tree: " + IsSymmetric_Iterative(topNode));
        //}



        /*       
                    1
                   / \
                  2   2
                 / \ / \
                3  4 4  3
               /\ /\ /\ /\
              5           5
        */
        private static TreeNode BuildSymmetricTree()
        {
            TreeNode node1 = new TreeNode();
            node1.Value = 1;

            TreeNode node2 = new TreeNode();
            node2.Value = 2;
            TreeNode node3 = new TreeNode();
            node3.Value = 2;
            node1.Left = node2;
            node1.Right = node3;

            TreeNode node4 = new TreeNode();
            node4.Value = 3;
            TreeNode node5 = new TreeNode();
            node5.Value = 4;
            TreeNode node6 = new TreeNode();
            node6.Value = 4;
            TreeNode node7 = new TreeNode();
            node7.Value = 3;
            node2.Left = node4;
            node2.Right = node5;
            node3.Left = node6;
            node3.Right = node7;

            TreeNode node8 = new TreeNode();
            node8.Value = 5;
            TreeNode node9 = new TreeNode();
            node9.Value = 5;
            node4.Left = node8;
            node7.Right = node9;

            return node1;
        }

    }
}
