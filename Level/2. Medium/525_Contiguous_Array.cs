public class Solution {
    public int FindMaxLength(int[] nums) {
        var map = new Dictionary<int, int>();
        int ret = 0, sum = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i] == 0 ? -1 : 1;
            
            if (sum == 0)
                ret = Math.Max(ret, i + 1);
            else if (map.ContainsKey(sum))
                ret = Math.Max(ret, i - map[sum]);
            else
                map.Add(sum, i);
        }
        
        return ret;
    }
}