public class Solution {
    public int MaxPerformance(int n, int[] speed, int[] efficiency, int k) {
        var arr = new Tuple<int, int>[n];
        for (int i = 0; i < n; i++)
            arr[i] = new Tuple<int, int>(efficiency[i], speed[i]);
        
        Array.Sort(arr, (a, b) => b.Item1 - a.Item1);
        
        var pq = new SortedSet<(int val, int idx)>();
        long ret = 0, sum = 0;
        int index = 0;
        foreach (var t in arr)
        {
            pq.Add((t.Item2, index++));
            sum += t.Item2;
            if (pq.Count > k)
            {
                sum -= pq.Min.val;
                pq.Remove(pq.Min);
            }
            
            ret = Math.Max(ret, sum * t.Item1);
        }
        
        return (int) (ret % 1000000007);
    }
}