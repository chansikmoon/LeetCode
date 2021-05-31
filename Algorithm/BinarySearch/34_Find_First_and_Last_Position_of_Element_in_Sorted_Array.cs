public class Solution
{
    public int[] SearchRange(int[] nums, int target)
    {
        int l = 0, r = nums.Length - 1;
        var ret = new int[] { -1, -1 };

        while (l <= r)
        {
            int m = l + (r - l) / 2;

            if (nums[m] >= target)
            {
                if (nums[m] == target)
                    ret[0] = m;

                r = m - 1;
            }
            else
                l = m + 1;
        }

        r = nums.Length - 1;

        while (l <= r)
        {
            int m = l + (r - l) / 2;

            if (nums[m] == target)
            {
                ret[1] = m;
                l = m + 1;
            }
            else
                r = m - 1;
        }

        return ret;
    }

    private int FindPosition(int[] nums, int target)
    {
        int n = nums.Length;
        int l = 0, h = n - 1;
        int first_pos = n;

        while (l <= h)
        {
            int mid = l + (h - l) / 2;
            if (nums[mid] >= target)
            {
                first_pos = mid;
                h = mid - 1;
            }
            else
                l = mid + 1;
        }

        return first_pos;
    }

    // Just look for the first appear position for target and target + 1
    // And subtract 1 index for the target + 1 position.
    public int[] AnotherWay(int[] nums, int target)
    {
        int first = FindPosition(nums, target);
        int last = FindPosition(nums, target + 1) - 1;

        if (first <= last)
            return new int[] { first, last };

        return new int[] { -1, -1 };
    }
}