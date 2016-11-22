using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algrithm.LeetCode
{
    /*
        Say you have an array for which the ith element is the price of a given stock on day i.
        If you were only permitted to complete at most one transaction (ie, buy one and sell one share of the stock), 
        design an algorithm to find the maximum profit.
    */
    /// <summary>
    /// 关键：从左向右，记录最低点，同时计算最大利益
    /// </summary>
    class BestTimeToBuyAndSellStockI
    {
        private static int GetMaximumProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;

            int maxProfit = 0;
            int minPrice = prices[0];
            for(int i = 1; i < prices.Length; i++)
            {                
                if (prices[i] > prices[i] - 1)
                {
                    maxProfit = Math.Max(maxProfit, prices[i] - minPrice);
                }

                minPrice = Math.Min(minPrice, prices[i]);
            }

            return maxProfit;
        }

        //static void Main(string[] args)
        //{
        //    int[] prices = new int[] { 1, 5, 6, 7, 9, 12, 5, 2, 1, 7, 13, 2, 1, 9, 11 };
        //    int maxProfit = GetMaximumProfit(prices);
        //    Console.WriteLine("Max profit is: " + maxProfit);
        //}
    }
}
