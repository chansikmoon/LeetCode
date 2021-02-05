public class Solution {
    public int FindLHS(int[] nums) {
        var map = new Dictionary<int, int>();
        
        foreach (int num in nums)
        {
            if (!map.ContainsKey(num))
                map.Add(num, 0);
                
            map[num]++;
        }
        
        int ret = 0;
        
        foreach (var kvp in map)
        {
            if (map.ContainsKey(kvp.Key + 1))
                ret = Math.Max(ret, map[kvp.Key + 1] + kvp.Value);
        }
        
        return ret;
    }
}