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

    public int Solution1(int[] nums) {
        int expected = nums.Length * (nums.Length + 1) / 2;
        int actual = 0;
        for (int i = 0; i < nums.Length; i++)
            actual += nums[i];
        
        return expected - actual;
    }
}