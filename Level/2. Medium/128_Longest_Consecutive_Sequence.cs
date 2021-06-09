public class Solution {
    public int LongestConsecutive(int[] nums) {
        var map = new Dictionary<int, int>();
        int ret = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (!map.ContainsKey(nums[i]))
            {
                int left = map.ContainsKey(nums[i] - 1) ? map[nums[i] - 1] : 0;
                int right = map.ContainsKey(nums[i] + 1) ? map[nums[i] + 1] : 0;
                int sum = left + right + 1;
                
                map.Add(nums[i], sum);
                
                ret = Math.Max(ret, sum);
                
                if (!map.ContainsKey(nums[i] - left))
                    map.Add(nums[i] - left, 0);
                if (!map.ContainsKey(nums[i] + right))
                    map.Add(nums[i] + right, 0);
                
                map[nums[i] - left] = sum;
                map[nums[i] + right] = sum;
            }
        }
        
        return ret;
    }
}