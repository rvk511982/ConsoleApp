using System.Text.RegularExpressions;

namespace ConsolePractice.Test
{
    public static class MyTest
    {
        //        You are given an array of strings numbers and an integer k.Each string in numbers represents an integer without leading zeros.
        //        Return the string that represents the kth largest integer in nums.

        //Note: Duplicate numbers should be counted distinctly. For example, if numbers is ["1", "2", "2"], "2" is the first largest integer, "2" is the second-largest integer, and "1" is the third-largest integer.


        //Example 1:


        //Input: nums = ["3", "6", "7", "10"], k = 4
        //Output: "3"
        //Explanation:
        //The numbers in nums sorted in non-decreasing order are["3", "6", "7", "10"].
        //The 4th largest integer in nums is "3".
        //Example 2:


        //Input: nums = ["2", "21", "12", "1"], k = 3
        //Output: "2"
        //Explanation:
        //The numbers in nums sorted in non-decreasing order are["1", "2", "12", "21"].
        //The 3rd largest integer in nums is "2".
        //Example 3:


        //Input: nums = ["0", "0"], k = 2
        //Output: "0"
        //Explanation:
        //The numbers in nums sorted in non-decreasing order are["0", "0"].
        //The 2nd largest integer in nums is "0".

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static string KthLargestNumber()
        {
            var result = string.Empty;
            try
            {
                string[] input = { "0", "0" };
                int k = 2;

                var sortedNumbers = input.OrderByDescending(a => a.Length).ThenByDescending(a => a).ToList();
                if (sortedNumbers.Count > k)
                    result = sortedNumbers[k - 1];
                else
                    result = sortedNumbers[sortedNumbers.Count - 1];

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// Extracts the maximum numeric value from an alphanumeric string
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Return the max value</returns>
        public static int ExtractMaxNumericValue(string input)
        {
            // Use regular expression to find all numeric values in the string
            var matches = Regex.Matches(input, @"\d+");

            int max = int.MinValue;

            // Iterate through all matches and find the maximum value
            foreach (Match match in matches)
            {
                int value = int.Parse(match.Value);
                if (value > max)
                {
                    max = value;
                }
            }

            return max;
        }

        public static int ExtractMaxNumericValue_LINQ(string input)
        {
            return Regex.Matches(input, @"\d+")
                        .Cast<Match>()
                        .Select(m => int.Parse(m.Value))
                        .DefaultIfEmpty(int.MinValue)
                        .Max();
        }

        public static int ExtractMaxNumericValue_Span(string input)
        {
            ReadOnlySpan<char> span = input.AsSpan();
            int max = int.MinValue;
            int currentNumber = 0;
            bool hasNumber = false;

            foreach (char c in span)
            {
                if (char.IsDigit(c))
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                    hasNumber = true;
                }
                else if (hasNumber)
                {
                    max = Math.Max(max, currentNumber);
                    currentNumber = 0;
                    hasNumber = false;
                }
            }

            if (hasNumber) max = Math.Max(max, currentNumber);
            return max;
        }

        public static int ExtractMaxNumericValue_Char(string input)
        {
            int max = int.MinValue;
            int currentNumber = 0;
            bool hasNumber = false;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    currentNumber = currentNumber * 10 + (c - '0');
                    hasNumber = true;
                }
                else if (hasNumber)
                {
                    max = Math.Max(max, currentNumber);
                    currentNumber = 0;
                    hasNumber = false;
                }
            }

            if (hasNumber) max = Math.Max(max, currentNumber);
            return max;
        }

