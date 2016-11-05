using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
    Given a binary tree, flatten it to a linked list in-place.

    For example,


    Given
             1
            / \
           2   5
          / \   \
         3   4   6



    The flattened tree should look like:

       1
        \
         2
          \
           3
            \
             4
              \
               5
                \
                 6

    Hints: If you notice carefully in the flattened tree, each node's right child points to the next node of a pre-order traversal.

    */
    /// <summary>
    /// 自行思考解决，时间复杂度为O(n)，比参考答案要好
    /// 关键：
    ///     自下向上，先左子树，再右子树，进行扁平化，然后将当前节点的左子节点设置为Null，右子节点设置为左子树（左子树此时已扁平化），再针对已扁平化的左子树返回的最底部节点，将其右子节点设置为当前结点的已扁平化的右子树。
    ///     扁平化函数返回扁平化之后的最底部节点，即，左子树返回左子树扁平化之后的最底部节点，右子树返回右子树扁平化之后的最底部节点。如果右子树为空，返回当前节点作为最底部节点。
    /// </summary>
    class FlatenBinaryTreetToLinkedList
    {
        private static TreeNode Flaten(TreeNode node)
        {
            if (node == null) return null;

            TreeNode leftBottomNode = Flaten(node.Left);
            TreeNode rightBottomNode = Flaten(node.Right);
            if (leftBottomNode != null)
            {
                TreeNode rightNode = node.Right;
                node.Right = node.Left;
                node.Left = null;
                leftBottomNode.Right = rightNode;
            }

            if (rightBottomNode == null && leftBottomNode == null)
            {
                return node;
            }
            else if(leftBottomNode != null && rightBottomNode == null)
            {
                return leftBottomNode;
            }
            else
            {
                return rightBottomNode;
            }
        }

        //static void Main(string[] args)
        //{
        //    TreeNode topNode = BuildTree();
        //    Flaten(topNode);
        //    PrintTree(topNode);
        //    Console.WriteLine();
        //}


        /// <summary>
        ///                     1
        ///               /           \
        ///            2                 5
        ///        /       \          /     \
        ///     3            4      6           7
        /// </summary>
        /// <returns></returns>
        private static TreeNode BuildTree()
        {
            TreeNode node1 = new TreeNode();
            node1.Value = 1;
            TreeNode node2 = new TreeNode();
            node2.Value = 2;
            TreeNode node3 = new TreeNode();
            node3.Value = 3;
            TreeNode node4 = new TreeNode();
            node4.Value = 4;
            TreeNode node5 = new TreeNode();
            node5.Value = 5;
            TreeNode node6 = new TreeNode();
            node6.Value = 6;
            TreeNode node7 = new TreeNode();
            node7.Value = 7;

            node1.Left = node2;
            node1.Right = node5;
            node2.Left = node3;
            node2.Right = node4;
            node5.Left = node6;
            node5.Right = node7;

            return node1;
        }

        private static void PrintTree(TreeNode topNode)
        {
            TreeNode currentNode = topNode;
            while(currentNode != null)
            {
                Console.WriteLine(currentNode.Value);
                if (currentNode.Left != null) Console.WriteLine("Error: " + currentNode.Left.Value);

                currentNode = currentNode.Right;
            }
        }
    }
}
