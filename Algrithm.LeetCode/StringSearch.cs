using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace CodeTest
{
    class StringSearch
    {
        private static bool IsExist(bool[][] pointStates, char[][] sources, string target, int currentTargetPosition, int currentColumn, int currentRow)
        {
            if (currentTargetPosition == target.Length)
            {
                return true;
            }

            if (currentColumn < 0 || currentColumn >= sources[0].Length
                || currentRow < 0 || currentRow >= sources.Length)
            {
                return false;
            }

            if (pointStates[currentRow][currentColumn] || sources[currentRow][currentColumn] != target[currentTargetPosition])
            {
                return false;
            }

            // 标记为占用
            pointStates[currentRow][currentColumn] = true;

            // 每当完成以某个点为起点的搜索，pointStates某些位置的占用状态已被污染(即为true)
            // 但是由于只要搜索到一个符合条件的字符串就函数返回，并不再需要pointStates，所以pointStates不需要全部重新创建
            // 如果题目要求是找到所有符合条件的坐标路径，那么在每执行完IsExist之后，在return true返回之前，都需要重置pointStates[currentRow][currentColumn]占用状态为false
            if (IsExist(pointStates, sources, target, currentTargetPosition + 1, currentColumn - 1, currentRow))
            {
                return true;
            }

            if (IsExist(pointStates, sources, target, currentTargetPosition + 1, currentColumn + 1, currentRow))
            {
                return true;
            }

            if (IsExist(pointStates, sources, target, currentTargetPosition + 1, currentColumn, currentRow - 1))
            {
                return true;
            }

            if (IsExist(pointStates, sources, target, currentTargetPosition + 1, currentColumn, currentRow + 1))
            {
                return true;
            }

            // 还原标记为未占用
            pointStates[currentRow][currentColumn] = false;
            return false;
        }

        private static bool IsExist(char[][] sources, string target)
        {
            // 各位置的占用状态列表，占用为true，未占用为false
            bool[][] pointStates = InitPointStates(sources);

            bool isExist = false;
            for (int column = 0; column < sources[0].Length; column++)
            {
                for (int row = 0; row < sources.Length; row++)
                {
                    if (IsExist(pointStates, sources, target, 0, column, row))
                    {
                        isExist = true;
                        break;
                    }
                }
            }
            return isExist;
        }

        private static bool[][] InitPointStates(char[][] sources)
        {   
            bool[][] pointStates = new bool[sources.Length][];
            for(int i = 0; i < pointStates.Length; i++)
            {
                pointStates[i] = new bool[sources[0].Length];
            }
            return pointStates;
        }

        //static void Main(string[] args)
        //{
        //    const string TARGET_1 = "ABCCED";
        //    const string TARGET_2 = "SEE";
        //    const string TARGET_3 = "ABCB";
        //    const string TARGET_4 = "EEDASFCSECBA";
        //    const string TARGET_5 = "BFCED";

        //    char[][] sources = new char[3][];
        //    sources[0] = new char[] { 'A', 'B', 'C', 'E' };
        //    sources[1] = new char[] { 'S', 'F', 'C', 'S' };
        //    sources[2] = new char[] { 'A', 'D', 'E', 'E' };

        //    Console.WriteLine(string.Format("'{0}' is existing: {1}", TARGET_1, IsExist(sources, TARGET_1)));
        //    Console.WriteLine(string.Format("'{0}' is existing: {1}", TARGET_2, IsExist(sources, TARGET_2)));
        //    Console.WriteLine(string.Format("'{0}' is existing: {1}", TARGET_3, IsExist(sources, TARGET_3)));
        //    Console.WriteLine(string.Format("'{0}' is existing: {1}", TARGET_4, IsExist(sources, TARGET_4)));
        //    Console.WriteLine(string.Format("'{0}' is existing: {1}", TARGET_5, IsExist(sources, TARGET_5)));
        //}
    }
}
