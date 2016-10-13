using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeTest
{
    class SortColor
    {
        //static void Main(string[] args)
        //{
        //    int[] array1 = { 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2 };
        //    int[] array2 = { 2, 1, 0, 2, 1, 0, 2, 1, 0, 2, 1, 1 };
        //    int[] array3 = { 0, 0, 1, 1, 2, 0, 2, 1, 1, 0, 1, 2, 2, 0, 1, 0 };
        //    int[] array4 = { 2, 1, 2, 1, 2, 1, 0, 0, 1, 1, 0, 2, 2, 0, 0, 1 };

        //    Sort(array1);
        //    Console.WriteLine(string.Join(", ", array1));
        //    Sort(array2);
        //    Console.WriteLine(string.Join(", ", array2));
        //    Sort(array3);
        //    Console.WriteLine(string.Join(", ", array3));
        //    Sort(array4);
        //    Console.WriteLine(string.Join(", ", array4));
        //}

        private static void Sort(int[] array)
        {
            int pos0 = 0;
            int pos2 = array.Length - 1;
            for (int i = 0; i < pos2;)
            {
                if(array[i] == 0)
                {
                    if (pos0 != i)
                    {
                        array[i] = array[pos0];
                        array[pos0++] = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                else if (array[i] == 2)
                {
                    if (pos2 != i)
                    {
                        array[i] = array[pos2];
                        array[pos2--] = 2;
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
