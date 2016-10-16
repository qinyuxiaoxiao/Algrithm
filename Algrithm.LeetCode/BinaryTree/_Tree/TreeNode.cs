using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm.LeetCode
{
    class TreeNode
    {
        public int Value
        {
            get;
            set;
        }

        public TreeNode Left
        {
            get;
            set;
        }

        public TreeNode Right
        {
            get;
            set;
        }

        public int DisplayDepth
        {
            get;
            set;
        }

        public int TreeNodeCount
        {
            get;
            set;
        }

        public string GetBSTTreeStructure()
        {
            int treeMaxDepth = (int)Math.Log(this.TreeNodeCount, 2) + 1;
            int bottomNodeCount = (int)Math.Pow(2, treeMaxDepth - 1);
            int bottomNodeWidth = (bottomNodeCount + 1) * 8;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(this);
            TreeNode lastNode = this;
            StringBuilder sb = new StringBuilder();
            while (queue.Count > 0)
            {
                TreeNode currentNode = queue.Dequeue();
                if (currentNode == null)
                {
                    sb.Append(Environment.NewLine);
                    break;
                }

                int levelNodeCount = (int)Math.Pow(2, currentNode.DisplayDepth - 1);

                int digitCount = currentNode.CalcDigitCount();
                int interval = (bottomNodeWidth - levelNodeCount * digitCount) / (levelNodeCount + 1);
                sb.Append(string.Join(string.Empty, Enumerable.Range(0, interval).Select(i => " ")));

                sb.Append(currentNode.Value);

                queue.Enqueue(currentNode.Left);
                queue.Enqueue(currentNode.Right);

                if(currentNode == lastNode)
                {
                    lastNode = currentNode.Right;
                    sb.Append(Environment.NewLine);
                    sb.Append(Environment.NewLine);
                }

            }

            sb.Append(Environment.NewLine);
            return sb.ToString();
        }

        /// <summary>
        /// 计算TreeNode所处的层的最左边的值的数字位数（当小于10时为1位数，当大于10小于100时为2位数...只考虑最多4位数的情况，因为太大了。。。）
        /// </summary>
        /// <returns></returns>
        private int CalcDigitCount()
        {
            int mostLeftNodeValue = (int)Math.Pow(2, this.DisplayDepth - 1);
            if (mostLeftNodeValue < 10)
            {
                return 1;
            }

            if (mostLeftNodeValue < 100)
            {
                return 2;
            }

            if (mostLeftNodeValue < 1000)
            {
                return 3;
            }

            return 4;
        }
    }
}
