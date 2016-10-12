using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
    [leetcode] 89. Gray Code

    The gray code is a binary numeral system where two successive values differ in only one bit.
    Given a non-negative integer n representing the total number of bits in the code, print the sequence of gray code. A gray code sequence must begin with 0.
    For example, given n = 2, return [0,1,3,2]. Its gray code sequence is:

    00 - 0    01 - 1    11 - 3    10 - 2
    Note:
    For a given n, a gray code sequence is not uniquely defined.
    For example, [0,2,3,1] is also a valid gray code sequence according to the above definition.
    */
    class GrayCode
    {
        private static List<int> GenerateGrayCode(int n)
        {
            if (n == 0) return null;

            List<int> grayCodes = new List<int>();

            grayCodes.Add(0);
            for(int i = 0; i < n; i++)
            {
                for(int j = grayCodes.Count - 1; j >= 0; j--)
                {
                    grayCodes.Add(grayCodes[j] + (1 << i));
                }
            }

            return grayCodes;
        }

        //static void Main(string[] args)
        //{
        //    const int N = 3;
        //    var grayCodes = GenerateGrayCode(N);

        //    Console.WriteLine(string.Join(", ", grayCodes));
        //    Console.WriteLine();

        //    for(int i = 0; i < grayCodes.Count; i++)
        //    {
        //        var binaryString = Convert.ToString(grayCodes[i], 2);
        //        Console.WriteLine(string.Join("", Enumerable.Range(0, N - binaryString.Length).Select(number => 0)) + binaryString);
        //    }

        //    Console.WriteLine();
        //}
    }


    /* 
    
    N = 3
            000
            001
            011
            010
            110
            111
            101
            100
                  
    
    N = 4
            0000
            0001
            0011
            0010
            0110
            0111
            0101
            0100
            1100
            1101
            1111
            1110
            1010
            1011
            1001
            1000

    */
}
