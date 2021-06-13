public class Solution {
    public int MinRefuelStops(int target, int tank, int[][] stations) {
        var pq = new SortedSet<(int fuel, int idx)>();
        int ret = 0, i;
        
        for (i = 0; tank < target; ret++)
        {
            // Let's try to go to the farthest station with current tank
            while (i < stations.Length && tank >= stations[i][0])
                pq.Add((stations[i][1], i++));
            
            // If we can't refuel anymore and not reached, then return.
            if (pq.Count == 0)
                return -1;
            
            // refill from the highest fuel available.
            tank += pq.Max.fuel;
            pq.Remove(pq.Max);
        }
        
        return ret;
    }

    public int DP(int target, int tank, int[][] stations) {
        var dp = new long[stations.Length + 1];
        dp[0] = startFuel;
        
        for (int i = 0; i < stations.Length; i++)
        {
            for (int j = i; j >= 0 && dp[j] >= stations[i][0]; j--)
            {
                dp[j + 1] = Math.Max(dp[j + 1], dp[j] + (long)stations[i][1]);
            }
        }
            
        for (int i = 0; i < dp.Length; i++)
        {
            if (dp[i] >= target)
                return i;
        }
        
        return -1;
    }
}