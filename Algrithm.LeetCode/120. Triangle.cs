using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
    Given a triangle, find the minimum path sum from top to bottom. Each step you may move to adjacent numbers on the row below.
    For example, given the following triangle
    [
         [2],
        [3,4],
       [6,5,7],
      [4,1,8,3]
    ]
    The minimum path sum from top to bottom is 11 (i.e., 2 + 3 + 5 + 1 = 11).
    Note:
    Bonus point if you are able to do this using only O(n) extra space, where n is the total number of rows in the triangle.
    */
    /// <summary>
    /// 关键： 三角形实际上是由长度从1到n的List逐个磊在一起构成的
    /// </summary>
    class Triangle
    {
        private static int CalcMinSum(List<List<int>> triangle)
        {
            if (triangle == null || triangle.Count == 0 || triangle.First().Count == 0) return 0;

            int[] sums = new int[triangle.Count];
            sums[0] = triangle[0][0];
            for(int i = 1; i < triangle.Count; i++)
            {
                // 记录上一个位置的值（因为题目要求空间复杂度为O(n)，所以需要借助变量)
                int preSum = sums[0];

                // 头元素的情况特殊，单独处理
                sums[0] = sums[0] + triangle[i][0];

                // 头、尾之间的元素
                for(int j = 1; j < i; j++)
                {
                    int temp = sums[j];
                    sums[j] = Math.Min(preSum, sums[j]) + triangle[i][j];
                    preSum = temp;
                }

                // 尾元素的情况特殊，单独处理
                sums[i] = preSum + triangle[i][i];
            }

            int minSum = int.MaxValue;
            for(int i = 0; i < sums.Length; i++)
            {
                minSum = Math.Min(sums[i], minSum);
            }

            return minSum;
        }

        //static void Main(string[] args)
        //{
        //    int minSum = CalcMinSum(BuildTriangle());
        //    Console.WriteLine("Minimum path sum is: " + minSum);
        //}

        private static List<List<int>> BuildTriangle()
        {
            List<List<int>> triangle = new List<List<int>>();
            triangle.Add(new List<int> { 2 });
            triangle.Add(new List<int> { 3, 4});
            triangle.Add(new List<int> { 6, 5, 7 });
            triangle.Add(new List<int> { 4, 1, 8, 3 });
            return triangle;
        }

    }
}
