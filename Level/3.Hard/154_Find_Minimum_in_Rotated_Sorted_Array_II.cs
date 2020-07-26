public class Solution {
    public int FindMin(int[] nums) {
        int l = 0, r = nums.Length - 1;
        
        while (l < r)
        {
            int m = l + (r - l) / 2;
            
            if (nums[m] < nums[r])
            {
                r = m;
            }
            else if (nums[m] > nums[r])
            {
                l = m + 1;
            }
            else
            {
                // [1,1,1,1,1,1,1,1,2,1,1]
                //  l       m         r
                // need to make l = r
                // End the while loop and return nums[l]
                if (nums[r - 1] > nums[r])
                {
                    l = r;
                    break;
                }
                r--;
            }
        }
        
        return nums[l];
    }
}