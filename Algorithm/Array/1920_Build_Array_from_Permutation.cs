public class Solution {
    public int[] BuildArray(int[] nums) {
        int n = nums.Length;
        var ret = new int[n];
        
        for (int i = 0; i < n; i++)
            ret[i] = nums[nums[i]];
        
        return ret;
    }
}