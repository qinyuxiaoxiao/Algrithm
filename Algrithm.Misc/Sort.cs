using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm
{
    class Sort
    {
        public static readonly int[] IntArray = new int[] { 80, 55, 40, 85, 10, 70, 65, 90, 35, 75, 50, 95, 100, 25, 30, 45, 20, 60, 15 };
        //public static readonly int[] IntArray = new int[] { 10, 20, 30, 40, 50, 60, 80, 90, 100 };
        //public static readonly int[] IntArray = new int[] { 100, 95, 90, 85, 80, 75, 70, 65, 60, 55, 50, 45, 40, 35, 30, 25, 20, 15, 10 };

        public static int[] GetArray()
        {
            int[] array = new int[IntArray.Length];    
            IntArray.CopyTo(array, 0);
            return array;
        }

        public static int[] ExecuteBubble()
        {
            int[] array = GetArray();

            int complexCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                bool bubbled = false;
                for (int j = array.Length - 1; j > i; j-- )
                {
                    if (array[j - 1] > array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                        bubbled = true;
                    }
                    complexCount++;
                }

                if (!bubbled) break;
            }

            Console.WriteLine(string.Format("Complex: {0}", complexCount));

            return array;
        }

        #region Sort Quick

        private static int _complexQuickCount = 0;
        public static int[] ExecuteQuick()
        {
            int[] array = GetArray();
            _complexQuickCount = 0;

            QuickSort(array, 0, array.Length - 1);

            Console.WriteLine(string.Format("Complex: {0}", _complexQuickCount));
            return array;
        }

        private static void QuickSort(int[] array, int start, int end)
        {
            if (start >= end) return;

            int i = start; 
            int j = end;
            int pivot = array[i];
            while (i < j)
            {
                while (array[j] >= pivot && i < j)
                {
                    j--;

                    _complexQuickCount++;
                }

                if (i < j)
                {
                    array[i] = array[j];
                    i++;
                }

                while (array[i] <= pivot && i < j)
                {
                    i++;

                    _complexQuickCount++;
                }

                if (i < j)
                {
                    array[j] = array[i];
                    j--;
                }                
            }

            array[i] = pivot;

            //Console.WriteLine(string.Join(", ", array));

            QuickSort(array, start, i - 1);
            QuickSort(array, i + 1, end);
        }

        #endregion Sort Quick


        public static int[] ExecuteStraightSelection()
        {
            int[] array = GetArray();

            int complexCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                int selection = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[selection])
                    {
                        selection = j;
                    }
                    complexCount++;
                }

                if (selection != i)
                {
                    int temp = array[i];
                    array[i] = array[selection];
                    array[selection] = temp;
                }
            }
            Console.WriteLine(string.Format("Complex: {0}", complexCount));
            return array;
        }


        #region Heap Sort

        private static int _complexHeapCount = 0;

        public static int[] ExecuteHeap()
        {
            int[] array = GetArray();

            _complexHeapCount = 0;

            BuilHeap(array);
            
            for (int i = array.Length - 1; i > 0; i--)
            {
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                AdjustHeap(array, 0, i - 1); 
            }

            Console.WriteLine(string.Format("Complex: {0}", _complexHeapCount));
            return array;
        }

        private static void BuilHeap(int[] array)
        {
            int lastNonLeafNodeIndex = array.Length / 2 - 1;

            for (int i = lastNonLeafNodeIndex; i >= 0; i--)
            {
                AdjustHeap(array, i, array.Length - 1);
            }
        }

        private static void AdjustHeap(int[] array, int i, int end)
        {
            int parent = i;
            int childNode = 2 * parent + 1;

            while (childNode <= end)
            {
                _complexHeapCount++;

                if (childNode + 1 <= end && array[childNode] < array[childNode + 1])
                {
                    childNode = childNode + 1;
                }

                if (array[parent] > array[childNode])
                {
                    break;
                }

                int temp = array[childNode];
                array[childNode] = array[parent];
                array[parent] = temp;

                parent = childNode;
                childNode = 2 * parent + 1;
            }

            Console.WriteLine(string.Join(", ", array));
        }

        #endregion Heap Sort
        
        public static int[] ExecuteInsertion()
        {
            int[] array = GetArray();
            int complexCount = 0;

            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                int temp = array[i];
                while (j > 0 && array[j - 1] > temp) 
                {
                    array[j] = array[j - 1];
                    j = j - 1;
                    complexCount++;
                }

                array[j] = temp;
            }

            Console.WriteLine(string.Format("Complex: {0}", complexCount));
            return array;
        }

        private static int _complexShellCount = 0;

        #region Wrong Shell Sort

        public static int[] WrongExecuteShell()
        {
            int[] array = GetArray();
            _complexShellCount = 0;

            WrongShellSort(array, array.Length / 2);

            Console.WriteLine(string.Format("Complex: {0}", _complexShellCount));
            return array;
        }

        private static void WrongShellSort(int[] array, int interval)
        {
            if (interval == 0) return;

            for (int i = 0; i < interval; i++)
            {
                for ( int j = i + interval; j < array.Length; j = j + interval )
                {               
                    int k = j;
                    int temp = array[j];

                    _complexShellCount++; // Increase 1 in advance, even if it will not go into below "while" loop

                    while (k > i && array[k - interval] > temp)
                    {
                        array[k] = array[k - interval];
                        k = k - interval;

                        _complexShellCount++; // Count in "while" loop

                        if (k <= i) _complexShellCount--; // Decrease 1 to correct the count if it has gone into "while" loop ever
                    }

                    array[k] = temp;
                }

                //Console.WriteLine(string.Join(", ", array));
            }

            WrongShellSort(array, interval / 2);
        }

        #endregion Shell Sort

        #region Correct Shell Sort

        public static int[] ExecuteShell()
        {
            int[] array = GetArray();

            int interval = array.Length / 2;
            while (interval > 0)
            {
                GroupedInsert(array, interval);
                interval = interval / 2;
            }

            return array;
        }

        private static void GroupedInsert(int[] array, int interval)
        {
            if (interval < 1) return;

            for (int i = 0; i < interval; i++)
            {
                for (int j = i; j < array.Length; j = j + interval)
                {
                    _complexShellCount++; 

                    int value = array[j];
                    int insertPosition = j;
                    while (insertPosition > i && array[insertPosition - interval] > value)
                    {
                        array[insertPosition] = array[insertPosition - interval];
                        insertPosition = insertPosition - interval;

                    }

                    if (insertPosition != j)
                    {
                        array[insertPosition] = value;
                    }
                }
            }
        }

        #endregion

        public static int[] ExecuteMerge()
        {
            int[] array1 = ExecuteInsertion();
            int[] array2 = ExecuteInsertion();
            int[] mergedArray = new int[array1.Length + array2.Length];

            int i = 0;
            int j = 0;
            int mergedIndex = 0;
            while (i < array1.Length && j < array2.Length)
            {
                if (array1[i] < array2[j])
                {
                    mergedArray[mergedIndex] = array1[i];
                    i++;
                }
                else
                {
                    mergedArray[mergedIndex] = array1[j];
                    j++;
                }

                mergedIndex++;
            }

            while (i < array1.Length)
            {
                mergedArray[mergedIndex++] = array1[i++];
            }

            while (j < array2.Length)
            {
                mergedArray[mergedIndex++] = array2[j++];
            }

            return mergedArray;
        }
    }
}
