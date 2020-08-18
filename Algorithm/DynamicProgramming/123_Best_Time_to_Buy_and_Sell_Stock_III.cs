public class Solution {
    public int MaxProfit(int[] prices) {
        
    }

    private int StateMachineSolution(int[] prices)
    {
        if (prices.Length == 0) return 0;
        
        int s0 = -prices[0], s1 = Int32.MinValue, s2 = Int32.MinValue, s3 = Int32.MinValue;
        
        for (int i = 1; i < prices.Length; i++)
        {
            //  State 0: Rest or Purchase(less money) 
            //  State 1: Rest or Sell (earn money)
            //  State 2: Rest or Purchase(less money)
            //  State 3: Rest or Sell (earn money)    
                        
            s0 = Math.Max(s0, -prices[i]);
            s1 = Math.Max(s1, s0 + prices[i]);
            s2 = Math.Max(s2, s1 - prices[i]);
            s3 = Math.Max(s3, s2 + prices[i]);
        }
        
        return Math.Max(0, s3);
    }

    private int Solution1(int[] prices)
    {
        int[,] dp = new int[3, prices.Length];
        
        // # of transactions
        for (int k = 1; k < 3; k++)
        {
            // sell stock at i
            for (int i = 1; i < prices.Length; i++)
            {
                int min = prices[0];
                // Find the min purchase stock
                for (int j = 1; j <= i; j++)
                    // prices[j] - Purchase
                    // dp[k - 1, j - 1] - Maximum profit up to j from the previous transaction 
                    min = Math.Min(min, prices[j] - dp[k - 1, j - 1]);
                dp[k, i] = Math.Max(dp[k, i-1], prices[i] - min);
            }
        }
        
        return dp[2, prices.Length - 1];
    }
}