using ConsolePractice.Indexers;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
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

        public static string KthLargestNumber()
        {
            var result = string.Empty;
            try
            {
                string[] input = { "0", "0" };
                int k = 2;

                var sortedNumbers = input.OrderByDescending(a => a.Length).ThenByDescending(a => a).ToList();
                if (sortedNumbers.Count > k)
                    result = sortedNumbers[k-1];
                else
                    result = sortedNumbers[sortedNumbers.Count - 1];
            
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return result;  
        }
    }
}
