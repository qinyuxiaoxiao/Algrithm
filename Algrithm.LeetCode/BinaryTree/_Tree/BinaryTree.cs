using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.LeetCode
{
    class BinaryTree
    {
        public static TreeNode BuildBalanceTree(int count)
        {
            if (count == 0) return null;

            TreeNode topNode = new TreeNode();
            topNode.DisplayDepth = 1;
            topNode.Value = 1;
            topNode.TreeNodeCount = count;

            Queue<TreeNode> queueNodes = new Queue<TreeNode>();
            queueNodes.Enqueue(topNode);


            int value = 2;
            while (value <= count && queueNodes.Count > 0)
            {
                TreeNode parentNode = queueNodes.Dequeue();

                if (value <= count)
                {
                    TreeNode leftNode = new TreeNode();
                    leftNode.Value = value;
                    leftNode.DisplayDepth = parentNode.DisplayDepth + 1;
                    parentNode.Left = leftNode;
                    queueNodes.Enqueue(leftNode);
                    value++;
                }

                if (value <= count)
                {
                    TreeNode rightNode = new TreeNode();
                    rightNode.Value = value;
                    rightNode.DisplayDepth = parentNode.DisplayDepth + 1;
                    parentNode.Right = rightNode;
                    queueNodes.Enqueue(rightNode);
                    value++;
                }
            }

            return topNode;
        }
    }
}
