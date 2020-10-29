public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        List<string> ret = new List<string>();
        
        for (int l = 0, r = 0; r < nums.Length; r++)
        {
            if (r + 1 < nums.Length && nums[r] + 1 == nums[r + 1])
                continue;
            
            if (l == r)
                ret.Add(nums[r].ToString());
            else
                ret.Add(string.Format("{0}->{1}", nums[l], nums[r]));
            
            l = r + 1;
        }
        
        return ret;
    }
}