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
    /// 关键：理解题意，第二次买入再卖出总是建立在第一次买入再卖出之后，顺着该思路来设计。
    /// 参考答案的方法很巧妙，理解起来比较困难。最好画一个真实的价格走势图，按照其算法算出每一步的变量值，从而理解其算法逻辑
    /// 
    /// 把两次买入再卖出的先后操作细拆分为4个顺序发生的操作，用4个变量记录每步操作后的收益：
    /// 
    ///     profit1Buy      第1次买入(没有卖出)时的收益
    ///     profit1Sell     第1次卖出时的收益
    ///     profit2Buy      第2次买入(没有卖出)时的收益
    ///     profit2Sell     第2次卖出时的收益
    ///     
    /// 注意：计算的顺是自后向前计算，即按照profit2Sell， profit2Buy， profit1Sell， profit1Buy的顺序来计算
    ///     
    /// </summary>
    class BestTimeToBuyAndSellStockIII
    {
        private static int GetMaximumProfit(int[] prices)
        {
            if (prices == null || prices.Length <= 1) return 0;
            int profit1Buy = int.MinValue;
            int profit1Sell = 0;
            int profit2Buy = int.MinValue;
            int profit2Sell = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                // 注意：计算的顺是自后向前计算，即按照profit2Sell， profit2Buy， profit1Sell， profit1Buy的顺序来计算
                profit2Sell = Math.Max(profit2Sell, profit2Buy + prices[i]);
                profit2Buy = Math.Max(profit2Buy, profit1Sell - prices[i]);
                profit1Sell = Math.Max(profit1Sell, profit1Buy + prices[i]);
                profit1Buy = Math.Max(profit1Buy, -prices[i]);
            }

            // 取最大值是因为可能操作1次取得最大收益
            return Math.Max(profit2Sell, profit1Sell);
        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine();
        //}
    }
}
