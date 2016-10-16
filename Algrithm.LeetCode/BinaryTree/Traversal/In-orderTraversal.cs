using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Algrithm.LeetCode
{
    class InorderTraversal
    {
        private static List<TreeNode> Traverse(TreeNode topNode)
        {
            if (topNode == null) return null;
            List<TreeNode> traversalNodes = new List<TreeNode>();

            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = topNode;
            stack.Push(topNode);

            while (stack.Count > 0 || current != null)
            {
                while (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }

                current = stack.Pop();
                traversalNodes.Add(current);
                current = current.Right;
            }

            return traversalNodes;
        }

        //static void Main(string[] args)
        //{
        //    TreeNode topNode = BinaryTree.BuildBalanceTree(20);
        //    List<TreeNode> traversalNodes = Traverse(topNode);
        //    Console.WriteLine(topNode.GetBSTTreeStructure());
        //    Console.WriteLine(string.Join(", ", traversalNodes.Select(n => n.Value)));
        //}
    }
}
