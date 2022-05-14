public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k) {
        var grid = new int[n + 1, n + 1];
        var cost = new int[n + 1];
        
        for (int i = 0; i <= n; i++) {
            cost[i] = Int32.MaxValue;
            for (int j = 0; j <= n; j++) {
                grid[i,j] = Int32.MaxValue;    
            }
        }
        
        foreach (var time in times) {
            int x = time[0];
            int y = time[1];
            int z = time[2];
            
            grid[x, y] = z;
        }
        
        var q = new Queue<int>();
        q.Enqueue(k);
        cost[0] = 0;
        cost[k] = 0;    
        
        while (q.Count > 0) {
            int x = q.Dequeue();
            
            for (int y = 1; y <= n; y++) {
                if (grid[x, y] != Int32.MaxValue) {
                    int newZ = grid[x, y] + cost[x]; 
                    
                    if (newZ < cost[y]) {
                        cost[y] = newZ;
                        q.Enqueue(y);
                    }
                }
            }
        }
        
        int ret = Int32.MinValue;
        
        foreach(int i in cost)
        {
            if (i == Int32.MaxValue)
                return -1;
            
            ret = Math.Max(ret, i);
        }
        
        return ret;
    }
}