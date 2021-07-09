public class Solution {
    public int FindLength(int[] nums1, int[] nums2) {
        int n = nums1.Length;
        int m = nums2.Length;
        
        int max = 0;
        var dp = new int[n + 1, m + 1];
        
        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j <= m; j++)
            {
                if (nums1[i-1] == nums2[j-1])
                {
                    dp[i,j] = dp[i-1,j-1] + 1;
                    max = Math.Max(max, dp[i,j]);
                }
            }
        }
        
        return max;
    }
}