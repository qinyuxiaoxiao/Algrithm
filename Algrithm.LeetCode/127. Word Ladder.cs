using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
        Given two words (beginWord and endWord), and a dictionary's word list, find the length of shortest transformation sequence from beginWord to endWord, such that:
        1. Only one letter can be changed at a time
        2. Each intermediate word must exist in the word list

        For example,
        Given:
        beginWord = "hit"
        endWord = "cog"
        wordList = ["hot","dot","dog","lot","log"]

        As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
        return its length 5.

        Note:
        • Return 0 if there is no such transformation sequence.
        • All words have the same length.

        All words contain only lowercase alphabetic characters.
    */
    class WordLadder
    {
        private static int GetShortestLength(List<string> words, string begin, string end)
        {
            if (words == null || words.Count == 0
                || string.IsNullOrWhiteSpace(begin)
                || string.IsNullOrWhiteSpace(end)
                || begin.Length != end.Length)
            {
                return 0;
            }
            
            int length = 1;
            Queue<string> matches = new Queue<string>();
            matches.Enqueue(begin);

            while(matches.Count > 0)
            {
                int matchCount = matches.Count;
                for(int i = 0; i < matchCount; i++)
                {
                    string match = matches.Dequeue();                    
                    char[] letters = match.ToArray(); // String[]索引器是只读的，无法通过它修改其中的字符，所以使用char[]，可以对其中的字符进行修改或恢复
                    for (int j = 0; j < match.Length; j++)
                    {
                        char origin = letters[j];

                        for (int k = 'a'; k <= 'z'; k++)
                        {
                            letters[j] = (char)k;                            
                            string testWord = new string(letters);

                            if(testWord == end)
                            {
                                return length + 1;
                            }
                            else if(words.IndexOf(testWord) >= 0)
                            {
                                matches.Enqueue(testWord);
                                words.Remove(testWord);
                            }
                        }

                        letters[j] = origin;
                    }
                }

                length = length + 1;
            }

            return 0;
        }

        static void Main(string[] args)
        {
            List<string> words = new List<string> { "hot", "dot", "dog", "lot", "log" };
            int shortestLength = GetShortestLength(words, "hit", "cog");
            Console.WriteLine("The shortest length is: " + shortestLength);
        }

    }
}
