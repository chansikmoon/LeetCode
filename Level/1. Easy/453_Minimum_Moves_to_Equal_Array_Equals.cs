public class Solution
{
    public int MinMoves(int[] nums)
    {
        int min = nums[0];

        for (int i = 1; i < nums.Length; i++)
            min = Math.Min(min, nums[i]);

        int ret = 0;

        for (int i = 0; i < nums.Length; i++)
            ret += nums[i] - min;

        return ret;
    }
}