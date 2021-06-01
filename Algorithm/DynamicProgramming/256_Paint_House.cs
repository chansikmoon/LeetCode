public class Solution {
    public int MinCost(int[][] costs) {
        int n = costs.Length;
        
        for (int i = 1; i < n; i++)
        {
            costs[i][0] += Math.Min(costs[i-1][1], costs[i-1][2]);
            costs[i][1] += Math.Min(costs[i-1][0], costs[i-1][2]);
            costs[i][2] += Math.Min(costs[i-1][0], costs[i-1][1]);
        }
        
        return Math.Min(costs[n-1][0], Math.Min(costs[n-1][1], costs[n-1][2]));
    }
}