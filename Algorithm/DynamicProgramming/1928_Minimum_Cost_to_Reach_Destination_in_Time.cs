public class Solution {
    public int MinCost(int maxTime, int[][] edges, int[] passingFees) {
        int n = passingFees.Length;
        var adjList = new List<(int dest, int time)>[n];
        var dp = new int[maxTime + 1, n];
        
        for (int i = 0; i <= maxTime; i++)
            for (int j = 0; j < n; j++)
                dp[i,j] = Int32.MaxValue;
        
        for (int i = 0; i < n; i++)
            adjList[i] = new List<(int dest, int time)>();
        
        for (int i = 0; i < edges.Length; i++)
        {
            int u = edges[i][0];
            int v = edges[i][1];
            int t = edges[i][2];
            
            adjList[u].Add((v, t));
            adjList[v].Add((u, t));
        }
        
        dp[0, 0] = passingFees[0];
        int ret = Int32.MaxValue;
        
        for (int currTime = 0; currTime <= maxTime; currTime++)
        {
            for (int frm = 0; frm < n; frm++)
            {
                int currCost = dp[currTime, frm];
                
                if (currCost == Int32.MaxValue)
                    continue;
                
                for (int i = 0; i < adjList[frm].Count; i++)
                {
                    var next = adjList[frm][i];
                    int dest = next.dest;
                    int time = next.time;
                    
                    int nextTime = time + currTime;
                    
                    if (nextTime <= maxTime)
                    {
                        dp[nextTime, dest] = Math.Min(dp[nextTime, dest], currCost + passingFees[dest]);
                        
                        if (dest == n - 1)
                            ret = Math.Min(ret, dp[nextTime, dest]);
                    }
                }
            }
        }
        
        return ret == Int32.MaxValue ? -1 : ret;
    }
}