using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.Tree
{
    class BinaryTree
    {

        #region Build Balance Tree

        public static TreeNode BuildBalanceTree(int count)
        {
            if (count == 0) return null;

            TreeNode topNode = new TreeNode();
            topNode.DisplayDepth = 1;
            topNode.Value = count;

            Queue<TreeNode> queueNodes = new Queue<TreeNode>();
            queueNodes.Enqueue(topNode);
            int restCount = count - 1;
            BuildBalanceTree(queueNodes, restCount);

            return topNode;
        }

        private static void BuildBalanceTree(Queue<TreeNode> queueNodes, int restCount)
        {
            if (restCount == 0) return;

            while (restCount > 0 && queueNodes.Count > 0)
            {
                TreeNode parentNode = queueNodes.Dequeue();

                if (restCount > 0)
                {
                    TreeNode leftNode = new TreeNode();
                    leftNode.Value = restCount;
                    leftNode.DisplayDepth = parentNode.DisplayDepth + 1;
                    parentNode.Left = leftNode;
                    queueNodes.Enqueue(leftNode);
                    restCount--;
                }

                if (restCount > 0)
                {
                    TreeNode rightNode = new TreeNode();
                    rightNode.Value = restCount;
                    rightNode.DisplayDepth = parentNode.DisplayDepth + 1;
                    parentNode.Right = rightNode;
                    queueNodes.Enqueue(rightNode);
                    restCount--;
                }
            }
        }

        #endregion End Build Balance Tree

        public static void ScanWide(TreeNode topNode)
        {
            if (topNode == null) return;

            Queue<TreeNode> queueNodes = new Queue<TreeNode>();
            queueNodes.Enqueue(topNode);

            Console.WriteLine("Scan Tree width-first:");
            Console.WriteLine(string.Format("Node Depth: {0} \t Node Value: {1} \t Node Type: Top", topNode.DisplayDepth, topNode.Value));
            while (queueNodes.Count > 0)
            {
                TreeNode node = queueNodes.Dequeue();

                if (node.Left != null)
                {
                    Console.WriteLine(string.Format("Node Depth: {0} \t Node Value: {1} \t Node Type: Left", node.Left.DisplayDepth, node.Left.Value));
                    queueNodes.Enqueue(node.Left);
                }

                if (node.Right != null)
                {
                    Console.WriteLine(string.Format("Node Depth: {0} \t Node Value: {1} \t Node Type: Right", node.Right.DisplayDepth, node.Right.Value));
                    queueNodes.Enqueue(node.Right);
                }
            }
        }

        /*
         
        public static bool CheckBalanceOptional(TreeNode topNode)
        {
            int depth = 0;
            return CheckBalanceOptional(ref depth, topNode);
        }

        private static bool CheckBalanceOptional(ref int depth, TreeNode node)
        {
            if (node == null) return true;

            depth++;

            int depthBackup = depth;

            bool isLeftBalance = CheckBalanceOptional(ref depth, node.Left);
            if ( !isLeftBalance ) return false;
            int leftDepth = depth;

            depth = depthBackup;
            bool isRightBalance = CheckBalanceOptional(ref depth, node.Right);
            if ( !isRightBalance ) return false;
            int rightDepth = depth;

            depth = leftDepth > rightDepth ? leftDepth : rightDepth;

            Console.WriteLine(string.Format("Node Value: {0} \t Node Self Depth: {1} \t Left Depth: {2} \t Right Depth: {3}", node.Value, node.DisplayDepth, leftDepth, rightDepth));

            int difference = leftDepth - rightDepth;
            bool isBalance = (difference >= 0 && difference <= 1) || (difference <= 0 && difference >= -1);
            return isBalance;
        }
         
        */


        #region Check Balance V1

        public static bool CheckBalance(TreeNode topNode)
        {
            return GetNodeDepth(topNode) >= 0;
        }

        // If any child node (left/right) is not balance, return -1;
        // Otherwise return the actual depth: 1 + (Bigger one of left/right child depth)
        private static int GetNodeDepth(TreeNode node)
        {
            if (node == null) return 0;
            int leftDepth = GetNodeDepth(node.Left);
            if (leftDepth == -1)
            {
                Console.WriteLine(string.Format("Node Value: {0} \t Node Self Depth: {1} \t is NOT balance", node.Left.Value, node.Left.DisplayDepth));
                return -1;
            }

            int rightDepth = GetNodeDepth(node.Right);
            if (rightDepth == -1)
            {
                Console.WriteLine(string.Format("Node Value: {0} \t Node Self Depth: {1} \t is NOT balance", node.Right.Value, node.Right.DisplayDepth));
                return -1;
            }

            Console.WriteLine(string.Format("Node Value: {0} \t Node Self Depth: {1} \t Left Depth: {2} \t Right Depth: {3}", node.Value, node.DisplayDepth, leftDepth, rightDepth));
            
            int difference = leftDepth - rightDepth;
            bool isChildBalance = (difference >= 0 && difference <= 1) || (difference <= 0 && difference >= -1);
            if (!isChildBalance)
            {
                return -1;
            }
            else
            {
                return 1 + (leftDepth > rightDepth ? leftDepth : rightDepth);
            }
        }

        #endregion


        #region Check Balance V2


        public static int GetNodeDepthV2(TreeNode node)
        {
            if (node == null) return 0;

            int leftDepth = 1 + GetNodeDepthV2(node.Left);
            int rightDepth = 1 + GetNodeDepthV2(node.Right);
            return leftDepth > rightDepth ? leftDepth : rightDepth;
        }

        public static bool CheckBalanceV2(TreeNode node)
        {
            if (node == null) return true;

            if (CheckBalanceV2(node.Left) && CheckBalanceV2(node.Right))
            {
                int leftDepth = GetNodeDepthV2(node.Left);
                int rightDepth = GetNodeDepthV2(node.Right);
                int difference = leftDepth - rightDepth;
                bool isChildBalance = (difference >= 0 && difference <= 1) || (difference <= 0 && difference >= -1);
                return isChildBalance;
            }
            else
            {
                return false;
            }
        }


        #endregion
    }
}
