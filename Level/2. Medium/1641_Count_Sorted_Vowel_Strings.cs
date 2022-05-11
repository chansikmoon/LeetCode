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

    // 05/11/22
    // Brute force implementation
    public int CountVowelStrings(int n) {
        var dp = new int[6, n + 1];
        
        for (int i = 1; i <= 5; i++) {
            dp[i, 1] = i; 
        }
        
        for (int j = 1; j <= n; j++) {
            dp[1, j] = 1;    
        }   
        
        for (int i = 2; i <= 5; i++) {
            for (int j = 2; j <= n; j++) {
                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];
            }
        }            
        
        return dp[5, n];
    }
}