        public static void SortStringInDescendingOrder(string input)
        {
            try
            {
                Console.WriteLine("======== SortStringInDescendingOrder using ToArray ========");
                var sortedString = new string(input.OrderByDescending(c => c).ToArray());
                Console.WriteLine($"Sorted string in descending order: {sortedString}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SortStringInDescendingOrder_ArraySort(string input)
        {
            try
            {
                Console.WriteLine("======== SortStringInDescendingOrder Using Array.Sort with Custom Comparer ========");
                char[] charArray = input.ToCharArray();
                Array.Sort(charArray, (a, b) => b.CompareTo(a)); // Sort in descending order
                string sortedString = new string(charArray);
                Console.WriteLine($"Sorted string in descending order Using Array.Sort with Custom Comparer: {sortedString}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SortStringInDescendingOrder_ListSort(string input)
        {
            try
            {
                Console.WriteLine("======== SortStringInDescendingOrder Using List<T>.Sort ========");
                List<char> charList = new List<char>(input);
                charList.Sort((a, b) => b.CompareTo(a)); // Sort in descending order
                string sortedString = new string(charList.ToArray());
                Console.WriteLine($"Sorted string in descending order Using List<T>.Sort: {sortedString}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SortStringInDescendingOrder_Span(string input)
        {
            try
            {
                Console.WriteLine("======== SortStringInDescendingOrder Using Span<T> for High Performance (C# 8+) ========");
                Span<char> span = stackalloc char[input.Length]; // Avoid heap allocation
                input.AsSpan().CopyTo(span);
                span.Sort((a, b) => b.CompareTo(a)); // Sort in descending order
                string sortedString = new string(span);
                Console.WriteLine($"Sorted string in descending order Using Span<T> for High Performance (C# 8+): {sortedString}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void SortStringInDescendingOrder_BubbleSort(string input)
        {
            Console.WriteLine("======== SortStringInDescendingOrder Using Manual Bubble Sort (For Learning Purposes) ========");
            try
            {
                char[] charArray = input.ToCharArray();
                int n = charArray.Length;
                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (charArray[j] < charArray[j + 1])
                        {
                            // Swap characters
                            char temp = charArray[j];
                            charArray[j] = charArray[j + 1];
                            charArray[j + 1] = temp;
                        }
                    }
                }
                string sortedString = new string(charArray);
                Console.WriteLine($"Sorted string in descending order Using Manual Bubble Sort (For Learning Purposes): {sortedString}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public static void LexicoGraphicalOrder()
        {
            string[] words = { "apple", "banana", "cherry" };
            foreach (var item in words)
            {
                var sortedWords = item.OrderByDescending(word => word).ToArray();
                Console.WriteLine("Words in lexicographical order:");
                Console.WriteLine(sortedWords);
            }
        }

        public static void SmallestPositiveInteger()
        {
            int[] A = [-1, -3];
            HashSet<int> numbers = new HashSet<int>();
            foreach (int num in A)
            {
                if (num > 0)
                {
                    numbers.Add(num);
                }
            }

            int smallPositiveNumber = 1;
            while (numbers.Contains(smallPositiveNumber))
            {
                smallPositiveNumber++;
            }
            Console.WriteLine(smallPositiveNumber);
        }

        public static void MinimumNumberOfDistinctLetters(string P, string Q)
        {
            Console.WriteLine($"First input {P}, second input {Q}");
            // Return 0 if any of the given input is null
            if (string.IsNullOrEmpty(P) || string.IsNullOrEmpty(Q))
            {
                Console.WriteLine($"number of distinct letters is {0} ");
            }

            // Used a hashset for storing distinct letter
            HashSet<char> distinctChar = new HashSet<char>();
            int n = P.Length;

            // Iterate over P & Q to find distinct letter
            for (int i = 0; i < n; i++)
            {
                // Add the minimum of the characters to identify distinct letters
                distinctChar.Add(P[i]);
                distinctChar.Add(Q[i]);
            }

            int minDistinct = int.MaxValue;
            // Iterating over 2 loops c1 and c2 to find best two characters 
            // that can be minimize the number of distinct letter
            for (char c1 = 'a'; c1 <= 'z'; c1++)
            {
                for (char c2 = 'a'; c2 <= 'z'; c2++)
                {
                    // Hashset to hold the letter after comparing from iteration
                    HashSet<char> tempLetters = new HashSet<char>();
                    for (int i = 0; i < n; i++)
                    {
                        if (P[i] == c1 || Q[i] == c1)
                            tempLetters.Add(c1);
                        else if (P[i] == c2 || Q[i] == c2)
                            tempLetters.Add(c2);
                        else
                            tempLetters.Add(P[i]);
                    }

                    // Taking Math.Min help to find Minimum distinct count
                    minDistinct = Math.Min(minDistinct, tempLetters.Count);
                }
            }

            // return the count of distinct letters
            Console.WriteLine("number of distinct letters is ==>> " + minDistinct);
        }
    }

    public class DocumentVersioning
    {
        private Stack<string> history;

        public DocumentVersioning()
        {
            history = new Stack<string>();
            history.Push(""); // Initial empty document state
        }

        public void ProcessOperations(string[] operations)
        {
            foreach (var operation in operations)
            {
                Console.WriteLine("Process Operations Being Performed On : " + operation);
                var parts = operation.Split(new[] { ' ' }, 2);
                var command = parts[0];

                if (command == "WRITE")
                {
                    var newText = parts[1];
                    var currentState = history.Peek() + newText;
                    history.Push(currentState);
                }
                else if (command == "UNDO")
                {
                    if (history.Count > 1)
                    {
                        history.Pop();
                    }
                }
            }
            GetFinalState();
        }

        private void GetFinalState()
        {
            Console.WriteLine(history.Peek());
        }
    }

    //public class Program
    //{
    //    public static void Main()
    //    {
    //        var operations = new[] { "WRITE Hello", "WRITE World", "UNDO" };
    //        var documentVersioning = new DocumentVersioning();
    //        documentVersioning.ProcessOperations(operations);
    //        Console.WriteLine(documentVersioning.GetFinalState()); // Output: Hello
    //    }
    //}
}
