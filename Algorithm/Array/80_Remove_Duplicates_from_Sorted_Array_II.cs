public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int idx = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            if (idx < 2 || nums[idx - 2] < nums[i])
            {
                nums[idx++] = nums[i];
            }
        }
        
        return idx;
    }
}