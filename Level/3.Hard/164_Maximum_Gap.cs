public class Solution {
    public int MaximumGap(int[] nums) {
        if (nums == null || nums.Length < 2)
            return 0;
        
        int min = nums[0];
        int max = nums[0];
        
        foreach (int num in nums)
        {
            min = Math.Min(min, num);
            max = Math.Max(max, num);
        }
        
        int gap = (int)Math.Ceiling((double)(max - min) / (nums.Length - 1));
        var bucketsMin = new int[nums.Length - 1];
        var bucketsMax = new int[nums.Length - 1];
        Array.Fill(bucketsMin, Int32.MaxValue);
        Array.Fill(bucketsMax, Int32.MinValue);
        
        foreach (int num in nums)
        {
            if (num == min || num == max)
                continue;
            
            int idx = (num - min) / gap;
            bucketsMin[idx] = Math.Min(bucketsMin[idx], num);
            bucketsMax[idx] = Math.Max(bucketsMax[idx], num);
        }
        
        int maxGap = Int32.MinValue;
        int prev = min;
        
        for (int i = 0; i < nums.Length - 1; i++)
        {
            if (bucketsMin[i] == Int32.MaxValue && bucketsMax[i] == Int32.MinValue)
                continue;
            maxGap = Math.Max(maxGap, bucketsMin[i] - prev);
            prev = bucketsMax[i];
        }
        
        maxGap = Math.Max(maxGap, max - prev);
        return maxGap;
    }
}