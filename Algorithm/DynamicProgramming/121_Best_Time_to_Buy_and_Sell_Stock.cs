public class Solution {
    public int MaxProfit(int[] prices) {
        int max = 0, curr = prices[0];
        
        for (int i = 0; i < prices.Length; i++)
        {
            curr = Math.Min(curr, prices[i]);
            max = Math.Max(max, prices[i] - curr);
        }
        
        return max;
    }
}