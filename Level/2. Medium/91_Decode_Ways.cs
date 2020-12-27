public class Solution {
    public int NumDecodings(string s) {
        return Recursive(new Dictionary<int, int>(), s, 0);
    }
    
    private int Recursive(Dictionary<int, int> memo, string s, int index)
    {
        if (index == s.Length)
            return 1;
        if (s[index] == '0')
            return 0;
        if (index == s.Length - 1)
            return 1;
        
        if (memo.ContainsKey(index))
            return memo[index];
        
        int ans = Recursive(memo, s, index + 1);
        
        if (Int32.Parse(s.Substring(index, 2)) < 27)
            ans += Recursive(memo, s, index + 2);
        
        memo.Add(index, ans);
    
        return ans;
    }

    private int Iterative(string s)
    {
        int[] dp = new int[s.Length + 1];
        dp[0] = 1;
        dp[1] = s[0] == '0' ? 0 : 1;
        
        for (int i = 2; i < dp.Length; i++)
        {
            if (s[i - 1] != '0')
                dp[i] += dp[i - 1];
            
            int twoDigits = Int32.Parse(s.Substring(i - 2, 2));
            if (twoDigits > 9 && twoDigits < 27)
                dp[i] += dp[i - 2];
        }
        
        return dp[s.Length];
    }
}