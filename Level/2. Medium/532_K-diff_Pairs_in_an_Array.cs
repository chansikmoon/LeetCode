public class Solution {
    public int FindPairs(int[] nums, int k) {
        Dictionary<int, int> map = new Dictionary<int, int>();
        int ret = 0;
        
        foreach (int num in nums)
        {
            if (!map.ContainsKey(num))
                map.Add(num, 0);
            map[num]++;
        }
        
        foreach (var kvp in map)
        {
            if ((k > 0 && map.ContainsKey(kvp.Key + k)) || 
                (k == 0 && map.ContainsKey(kvp.Key) && map[kvp.Key] > 1))
                ret++;
        }
        
        return ret;
    }
}