public class Solution {
    public int SingleNonDuplicate(int[] nums) {
        int l = 0, r = nums.Length - 1;
        if (r == 1)
            return nums[l];
        
        while (l < r)
        {
            int m = l + (r - l) / 2;
            
            if (m - 1 >= 0 && m + 1 < nums.Length && nums[m] != nums[m - 1] && nums[m] != nums[m + 1])
                return nums[m];
            
            if (nums[m] == nums[m - 1])
            {
                if ((m - l + 1) % 2 == 0)
                    l = m + 1;
                else
                    r = m - 2;
            }
            else
            {
                if ((m - l) % 2 == 0)
                    l = m + 2;
                else
                    r = m - 1;
            }
        }
        
        return nums[l];
    }
}