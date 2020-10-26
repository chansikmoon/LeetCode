public class Solution {
    // O(n^1.5)
    // O(n)
    public bool WinnerSquareGame(int n) {
        bool[] dp = new bool[n + 1];
        
        // O(n)
        for (int i = 1; i <= n; i++)
        {
            // O(sqrt(n))
            for (int k = 1; k * k <= i; k++)
            {
                // if dp[i - k * k] is false, then dp[i] should be true
                // if dp[i - k * k] is true, then Alice loses then game at ith turn.
                // Ex) dp[1 - (1)] == false, then dp[1] = true
                if (!dp[i - k * k])
                {
                    dp[i] = true;
                    break;
                }
            }
        }
        
        return dp[n];
    }
}