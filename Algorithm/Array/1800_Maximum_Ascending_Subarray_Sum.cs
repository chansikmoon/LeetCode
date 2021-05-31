public class Solution
{
    public int MaxAscendingSum(int[] nums)
    {
        int sum = nums[0], ret = 0;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                ret = Math.Max(ret, sum);
                sum = 0;
            }

            sum += nums[i];
        }

        return Math.Max(ret, sum);
    }
}