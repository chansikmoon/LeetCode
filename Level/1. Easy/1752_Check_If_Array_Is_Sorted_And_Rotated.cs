public class Solution {
    public bool Check(int[] nums) {
        int outOfOrder = 0, n = nums.Length;
        
        for (int i = 0; i < n; i++)
        {
            if (nums[i] > nums[(i + 1) % n])
                outOfOrder++;
            if (outOfOrder > 1)
                return false;
        }
        
        return true;
    }
    
    private bool BruteForce(int[] nums)
    {
        int l = 0, r = nums.Length - 1, n = nums.Length;
        while (l < r)
        {
            int m = (l + r) / 2;
            if (nums[m] < nums[r])
                r = m;
            else if (nums[m] > nums[r])
                l = m + 1;
            else
            {
                if (nums[r - 1] > nums[r])
                {
                    l = r;
                    break;
                }
                r--;
            }
        }
        
        var sortedNums = nums.OrderBy(x => x).ToArray();
        
        for (int i = 0; i < n; i++)
        {
            if (sortedNums[i] != nums[(i + l) % n])
                return false;
        }
        
        return true;
    }
}