public class Solution {
    public IList<string> SummaryRanges(int[] nums) {
        var ret = new List<string>();
        
        for (int l = 0, r = 0; r < nums.Length; r++) {
            if (r + 1 < nums.Length && nums[r] + 1 == nums[r + 1]) {
                continue;
            }
            
            ret.Add(l == r ? $"{nums[r]}" : $"{nums[l]}->{nums[r]}");
            l = r + 1;
        }
        
        return ret;
    }
}