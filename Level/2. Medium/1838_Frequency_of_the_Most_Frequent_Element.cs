public class Solution
{
    public int MaxFrequency(int[] nums, int k)
    {
        Array.Sort(nums);
        int ret = 0;
        long sum = 0;

        for (int l = 0, r = 0; r < nums.Length; r++)
        {
            sum += nums[r];

            while (sum + k < nums[r] * (r - l + 1))
            {
                sum -= nums[l];
                l++;
            }

            ret = Math.Max(ret, r - l + 1);
        }

        return ret;
    }
}