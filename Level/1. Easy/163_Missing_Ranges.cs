public class Solution {
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) {
        List<string> ret = new List<string>();
        
        if (nums.Length == 0)
        {
            ret.Add(GetMissingString(lower, upper));
            return ret;
        }
        
        // lower -> nums[0]
        if (lower < nums[0])
            ret.Add(GetMissingString(lower, nums[0] - 1));
        
        // nums[1] -> nums[n - 1]
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i - 1] + 1 == nums[i])
                continue;
            
            ret.Add(GetMissingString(nums[i - 1] + 1, nums[i] - 1));
        }
        
        // nums[n - 1] -> upper
        if (nums[nums.Length - 1] < upper)
        {
            ret.Add(GetMissingString(nums[nums.Length - 1] + 1, upper));
        }
        
        return ret;
    }
    
    public string GetMissingString(int a, int b)
    {
        return a == b ? a.ToString() : string.Format("{0}->{1}", a, b);
    }
}