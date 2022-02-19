public class Solution {
    public int MinimumDeviation(int[] nums) {
        var pq = new SortedSet<int>();
        foreach (int n in nums) {
            pq.Add(n % 2 == 1 ? n * 2 : n);
        }
        
        int ret = pq.Max - pq.Min;
        
        while (pq.Max % 2 == 0) {
            int max = pq.Max;
            pq.Remove(max);
            pq.Add(max / 2);
            
            ret = Math.Min(ret, pq.Max - pq.Min);
        }
        
        return ret;
    }
}