public class Solution {
    public int EliminateMaximum(int[] dist, int[] speed) {
        var pq = new SortedSet<(double d, int idx)>();
        
        for (int i = 0; i < dist.Length; i++)
            pq.Add(((double)dist[i] / (double)speed[i], i));
        
        int ret = 0;
        double minute = 0;
        
        while (pq.Count > 0)
        {
            var min = pq.Min;
            pq.Remove(pq.Min);
            
            if (min.d <= minute)
                return ret;
            
            ret++;
            minute += 1;
        }
        
        return ret;
    }
}