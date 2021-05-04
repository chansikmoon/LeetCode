public class Solution
{
    public int[] RunningSum(int[] nums)
    {
        var ret = new int[nums.Length];

        for (int i = 0; i < nums.Length; i++)
        {
            int sum = nums[i];

            if (i > 0)
                sum += ret[i - 1];

            ret[i] = sum;
        }

        return ret;
    }
}