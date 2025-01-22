using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsolePractice.GeneralQuery
{
    public static class GeneralQueries
    {
        /// <summary>
        /// Exchange Integer
        /// </summary>
        public static void ExchangeInteger()
        {
            int a = 10;
            int b = 5;
            Console.WriteLine("a={0}", a);
            Console.WriteLine("b={0}", b);
            a = a + b; // Now a would be 15   
            b = a - b; // Now b would be 15-5=10 ........   
            a = a - b; // Now a would be 15-10=5........   
            Console.WriteLine("a={0}", a);
            Console.WriteLine("b={0}", b);
        }

        /// <summary>
        /// Swap neighbor char in string, For Example string “TAPAN” would be "ATAPN"
        /// </summary>
        /// <param name="strToSwap"></param>
        /// <returns></returns>
        public static string SwapNeighbourChar(string strToSwap)
        {
            char[] arraStr = strToSwap.ToCharArray();
            StringBuilder strbuild = new StringBuilder();
            for (int i = 0; i <= arraStr.Length - 1; i++)
            {
                if (i != arraStr.Length - 1)
                {
                    strbuild.Append(arraStr[i + 1]);
                }
                strbuild.Append(arraStr[i]);
                i = i + 1;
            }
            return strbuild.ToString();
        }

        /// <summary>
        /// Generate Fibonacci Series
        /// </summary>
        /// <param name="limit"></param>
        public static void FibonacciSeries(int limit)
        {
            int digit1, digit2, digit3;
            digit1 = 0;
            digit2 = 1;
            digit3 = digit1 + digit2;
            Console.WriteLine(digit1);
            Console.WriteLine(digit2);
            Console.WriteLine(digit3);
            for (int i = 0; i < limit; i++)
            {
                digit1 = digit2;
                digit2 = digit3;
                digit3 = digit1 + digit2;
                Console.WriteLine(digit3);
            }
        }

        /// <summary>
        /// Factorial Of Number
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static int FactorialOfNumber(int number)
        {
            // 7*6  
            int result = 1;
            for (int i = number; i > 0; i--)
            {
                result = result * i;
            }
            return result;
        }

        /// <summary>
        /// Preserving the first occurrence and replacing all the others.
        /// </summary>
        /// <param name="str"></param>
        public static void PreserveFirstAndRemoveAll(string str)
        {
            Console.WriteLine("before: {0}", str);

            GroupCollection halves = Regex.Match(str, @"([^$]*\$)(.*)").Groups;
            var answer = halves[1].Value + halves[2].Value.Replace("$", "");

            Console.WriteLine("after: {0}", answer);
        }

        //Reverse a string in C# without changing the position of vowels

        public static string ReverseWithoutChangingVowels(string input)
        {
            HashSet<char> vowels = new HashSet<char> { 'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U' };
            char[] chars = input.ToCharArray();
            List<int> vowelPositions = new List<int>();
            List<char> nonVowels = new List<char>();

            // Collect vowels positions and non-vowel characters
            for (int i = 0; i < chars.Length; i++)
            {
                if (vowels.Contains(chars[i]))
                {
                    vowelPositions.Add(i);
                }
                else
                {
                    nonVowels.Add(chars[i]);
                }
            }

            // Reverse the non-vowel characters
            nonVowels.Reverse();

            // Reconstruct the string
            int nonVowelIndex = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                if (!vowelPositions.Contains(i))
                {
                    chars[i] = nonVowels[nonVowelIndex++];
                }
            }

            return new string(chars);
        }
    }
}
