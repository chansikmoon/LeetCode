public class Solution {
    public int FindNumberOfLIS(int[] nums) {
        if (nums.Length == 0) return 0;
        
        int n = nums.Length;
        var length = Enumerable.Repeat(1, n).ToArray();
        var count = Enumerable.Repeat(1, n).ToArray();
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < i; j++)
            {
                // increasing
                if (nums[j] < nums[i])
                {
                    // update ith index length and count 
                    if (length[j] >= length[i])
                    {
                        length[i] = length[j] + 1;
                        count[i] = count[j];
                    }
                    // update count
                    else if (length[j] + 1 == length[i])
                        count[i] += count[j];
                }
            }
        }
        
        int longest = length.Max(), ret = 0;
        
        for (int i = 0; i < n; i++)
        {
            if (length[i] == longest)
                ret += count[i];
        }
        
        return ret;
    }
}