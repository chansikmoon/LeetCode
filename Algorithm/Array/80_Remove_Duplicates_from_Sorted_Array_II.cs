public class Solution {
    public int RemoveDuplicates(int[] nums) {
        int index = 0;
        foreach (int num in nums)
        {
            if (index < 2 || num > nums[index - 2])
                nums[index++] = num;
        }
        
        return index;
    }
}