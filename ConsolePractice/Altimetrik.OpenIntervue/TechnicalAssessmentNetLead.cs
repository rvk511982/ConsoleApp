using Microsoft.Azure.Cosmos.Core.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Altimetrik.OpenIntervue
{
    public static class TechnicalAssessmentNetLead
    {
        /// <summary>
        /// Sorts an array of integers in non-decreasing order and counts the occurrences of each unique integer.
        /// </summary>
        /// <param name="arr">An array of integers that may contain duplicates.</param>
        /// <returns>A string representing the sorted array followed by counts of each unique integer in the format 'number: count'.
        /// If the input array is empty, returns an empty string.</returns>
        public static void SortAndCountDuplicates(int[] arr)
        {
            if (arr.Length == 0)
                return;

            // Print original array
            Console.WriteLine("Input detail:");
            Console.WriteLine(arr.Length);
            Console.WriteLine(string.Join(" ", arr));

            // Sort array
            Array.Sort(arr);

            Console.WriteLine("Output detail:");
            // Print sorted array
            Console.WriteLine(string.Join(" ", arr));

            // Count duplicates
            Dictionary<int, int> counts = new Dictionary<int, int>();

            foreach (int num in arr)
            {
                if (counts.ContainsKey(num))
                    counts[num]++;
                else
                    counts[num] = 1;
            }

            // Print counts in sorted key order
            foreach (var kv in counts.OrderBy(k => k.Key))
            {
                Console.WriteLine($"{kv.Key}: {kv.Value}");
            }
        }

        /// <summary> 
        /// Sorts the array in non-decreasing order and returns both the sorted array 
        /// and a dictionary of counts for each unique integer. 
        /// </summary> 
        public static (int[] SortedArray, Dictionary<int, int> Counts) Process(int[] arr)
        {
            if (arr == null || arr.Length == 0)
            {
                return (Array.Empty<int>(), new Dictionary<int, int>());
            }
            // Sort the array
            Array.Sort(arr);
            // Count occurrences
            var counts = new Dictionary<int, int>();
            foreach (var num in arr)
            {
                if (counts.ContainsKey(num))
                    counts[num]++;
                else counts[num] = 1;
            }
            return (arr, counts);
        }

        /// <summary> 
        /// Utility method to print results in the required format. 
        /// </summary> 
        public static void PrintResult((int[] SortedArray, Dictionary<int, int> Counts) result)
        {
            if (result.SortedArray.Length == 0)
            {
                return;
            }
            // Print sorted array
            Console.WriteLine(string.Join(" ", result.SortedArray));
            // Print counts
            foreach (var kvp in result.Counts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
        }
    }

    //public class TechnicalAssessmentNetLeadTests
    //{
    //    public static void RunTests()
    //    {
    //        var testCases = new List<int[]>
    //        {
    //            new int[] { 4, 2, 2, 8, 3, 3, 1 },
    //            new int[] { },
    //            new int[] { 5, 5, 5, 5 },
    //            new int[] { 1, 2, 3, 4, 5 },
    //            new int[] { 10, -1, 2, -1, 10 }
    //        };
    //        foreach (var testCase in testCases)
    //        {
    //            Console.WriteLine("===================================");
    //            TechnicalAssessmentNetLead.SortAndCountDuplicates(testCase);
    //            Console.WriteLine("===================================");
    //        }
    //    }
    //}
}
    