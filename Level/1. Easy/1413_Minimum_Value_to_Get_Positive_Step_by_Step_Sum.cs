public class Solution {
    public int MinStartValue(int[] nums) {
        int sum = nums[0], min = Math.Min(nums[0], 0);
        
        for (int i = 1; i < nums.Length; i++)
        {
            sum += nums[i];
            min = Math.Min(min, sum);
        }
        
        return 1 + Math.Abs(min);
    }
}