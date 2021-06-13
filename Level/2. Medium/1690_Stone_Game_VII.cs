public class Solution {
    public int StoneGameVII(int[] stones) {
        int n = stones.Length;
        var preSum = new int[n + 1];
        var dp = new int[n, n];
        
        for (int i = 1; i <= n; i++)
            preSum[i] = preSum[i - 1] + stones[i - 1];
        
        for (int length = 1; length < n; length++)
        {
            for (int start = 0; start + length < n; start++)
            {
                int end = start + length;
                
                int removeFirst = preSum[end + 1] - preSum[start + 1];
                int removeLast = preSum[end] - preSum[start];
                
                dp[start, end] = Math.Max(removeFirst - dp[start + 1, end],
                                         removeLast - dp[start, end - 1]);
            }
        }
        
        return dp[0, n - 1];
    }
}