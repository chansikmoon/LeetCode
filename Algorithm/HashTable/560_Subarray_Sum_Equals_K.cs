public class Solution {
    public int SubarraySum(int[] nums, int k) {
        var map = new Dictionary<int, int>();
        map.Add(0, 1);
        int sum = 0, ret = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            
            if (map.ContainsKey(sum - k))
                ret += map[sum - k];
            
            if (!map.ContainsKey(sum))
                map.Add(sum, 0);
            
            map[sum]++;
        }
        
        return ret;
    }
}