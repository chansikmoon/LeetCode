public class Solution {
    public int MaxProfit(int k, int[] prices) {
        if (prices.Length == 0 || k == 0) return 0;
        if (k >= prices.Length / 2)
        {
            int ret = 0;
            for (int i = 1; i < prices.Length; i++)
                ret += Math.Max(0, prices[i] - prices[i - 1]);
            
            return ret;
        }
        
        int[] buy = new int[k + 1], sell = new int[k + 1];
        
        for (int i = 0; i <= k; i++)
            buy[i] = Int32.MinValue;
        
        for (int i = 0; i < prices.Length; i++)
        {
            for (int j = 1; j <= k; j++)
            {
                buy[j] = Math.Max(buy[j], sell[j-1] - prices[i]);
                sell[j] = Math.Max(sell[j], buy[j] + prices[i]);
            }
        }
        
        return sell[k];
    }
}