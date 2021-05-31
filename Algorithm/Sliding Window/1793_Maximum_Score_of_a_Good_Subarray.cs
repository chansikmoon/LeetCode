public class Solution
{
    public int MaximumScore(int[] nums, int k)
    {
        int i = k, j = k, min = nums[k], ret = nums[k];

        while (i > 0 || j < nums.Length - 1)
        {
            if (i == 0)
                j++;
            else if (j == nums.Length - 1)
                i--;
            else if (nums[i - 1] < nums[j + 1])
                j++;
            else
                i--;

            min = Math.Min(min, Math.Min(nums[i], nums[j]));
            ret = Math.Max(ret, min * (j - i + 1));
        }

        return ret;
    }
}