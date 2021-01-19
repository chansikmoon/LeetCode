public class Solution {
    public int MaxOperations(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        
        foreach (int num in nums)
        {
            if (!map.ContainsKey(num))
                map.Add(num, 0);
            map[num]++;
        }
        
        int ret = 0;
        foreach (var key in map.Keys.ToList())
        {
            int targetKey = k - key;
            if (map[key] <= 0 || !map.ContainsKey(targetKey))
                continue;
            
            int possible = Math.Min(map[key], map[targetKey]);
            if (key == targetKey)
            {
                possible = map[key] >= 2 ? map[key] / 2 : 0;
            }
            
            ret += possible;
            
            map[key] -= possible;
            map[targetKey] -= possible;
        }
        
        return ret;
    }
}