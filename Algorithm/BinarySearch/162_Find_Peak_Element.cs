public class Solution {
    public int FindPeakElement(int[] nums) {
        int l = 0, r = nums.Length - 1;
        
        while (l < r)
        {
            int m = l + (r - l) / 2;
            if (nums[m] <= nums[m + 1])
                l = m + 1;
            else
                r = m;
        }
        
        return l;
    }
}