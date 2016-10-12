using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algrithm
{
    class PalinDrome
    {
        private const string INPUT_TEXT = @"started[ It seems impossible. As I pee sir I see Pisa. Really?]ended
                                            started[ Are we not pure? “No sir!” Panama’s moody Noriega brags. “It is garbage!” Irony dooms a man; a prisoner up to new era.]ended
                                           ";
        private const char BLANK = ' ';

        public static string InputText
        {
            get
            {
                return INPUT_TEXT;
            }
        }

        public static List<string> Execute()
        {
            string input = INPUT_TEXT;
            List<string> palinDromes = new List<string>();            
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == BLANK || ! Char.IsLetter(input[i])) continue;

                for (int j = input.Length - 1; j > i; j--)
                {
                    if (input[j] == BLANK || ! Char.IsLetter(input[j])) continue;

                    if (Char.ToUpper(input[j]) == Char.ToUpper(input[i]))
                    {
                        int front = i;
                        int end = j;
                        StringBuilder sbFront = new StringBuilder();
                        StringBuilder sbEnd = new StringBuilder();

                        while ( front < end)
                        {
                            while ((input[front] == BLANK || ! Char.IsLetter(input[front]))
                                && front < end)
                            {
                                front++;
                            }

                            while ((input[end] == BLANK || !Char.IsLetter(input[end]))
                                && front < end)
                            {
                                end--;
                            }

                            if (Char.ToUpper(input[front]) == Char.ToUpper(input[end]))
                            {
                                front++;
                                end--;
                            }
                            else
                            {
                                break;
                            }
                        }

                        if (front >= end)
                        {
                            palinDromes.Add(input.Substring(i, j - i + 1));
                        }
                    }
                }
            }

            return palinDromes;
        }
    }
}
