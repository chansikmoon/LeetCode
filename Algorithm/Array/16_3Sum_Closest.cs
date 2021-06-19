public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);

        int minDiff = Int32.MaxValue;
        int ret = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i - 1] == nums[i])
                continue;

            int j = i + 1, k = nums.Length - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (Math.Abs(target - sum) < minDiff)
                {
                    minDiff = Math.Abs(target - sum);
                    ret = sum;
                }

                if (target == sum)
                    return ret;
                else if (target > sum)
                    j++;
                else if (target < sum)
                    k--;
            }
        }

        return ret;
    }
}