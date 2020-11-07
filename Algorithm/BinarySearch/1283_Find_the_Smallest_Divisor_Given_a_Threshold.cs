public class Solution {
    public int SmallestDivisor(int[] nums, int threshold) {
        int left = 1, right = Int32.MinValue, n = nums.Length;
        
        for (int i = 0; i < n; i++)
        {
            right = Math.Max(right, nums[i]);
        }
        
        while (left < right)
        {
            int mid = (left + right) >> 1, sum = 0;
            
            for (int i = 0; i < n; i++)
            {
                sum += (int) Math.Ceiling((double) nums[i] / mid);
            }
            
            if (sum > threshold)
                left = mid + 1;
            else
                right = mid;
        }
        
        return left;
    }
}