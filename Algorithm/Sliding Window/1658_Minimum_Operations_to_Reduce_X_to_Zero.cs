public class Solution {
    public int MinOperations(int[] nums, int x) {
        int middleSum = nums.Sum()-x;
        if (middleSum < 0)
            return -1;
        if (middleSum == 0)
            return nums.Length;
        int len = -1;
        
        for (int r = 0, l = 0, sum = 0; r < nums.Length; r++)
        {
            if (sum < middleSum)
                sum += nums[r];
            while (sum >= middleSum)
            {
                if (sum == middleSum)
                    len = Math.Max(len, r-l+1);
                sum -= nums[l++];
            }
        }
            
        return len == -1 ? -1 : nums.Length - len;
    }
}