using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsolePractice.Codility
{
    public static class MaxIncomeCalculator
    {
        public static void IncomeCalculator(int[] A)
        {
            int incomeCal = 0;

            int n = A.Length;
            long maxProfit = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = i; j < n; j++)
                {
                    long currentProfit = 0;
                    int buyIndex = -1;
                    for (int k = i; k <= j; k++)
                    {
                        if (buyIndex == -1 || A[k] < A[buyIndex])
                        {
                            buyIndex = k;
                        }
                        if (k > buyIndex)
                        {
                            currentProfit += A[k] - A[buyIndex];
                            buyIndex = -1; // Reset buy index after sell
                        }
                    }
                    maxProfit = Math.Max(maxProfit, currentProfit);

                }
            }

            incomeCal = (int)(maxProfit % 1000000000);

            //incomeCal = (int)(maxIncome % 1000000000);
            Console.WriteLine("Max Income ==>> " + incomeCal);
        }

        public static void SolutionOptimized(int[] A)
        {
            int incomeCal = 0;
            long maxIncome = 0;
            int n = A.Length;
            bool hasAsset = false;
            int buyPrice = 0;

            for (int i = 0; i < n; i++)
            {
                if (!hasAsset)
                {
                    // If we don't have an asset, we decide to buy if next price is higher
                    if (i < n - 1 && A[i] < A[i + 1])
                    {
                        buyPrice = A[i];
                        hasAsset = true;
                    }
                }
                else
                {
                    // If we have an asset, we decide to sell if next price is lower or it's the last day
                    if (i == n - 1 || A[i] > A[i + 1])
                    {
                        maxIncome += A[i] - buyPrice;
                        hasAsset = false;
                    }
                }
            }

            //return (int)(maxIncome % 1000000000);


            incomeCal = (int)(maxIncome % 1000000000);

            Console.WriteLine($"Max Income output {incomeCal} ");
        }

        public static void MaxProfit__SD(int[] A)
        {
            const int mod = 1000000000;  // Define modulo constant
            int incomeCal = 0;
            long maxIncome = 0;
            int n = A.Length;

            bool hasAsset = false;
            int buyPrice = 0;

            //for (int i = 0; i < n; i++)
            //{
            //    if (!hasAsset && (i == n - 1 || A[i] > A[i + 1]))
            //    {
            //        maxIncome += A[i]; // Sell
            //    }
            //    else if (hasAsset && (i == n - 1 || A[i] > A[i + 1]))
            //    {
            //        maxIncome += A[i] - buyPrice; // Sell with profit
            //        hasAsset = false;
            //    }
            //    else if (!hasAsset && (i < n - 1 && A[i] < A[i + 1]))
            //    {
            //        buyPrice = A[i]; // Buy
            //        hasAsset = true;
            //    }
            //}

            for (int i = 0; i < n; i++)
            {
                if (hasAsset && (i == n - 1 || A[i] > A[i + 1]))
                {
                    maxIncome += A[i] - buyPrice; // Sell with profit
                    hasAsset = false;
                }
                else if (!hasAsset && (i < n - 1 && A[i] < A[i + 1]))
                {
                    buyPrice = A[i]; // Buy
                    hasAsset = true;
                }
            }

            incomeCal = (int)(maxIncome % mod);

            Console.WriteLine($"MaxProfit output {incomeCal} ");
        }

        public static void MaxProfit(int[] arr)
        {
            // Define modulo constant
            const int mod = 1000000000;  
            int maxProfit = 0;

            HashSet<long> maxProfits = new HashSet<long>();
            bool[] selling = { true };

            long Sell(long a, long b = 0)
            {
                selling[0] = false;
                return a + b;
            }

            long Buy(long a, long b = 0)
            {
                selling[0] = true;
                return a - b;
            }

            void CalculateProfit(long profit, int i)
            {
                if (profit < 0)
                {
                    return;
                }
                if (i >= arr.Length)
                {
                    maxProfits.Add(profit);
                    return;
                }

                if (selling[0])
                {
                    CalculateProfit(Sell(profit, arr[i]), i + 1);
                    CalculateProfit(Buy(profit), i + 1);
                }
                else
                {
                    CalculateProfit(Buy(profit, arr[i]), i + 1);
                    CalculateProfit(Sell(profit), i + 1);
                }
            }

            CalculateProfit(0, 0);
            maxProfit = (int)(maxProfits.Max() % mod);
            Console.WriteLine($"MaxProfit output {maxProfit} ");
        }

        private static long CalculateRemainingProfit(int[] A, int startIndex)
        {
            int n = A.Length;
            long remainingProfit = 0;

            for (int i = startIndex; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (A[j] > A[i])
                    {
                        long currentProfit = A[j] - A[i];
                        long nextRemainingProfit = CalculateRemainingProfit(A, j + 1);
                        remainingProfit = Math.Max(remainingProfit, currentProfit + nextRemainingProfit);
                    }
                }
            }
            return remainingProfit;
        }
    }
}
