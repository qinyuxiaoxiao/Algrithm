using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
        Say you have an array for which theith element is the price of a given stock on day i.
        Design an algorithm to find the maximum profit. You may complete as many transactions as you like (ie, buy one and sell one share of the stock multiple times). 
        However, you may not engage in multiple transactions at the same time (ie, you must sell the stock before you buy again).
    */
    /// <summary>
    /// 关键：只需累加增长的部分
    /// </summary>
    class BestTimeToBuyAndSellStockII
    {
        private static int GetMaximumProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            int profit = 0;
            for(int i = 1; i < prices.Length; i++)
            {
                if (prices[i] > prices[i] - 1)
                {
                    profit += prices[i] - prices[i - 1];
                }
            }

            return profit;
        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine();
        //}
    }
}
