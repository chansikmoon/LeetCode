public class Solution
{
    public int MinMoves2(int[] nums)
    {
        Array.Sort(nums);
        int i = 0, j = nums.Length - 1, ret = 0;

        while (i < j)
            ret += nums[j--] - nums[i++];

        return ret;
    }

    public int Solution1(int[] nums)
    {
        Array.Sort(nums);
        int median = nums[nums.Length / 2], ret = 0;

        foreach (int num in nums)
            ret += Math.Abs(median - num);

        return ret;
    }
}