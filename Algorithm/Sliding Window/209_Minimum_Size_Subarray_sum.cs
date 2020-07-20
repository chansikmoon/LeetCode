public class Solution {
    public int MinSubArrayLen(int s, int[] nums) {
        int res = Int32.MaxValue, n = nums.Length, sum = 0;
        
        for (int l = 0, r = 0; r < n; r++)
        {
            sum += nums[r];
            
            while (sum >= s)
            {
                res = Math.Min(res, r - l + 1);
                sum -= nums[l++];
            }
        }
        
        return res == Int32.MaxValue ? 0 : res;
    }
}