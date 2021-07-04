public class Solution {
    public int CountVowelPermutation(int n) {
        if (n == 1)
            return 5;
        
        var dp = new int[5] {1, 1, 1, 1, 1};
        int MOD = 1000000007;
        
        for (int i = 1; i < n; i++)
        {
            var tmp = new int[5];
            
            for (int j = 0; j < 5; j++)
            {
                if (j == 0)
                    tmp[1] = (tmp[1] + dp[j]) % MOD;
                else if (j == 1)
                {
                    tmp[0] = (tmp[0] + dp[j]) % MOD;
                    tmp[2] = (tmp[2] + dp[j]) % MOD;
                }
                else if (j == 2)
                {
                    tmp[0] = (tmp[0] + dp[j]) % MOD;
                    tmp[1] = (tmp[1] + dp[j]) % MOD;
                    tmp[3] = (tmp[3] + dp[j]) % MOD;
                    tmp[4] = (tmp[4] + dp[j]) % MOD;
                }
                else if (j == 3)
                {
                    tmp[2] = (tmp[2] + dp[j]) % MOD;
                    tmp[4] = (tmp[4] + dp[j]) % MOD;
                }
                else if (j == 4)
                    tmp[0] = (tmp[0] + dp[j]) % MOD;
            }
            
            dp = tmp;
        }
        
        int ret = 0;
        
        for (int i = 0; i < 5; i++)
            ret = (ret + dp[i]) % MOD;
        
        return ret;
    }
}