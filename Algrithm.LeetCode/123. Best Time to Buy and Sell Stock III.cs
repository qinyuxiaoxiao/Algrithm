using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
        Say you have an array for which the ith element is the price of a given stock on day i.
        Design an algorithm to find the maximum profit. You may complete at most two transactions.

        Note:
        You may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
    */
    /// <summary>
    /// 关键：只需累加增长的部分
    /// </summary>
    class BestTimeToBuyAndSellStockIII
    {
        private static int GetMaximumProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            int maxProfit1 = 0;
            int maxProfit2 = 0;
            int profit = 0;
            for(int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i] - 1)
                {
                    profit += prices[i] - prices[i - 1];
                }
                else
                {
                    if (profit > maxProfit1)
                    {
                        maxProfit1 = profit;
                        maxProfit2 = Math.Max(maxProfit1, maxProfit2);
                    }
                    else if (profit > maxProfit2)
                    {
                        maxProfit2 = profit;
                    }

                    profit = 0;
                }
            }

            return maxProfit1 + maxProfit2;
        }

        static void Main(string[] args)
        {
            Console.WriteLine();
        }
    }
}
