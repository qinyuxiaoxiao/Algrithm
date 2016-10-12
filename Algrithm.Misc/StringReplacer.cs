using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm
{
    class StringReplacer
    {
        public const string Text = "abcd abc e 2";
        public static readonly string[] ReplaceFroms = new string[] { "ab", "bc", "abcd", "e", "2" };
        public static readonly string[] ReplaceTos = new string[] { "10", "20", "30", "2", "5" };

        public static string Replace()
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            while (i < Text.Length)
            {
                int maxMatchedReplaceItem = -1;
                for (int j = 0; j < ReplaceFroms.Length; j++)
                {              
                    string replaceFrom = ReplaceFroms[j];
                    if ( replaceFrom.Length == 0 ) continue;

                    int matchedEndIndex = i;
                    int replaceEndIndex = 0;
                    while (matchedEndIndex < Text.Length
                        && replaceEndIndex < replaceFrom.Length
                        && Text[matchedEndIndex] == replaceFrom[replaceEndIndex])
                    {
                        matchedEndIndex++;
                        replaceEndIndex++;
                    }

                    if (replaceEndIndex == replaceFrom.Length
                        && replaceEndIndex > 0)
                    {
                        if (maxMatchedReplaceItem < 0 || replaceFrom.Length > ReplaceFroms[maxMatchedReplaceItem].Length)
                        {
                            maxMatchedReplaceItem = j;
                        }
                    }
                }

                if (maxMatchedReplaceItem >= 0 && maxMatchedReplaceItem < ReplaceTos.Length)
                {
                    sb.Append(ReplaceTos[maxMatchedReplaceItem]);
                    i = i + ReplaceFroms[maxMatchedReplaceItem].Length;
                }
                else
                {
                    sb.Append(Text[i]);
                    i = i + 1;
                }                
            }
            

            return sb.ToString();
        }
    }
}
