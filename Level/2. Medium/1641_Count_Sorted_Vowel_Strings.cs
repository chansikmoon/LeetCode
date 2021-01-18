public class Solution {
    public int CountVowelStrings(int n) {
        var dp = new int[] {0,1,1,1,1,1};
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 1; j < 6; j++)
            {
                dp[j] += dp[j-1];
            }
        }
        
        return dp[5];
    }
}