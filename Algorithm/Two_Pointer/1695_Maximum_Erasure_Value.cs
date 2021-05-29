public class Solution
{
    public int MaximumUniqueSubarray(int[] nums)
    {
        int ret = 0;
        var seen = new HashSet<int>();

        for (int r = 0, l = 0, sum = 0; r < nums.Length; r++)
        {
            while (seen.Contains(nums[r]))
            {
                sum -= nums[l];
                seen.Remove(nums[l++]);
            }

            sum += nums[r];
            seen.Add(nums[r]);

            ret = Math.Max(ret, sum);
        }

        return ret;
    }
}