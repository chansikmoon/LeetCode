public class Solution {
    public int[] MaxSlidingWindow(int[] nums, int k) {
        int n = nums.Length;
        if (n == 0)
            return new int[0];
        
        int[] leftMax = new int[n], rightMax = new int[n], ret = new int[n - k + 1];
        leftMax[0] = nums[0];
        rightMax[n - 1] = nums[n - 1];
        
        for (int i = 1; i < n; i++)
        {
            leftMax[i] = i % k == 0 ? nums[i] : Math.Max(nums[i], leftMax[i - 1]);
            
            int j = n - i - 1;
            rightMax[j] = (j + 1) % k == 0 ? nums[j] : Math.Max(nums[j], rightMax[j + 1]);
        }
        
        /*

        k = 3
        input [1, 3, -1, | -3, 5, 3, | 6, 7]
                      i . . .             i
        left  [1, 3,  3, | -3, 5, 5, | 6, 7]
               j . . .            j
        right [3, 3, -1, |  5, 5, 3, | 7, 7]
        
        i: 2, j = 0 => Math.Max(3,  3) = 3
        i: 3, j = 1 => Math.Max(-3, 3) = 3
        i: 4, j = 2 => Math.Max(5, -1) = 5
        i: 5, j = 3 => Math.Max(5,  5) = 5
        i: 6, j = 4 => Math.Max(6,  5) = 6
        i: 7, j = 5 => Math.Max(7,  3) = 7
        
         */

        for (int i = 0; i + k - 1 < n; i++)
            ret[i] = Math.Max(leftMax[i + k - 1], rightMax[i]);
        
        return ret;
    }
}