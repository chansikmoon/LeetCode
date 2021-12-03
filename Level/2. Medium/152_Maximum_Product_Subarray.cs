public class Solution {
    public int MaxProduct(int[] nums) {
        int l = 0, r = 0, ret = nums[0];
        
        for (int i = 0; i < nums.Length; i++)
        {
            l = (l == 0 ? 1 : l) * nums[i];
            r = (r == 0 ? 1 : r) * nums[nums.Length - i - 1];
            ret = Math.Max(ret, Math.Max(l, r));
        }
        
        return ret;
    }
}