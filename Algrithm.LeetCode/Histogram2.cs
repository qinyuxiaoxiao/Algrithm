using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace CodeTest
{
    class Histogram2
    {
        private static int CalcMaxArea(int[] barHeights)
        {
            if (barHeights == null || barHeights.Length == 0) return 0;

            int maxArea = 0;
            Stack<int> indexes = new Stack<int>();
            int pos = 0;
            while (pos < barHeights.Length)
            {
                if (indexes.Count == 0 || barHeights[pos] >= barHeights[indexes.Peek()])
                {
                    indexes.Push(pos);
                    pos++;
                }
                else
                {
                    int tallestPos = indexes.Pop();
                    int height = barHeights[tallestPos];
                    int with = indexes.Count == 0 ? pos : pos - indexes.Peek() - 1;
                    maxArea = Math.Max(maxArea, height * with);
                }
            }

            // 栈中剩余的Bar，有效宽度是距离栈顶元素（即集合barHeights的末尾元素)的间距
            int endPos = indexes.Count == 0 ? 0 : indexes.Peek();
            while (indexes.Count > 0)
            {
                int currentPos = indexes.Pop();
                int height = barHeights[currentPos];
                int width = endPos - currentPos + 1;
                maxArea = Math.Max(maxArea, height * width);
            }

            return maxArea;
        }
        
        //static void Main(string[] args)
        //{
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 1, 5, 6, 2, 3 })));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 1, 5, 6, 2, 3, 10 })));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 1, 5, 6, 2, 3, 11 })));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 2, 5, 6, 2, 3, 10 })));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 2, 1, 5, 5, 6, 2, 3, 10 })));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1 })));
        //    Console.WriteLine(string.Format("Max area is: {0}", CalcMaxArea(new int[] { 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 4, 4, 4 })));
        //}

        //private static int CalcMaxArea(int[] barHeights)
        //{
        //    Stack<int> idx = new Stack<int>();
        //    int maxArea = 0;
        //    for (int i = 0; i < barHeights.Count(); i++)
        //    {
        //        if (idx.Count == 0 || barHeights[i] >= barHeights[idx.Peek()])
        //        {
        //            idx.Push(i);
        //        }
        //        else
        //        {
        //            int preIdx = idx.Peek();
        //            idx.Pop();
        //            maxArea = Math.Max(maxArea, barHeights[preIdx] * (idx.Count == 0 ? i : (i - idx.Peek() - 1)));
        //            i--;
        //        }
        //    }
        //    int sz = barHeights.Count();
        //    while (idx.Count() > 0)
        //    {
        //        int preIdx = idx.Peek();
        //        idx.Pop();
        //        maxArea = Math.Max(maxArea, barHeights[preIdx] * (idx.Count == 0 ? sz : (sz - idx.Peek() - 1)));
        //    }
        //    return maxArea;

        //}
    }
}
