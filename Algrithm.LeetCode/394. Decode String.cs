using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
        Given an encoded string, return it's decoded string.

        The encoding rule is: k[encoded_string], where the encoded_string inside the square brackets is being repeated exactly k times. Note thatk is guaranteed to be a positive integer.
        You may assume that the input string is always valid; No extra white spaces, square brackets are well-formed, etc.
        Furthermore, you may assume that the original data does not contain any digits and that digits are only for those repeat numbers, k. For example, there won't be input like 3a or2[4].

        Examples:
        s = "3[a]2[bc]", return "aaabcbc".
        s = "3[a2[c]]", return "accaccacc".
        s = "2[abc]3[cd]ef", return "abcabccdcdcdef".
    */
    /// <summary>
    /// 利用栈，注意把字符组合成一个数字或字符串之后再入栈，而不是单纯的一个一个字符入栈，否则会增加复杂度
    /// 所以这里用到了Stack<string>而不是Stack<char>
    /// </summary>
    class DecodeString
    {
        private static string Decode(string text)
        {
            string current = string.Empty;
            int number = 0;
            Stack<string> stack = new Stack<string>();

            for(int i = 0; i < text.Length; i++)
            {
                if (text[i] >= '0' && text[i] <= '9')
                {
                    number = (10 * number) + (text[i] - '0');
                }
                else if (text[i] == '[')
                {
                    stack.Push(current);
                    stack.Push(number.ToString());
                    current = string.Empty;
                    number = 0;
                }
                else if (text[i] == ']')
                {
                    int count = int.Parse(stack.Pop());
                    string sequence = string.Empty;
                    for(int j = 0; j < count; j++)
                    {
                        sequence = sequence + current;
                    }
                    current = stack.Pop() + sequence;
                }
                else
                {
                    current = current + text[i].ToString();
                }
            }

            return current;
        }

        //static void Main(string[] args)
        //{
        //    const string TEXT = "new2[abc]3[cd]ef";
        //    string result = Decode(TEXT);
        //    Console.WriteLine("The decoded result is: " + result);
        //}

    }
}
