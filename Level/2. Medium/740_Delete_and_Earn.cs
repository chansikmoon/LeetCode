public class Solution {
    public int DeleteAndEarn(int[] nums) {
        var arr = new int[10001];
        foreach (int num in nums) {
            arr[num] += num;
        }
        
        var dp = new int[10001];
        dp[0] = arr[0];
        dp[1] = arr[1];
        
        for (int i = 2; i < 10001; i++) {
            dp[i] = Math.Max(arr[i] + dp[i - 2], dp[i - 1]);
        }
        
        return dp[10000];
    }
}