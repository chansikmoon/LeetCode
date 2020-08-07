public class Solution {
    public int FindDuplicate(int[] nums) {
        int tortoise = nums[nums[0]], hare = nums[nums[nums[0]]];
        
        while (tortoise != hare)
        {
            tortoise = nums[tortoise];
            hare = nums[nums[hare]];
        }
        
        tortoise = nums[0];
        
        while (tortoise != hare)
        {
            tortoise = nums[tortoise];
            hare = nums[hare];
        }
        
        return hare;
    }
}