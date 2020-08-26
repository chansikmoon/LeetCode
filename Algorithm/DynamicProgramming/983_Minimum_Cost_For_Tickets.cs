public class Solution {
    // Time Complexity: O(n)
    // Space Complexity: O(n)
    public int MincostTickets(int[] days, int[] costs) {
        Queue<int[]> q7 = new Queue<int[]>(), q30 = new Queue<int[]>();
        int ret = 0;
        foreach (int day in days)
        {
            while (q7.Count > 0 && q7.Peek()[1] <= day) q7.Dequeue();
            while (q30.Count > 0 && q30.Peek()[1] <= day) q30.Dequeue();
            q7.Enqueue(new int[]{ret + costs[1], day + 7});
            q30.Enqueue(new int[]{ret + costs[2], day + 30});
            
            ret = Math.Min(ret + costs[0], Math.Min(q7.Peek()[0], q30.Peek()[0]));
        }
        
        return ret;
    }

    // Time Complexity: O(365)
    // Space Complexity: O(365)
    private int Solution1(int[] days, int[] costs)
    {
        HashSet<int> daysSet = days.ToHashSet();
        int[] dp = new int[366];
        
        for (int i = 1; i < 366; i++)
        {
            if (daysSet.Contains(i))
                dp[i] = Math.Min(dp[i-1] + costs[0], Math.Min(dp[Math.Max(0, i - 7)] + costs[1], 
                                                              dp[Math.Max(0, i - 30)] + costs[2]));
            
            else
                dp[i] = dp[i - 1];
        }
        
        return dp[365];
    }
}