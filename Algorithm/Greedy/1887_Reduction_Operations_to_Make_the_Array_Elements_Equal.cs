public class Solution {
    public int ReductionOperations(int[] nums) {
        Array.Sort(nums);
        
        int ret = 0, n = nums.Length;
        
        for (int i = n - 2; i >= 0; i--)
        {
            if (nums[i] == nums[i+1])
                continue;
            
            ret += (n - i - 1);
        }
        
        return ret;
    }
}