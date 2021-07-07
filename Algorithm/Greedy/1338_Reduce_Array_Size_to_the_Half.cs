public class Solution {
    public int MinSetSize(int[] arr) {
        var freq = new Dictionary<int, int>();
        
        for (int i = 0; i < arr.Length; i++)
        {
            if (!freq.ContainsKey(arr[i]))
                freq.Add(arr[i], 0);
            
            freq[arr[i]]++;
        }
        
        var pq = new SortedSet<(int count, int val)>();
        
        foreach (var kvp in freq)
            pq.Add((kvp.Value, kvp.Key));
        
        int count = 0, size = 0;
        while (size * 2 < arr.Length)
        {
            count++;
            size += pq.Max.count;
            pq.Remove(pq.Max);
        }
        
        return count;
    }

    public int linq(int[] arr) {
        var freq = arr
            .GroupBy(x => x)
            .Select(x => (num: x.Key, count: x.Count()))
            .OrderByDescending(x => x.count)
            .ToList();
        
        int ret = 0, half = arr.Length / 2, i = 0;
        
        while (half > 0)
        {
            half -= freq[i++].count;
            ret++;
        }
        
        return ret;
    }
}