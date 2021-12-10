public class Solution {
    public int NumTilings(int n) {
        var dp = new long[1001];
        dp[1] = 1;
        dp[2] = 2;
        dp[3] = 5;
        
        for (int i = 4; i <= n; i++)
        {
            dp[i] = 2*dp[i-1]+dp[i-3];
            dp[i] %= 1000000007;
        }
        
        return (int)dp[n];
    }    
}

/*

[0] = 0
[1] = 1 { | }
[2] = 2 { ||, =}
[3] = 5 { |||, =|, |=, ㄴㄱ, ㄱㄴ}
[4] = [3] + { | }, [2] + { = }, [3] + {ㄴㄱ, ㄱㄴ}, {ㄴ-ㄱ, ㄱ-ㄴ}

dp[n] = dp[n - 1] + dp[n-2] + 2 * (dp[n-3] + ... + dp[0])
dp[n - 1] = dp[n - 2] + dp[n-3] + 2 * (dp[n-4] + ... + dp[0])

dp[n] - dp[n - 1] = dp[n-1] + dp[n-2] + 2(dp[n-3] + ... + dp[0]) - dp[n-2] - dp[n-3] - 2(dp[n-4] + ... + dp[0])
dp[n] = 2 * dp[n-1] + dp[n-3]

 */