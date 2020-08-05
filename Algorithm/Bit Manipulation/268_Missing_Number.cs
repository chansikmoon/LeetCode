public class Solution {
    public int MissingNumber(int[] nums) {
        int ans = 0;
        
        for (int i = 0; i < nums.Length; i++)
        {
            ans ^= i;
            ans ^= nums[i];
        }
        
        return ans ^= nums.Length;
    }
}