public class Solution
{
    public int PartitionDisjoint(int[] nums)
    {
        int n = nums.Length, index = 0, max = nums[0], maxMax = nums[0];

        for (int i = 1; i < n; i++)
        {
            if (max > nums[i])
            {
                max = maxMax;
                index = i;
            }
            else
                maxMax = Math.Max(maxMax, nums[i]);
        }

        return index + 1;
    }

    public int BruteForce(int[] nums)
    {
        int n = nums.Length;
        var left = new int[n];
        var right = new int[n];

        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                left[i] = nums[i];
                continue;
            }

            left[i] = Math.Max(left[i - 1], nums[i]);
        }

        for (int i = n - 1; i >= 0; i--)
        {
            if (i == n - 1)
            {
                right[i] = nums[i];
                continue;
            }

            right[i] = Math.Min(right[i + 1], nums[i]);
        }

        for (int i = 1; i < n; i++)
        {
            if (left[i - 1] <= right[i])
                return i;
        }

        return 1;
    }
}
// 5 5 5 8 8 
// 0 0 3 6 6

// 1 1 1 1 6 12
// 0 0 0 0 6 12