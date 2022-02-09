public class Solution {
    public int FindPairs(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        int ret = 0;
        
        foreach (int num in nums)
        {
            if (!map.ContainsKey(num))
                map.Add(num, 0);
            map[num]++;
        }
        
        foreach (var kvp in map)
        {
            int num = kvp.Key;
            int freq = kvp.Value;
            
            if ((k > 0 && map.ContainsKey(num - k)) ||
               (k == 0 && map[num] > 1))
            {
                ret++;
            }
        }
        
        return ret;
    }
}