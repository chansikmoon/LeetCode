public class Solution {
    public int Fib(int n) {
        if (n < 3)
            return n == 0 ? 0 : 1;
        
        int a = 0, b = 1, c = 1;
        
        for (int i = 3; i <= n; i++)
        {
            a = b;
            b = c;
            c += a;
        }
        
        return c;
    }
    
    private int solution1(int n) {
        var dp = new int[31];
        dp[1] = dp[2] = 1;
        
        for (int i = 3; i <= n; i++)
        {
            dp[i] = dp[i-2] + dp[i-1];
        }
        
        return dp[n];
    }
}