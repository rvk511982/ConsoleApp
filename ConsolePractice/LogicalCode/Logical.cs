using System.Collections;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsolePractice
{
    public static class Logical
    {
        /// <summary>
        /// Given an array of ints, write a C# method to total all the values that are even numbers.
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns></returns>
        public static long TotalAllEvenNumbers(int[] intArray)
        {
            return intArray.Where(i => i % 2 == 0).Sum(a => (long)a);
        }

        /// <summary>
        /// Given an array of ints, write a C# method to total all the values that are odd numbers.
        /// </summary>
        /// <param name="intArray"></param>
        /// <returns></returns>
        public static long TotalAllOddNumbers(int[] intArray)
        {
            return (from i in intArray where i % 2 != 0 select (long)i).Sum();
        }

        /// <summary>
        /// Find out number of prime numbers for any given number
        /// </summary>
        /// <param name="inputNumber"></param>
        /// <returns></returns>
        public static string ReturnPrimeNumbers(int inputNumber)
        {
            string primeNumbers = "";
            for (int i = 1; i <= inputNumber; i++)
            {
                if (IsPrime(i))
                {
                    primeNumbers += i.ToString() + ", ";
                }
            }
            return primeNumbers.TrimEnd(',');
        }

        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }

        ///
        public static string ReverseString(string input)
        {
            if (!string.IsNullOrEmpty(input))
            {
                var inputStr = input.ToCharArray();
                Array.Reverse(inputStr);
                return new string(inputStr);
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ReverseStringLinq(string input)
        {
            return new string(input.Reverse().ToArray());
        }

        public static string ReverseStringLoop(string input)
        {
            var output = string.Empty;
            for (int i = input.Length - 1; i >= 0; i--)
            {
                output += input[i];
            }
            return output;
        }

        public static int ReverseNumber(int input)
        {
            int reversedNumber = 0;

            while (input > 0)
            {
                int remainder = input % 10;
                reversedNumber = (reversedNumber * 10) + remainder;
                input = input / 10;
            }
            return reversedNumber;
        }

        public static int FindLargestNumber(int[] array)
        {
            // Initialize the largest number with the first element of the array
            int largest = array[0];

            // Iterate through the array to find the largest number
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > largest)
                {
                    largest = array[i];
                }
            }

            return largest;
        }

        public static string CreateAnagram(string input)
        {
            char[] characters = input.ToCharArray();
            Random rng = new Random();
            int n = characters.Length;

            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                char value = characters[k];
                characters[k] = characters[n];
                characters[n] = value;
            }

            return new string(characters);
        }

        public static int MultiplyWithoutStar(int a, int b)
        {
            int result = 0;
            //for (int i = 0; i < Math.Abs(b); i++)
            //{
            //    result += a;
            //}
            for (int i = 0; i < b; i++)
            {
                result += a;
            }
            // Handle negative numbers
            if (b < 0)
            {
                result = -result;
            }
            return result;
        }

        /// <summary>
        /// finds and returns the first k non-repeating characters from a string
        /// </summary>
        /// <param name="str">Input string</param>
        /// <param name="k">for number of repeat</param>
        /// <returns></returns>
        public static string GetFirstKNonRepeatedChars(string str, int k)
        {
            if (string.IsNullOrEmpty(str) || k <= 0)
            {
                return string.Empty; // Return empty string for invalid input
            }

            if (k > str.Length)
            {
                return str; // Return entire string if k is greater than string length
            }

            // Use a dictionary to store character counts
            var charCounts = new Dictionary<char, int>();
            StringBuilder result = new StringBuilder();

            foreach (char c in str)
            {
                if (charCounts.ContainsKey(c))
                {
                    charCounts[c]++; // Increment count for existing character
                }
                else
                {
                    charCounts.Add(c, 1); // Add new character with count 1
                }

                // Update result string if character count is 1 and result length is less than k
                if (charCounts[c] == 1 && result.Length < k)
                {
                    result.Append(c);
                }
            }

            return result.ToString();
        }

        // Generate factorial using recursion in C#
        public static long Factorial(int n)
        {
            // Base case: factorial of 0 is 1
            if (n <= 1)
            {
                return 1;
            }
            // Recursive call
            return n * Factorial(n - 1);
        }

        public static void GeneratePANCard()
        {
            Random random = new Random();
            StringBuilder pan = new StringBuilder();
            var panNumber = string.Empty;

            // First 5 alphabets (A-Z)
            for (int i = 0; i < 5; i++)
            {
                pan.Append((char)('A' + random.Next(0, 26)));
            }

            // Next 4 digits (0-9)
            for (int i = 0; i < 4; i++)
            {
                pan.Append(random.Next(0, 10));
            }

            // Last alphabet (A-Z)
            pan.Append((char)('A' + random.Next(0, 26)));

            panNumber = pan.ToString();

            Console.WriteLine($"Generated PAN Number: {panNumber}");
        }

        public static void GenerateUniquePANCard()
        {
            // Store generated PANs to avoid duplicates
            var generatedPANs = new HashSet<string>();

            Random random = new Random();
            StringBuilder panBuilder = new StringBuilder();
            var panNumber = string.Empty;
            do
            {
                // First 3 alphabets (A-Z)
                for (int i = 0; i < 3; i++)
                {
                    panBuilder.Append((char)('A' + random.Next(0, 26)));
                }

                // 4th character: Holder type (e.g., 'P' for individual)
                panBuilder.Append('P');

                // 5th alphabet (A-Z)
                panBuilder.Append((char)('A' + random.Next(0, 26)));

                // Next 4 digits (0-9)
                for (int i = 0; i < 4; i++)
                {
                    panBuilder.Append(random.Next(0, 10));
                }

                // Last alphabet (A-Z)
                panBuilder.Append((char)('A' + random.Next(0, 26)));

                panNumber = panBuilder.ToString();
            }
            while (!IsValidPAN(panNumber) || !generatedPANs.Add(panNumber)); // Validate and ensure uniqueness
            Console.WriteLine($"Generated Unique PAN Card Number: {panNumber}");
        }

        static bool IsValidPAN(string pan)
        {
            // PAN format: AAAAA9999A (4th character 'P' for individual)
            string pattern = @"^[A-Z]{3}P[A-Z][0-9]{4}[A-Z]$";
            return Regex.IsMatch(pan, pattern);
        }

        // Return combination of Positive and negative valu in result for given input
        public static void PositiveNegativeValue()
        {
            int[] input = [1, 2, 3, -3, -6, 8, -9];
            var positiveNumbers = new List<int>();
            var negativeNumbers = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] > 0)
                    positiveNumbers.Add(input[i]);
                else
                    negativeNumbers.Add(input[i]);
            }

            var result = new List<int>();
            int maxLength = Math.Max(positiveNumbers.Count, negativeNumbers.Count);
            for (int a = 0; a < maxLength; a++)
            {
                if (a < positiveNumbers.Count)
                    result.Add(positiveNumbers[a]);

                if (a < negativeNumbers.Count)
                    result.Add(negativeNumbers[a]);
            }
            //return result;
            Console.WriteLine("Positive negative Output: " + string.Join(", ", result));
        }

        public static void GetOccuranceOfWordsFromSentence(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                Console.WriteLine("Empty");// string.Empty; // Return empty string for invalid input
            }

            // Use a dictionary to store word counts
            var wordCounts = new Dictionary<string, int>();
            StringBuilder result = new StringBuilder();
            string[] words = str.Split(' ');

            foreach (var word in words)
            {
                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++; // Increment count for existing word
                }
                else
                {
                    wordCounts.Add(word, 1); // Add new character with count 1
                }
            }

            // print the word count and their occurance
            foreach (var item in wordCounts)
            {
                Console.WriteLine("Word: {0} Count: {1}", item.Key, item.Value);
            }

        }
    }

    public abstract class AbstractClass
    {
        static AbstractClass()
        {
            Console.WriteLine("Abstract Static Constructor");
        }
        public AbstractClass()
        {
            Console.WriteLine("Abstract Default Constructor");
        }
        public void ConcreteMethod()
        {
            Console.WriteLine("Abstract Concrete Method");
        }
        protected abstract void AbstractMethod();
    }

    public class ConcreteClass : AbstractClass
    {
        static ConcreteClass()
        {
            Console.WriteLine("Concrete Static Constructor");
        }
        public ConcreteClass()
        {
            Console.WriteLine("Concrete Default Constructor");
        }
        protected override void AbstractMethod()
        {
            Console.WriteLine("Concrete Abstract Method");
        }
        public void ConcreteMethod()
        {
            Console.WriteLine("Concrete Class Concrete Method");
        }
    }
}
