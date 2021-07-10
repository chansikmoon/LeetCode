public class Solution {
    public int FindLongestChain(int[][] pairs) {
        Array.Sort(pairs, (a, b) => 
                   {
                       var res = a[0].CompareTo(b[0]);
                       return res == 0 ? a[1].CompareTo(b[1]) : res;
                   });
        
        int n = pairs.Length, max = 1;
        var dp = new int[n];
        dp[0] = 1;
        
        for (int j = 1; j < n; j++)
        {
            int currMax = 0;
            
            for (int i = 0; i < j; i++)
            {
                if (pairs[i][1] < pairs[j][0])
                    currMax = Math.Max(currMax, dp[i]);
            }
            
            dp[j] = currMax + 1;
            max = Math.Max(max, dp[j]);
        }
        
        return max;
    }

    public int Greedy(int[][] pairs) {
        Array.Sort(pairs, (a, b) => a[1].CompareTo(b[1]));
        
        int i = 0, max = 0, n = pairs.Length;
        
        while (i < n)
        {
            max++;
            int currEnd = pairs[i][1];
            
            while (i < n && pairs[i][0] <= currEnd)
                i++;
        }
        
        return max;
    }
}