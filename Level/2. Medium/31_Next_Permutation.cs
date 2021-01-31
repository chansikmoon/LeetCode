public class Solution {
    public void NextPermutation(int[] nums) {
        int i = nums.Length - 2;
        
        // Find the first decreasing element starting from the end of an array
        while (i >= 0 && nums[i] >= nums[i + 1])
            i--;
        
        if (i >= 0)
        {
            // Find the first bigger nums[j] than nums[i] starting from the end of an array
            int j = nums.Length - 1;
            while (i < j && nums[i] >= nums[j])
                j--;
            
            Swap(nums, i, j);
        }
        
        Reverse(nums, i + 1);
    }
    
    private void Swap(int[] nums, int i, int j)
    {
        int tmp = nums[i];
        nums[i] = nums[j];
        nums[j] = tmp;
    }
    
    private void Reverse(int[] nums, int i)
    {
        int j = nums.Length - 1;
        while (i < j)
            Swap(nums, i++, j--);
    }
}