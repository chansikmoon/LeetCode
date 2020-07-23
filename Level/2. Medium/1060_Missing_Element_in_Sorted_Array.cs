public class Solution {
    public int MissingElement(int[] nums, int k) {
        int n = nums.Length, l = 0, h = n - 1;
        int missingNums = nums[n - 1] - nums[0] + 1 - n;
        
        if (missingNums < k)
            return nums[n - 1] + k - missingNums;
        
        while (l < h - 1)
        {
            int m = l + (h - l) / 2;
            int missing = nums[m] - nums[l] - (m - l);
            
            if (missing >= k)
                h = m;
            else
            {
                k -= missing;
                l = m;
            }
        }
        
        return nums[l] + k;
    }
    
    private int BruteForce(int[] nums, int k)
    {
        int n = nums.Length, num = nums[0], index = 0, K = k, missing = nums[0];
        
        while (k > 0 && index < n)
        {
            if (nums[index] != num)
            {
                missing = num;
                k--;
            }
            else
                index++;
            
            num++;   
        }
        
        if (k > 0)
        {
            missing = nums[n - 1] + k;
        }
        
        return missing;
    }
}