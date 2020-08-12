public class Solution {
    public int HIndex(int[] citations) {
        int n = citations.Length;
        
        int[] dp = new int[n + 1];
        
        foreach (int c in citations)
        {
            if (c >= n)
                dp[n]++;
            else
                dp[c]++;
        }
        
        int count = 0;
        
        for (int i = n; i >= 0; i--)
        {
            count += dp[i];
            if (count >= i)
                return i;
        }
        
        return 0;
    }
    
    private int BinarySearch(int[] citations)
    {
        Array.Sort(citations);
        int n = citations.Length, l = 0, r = n - 1;
        
        while (l <= r)
        {
            int m = l + (r - l) / 2;
            
            if (citations[m] == n - m)
                return n - m;
            else if (citations[m] < n - m)
                l = m + 1;
            else
                r = m - 1;
        }
        
        return n - l;
    }
}