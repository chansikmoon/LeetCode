public class Solution {
    public int FindUnsortedSubarray(int[] nums) {
        int l = -1, r = -2, n = nums.Length;
        int min = nums[n - 1], max = nums[0];
        
        for (int i = 1; i < n; i++)
        {
            max = Math.Max(max, nums[i]);
            min = Math.Min(min, nums[n-1-i]);
            
            if (nums[i] < max)
                r = i;
            if (nums[n-1-i] > min)
                l = n-1-i;
        }
        
        return r-l+1;
    }
    
    private int BruteForce(int[] nums)
    {
        var sorted = nums.OrderBy(x => x).ToArray();
        int ret = 0;
        for (int l = -1, r = 0; r < nums.Length; r++)
        {
            if (sorted[r] != nums[r])
            {
                if (l == -1)
                    l = r;
                
                ret = Math.Max(ret, r - l + 1);
            }
        }
        
        return ret;
    }
}