public class Solution {
    public double FindMaxAverage(int[] nums, int k) {
        double low = -10001, high = 10001;
        while(low + 0.00001 < high)
        {
            double mid = (low + high) / 2;
            if(IsAveragePossible(nums, k, mid))
                low = mid;
            else
                high = mid;
        }
        
        return (low + high) / 2;
    }
    
    private bool IsAveragePossible(int[] nums, int k, double average)
    {
        int n = nums.Length;
        double[] cum = new double[n+1];
        for(int i = 0; i < n;i++)
            cum[i+1] = cum[i] + nums[i] - average;
        double min = double.MaxValue;
        for(int i = k-1;i < n; i++)
        {
            min = Math.Min(min, cum[i-(k-1)]);
            if(cum[i+1] - min >= 0)
                return true;
        }
        
        return false;
    }
}