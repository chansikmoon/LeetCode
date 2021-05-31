public class Solution
{
    public int Jump(int[] nums)
    {
        // BruteForce
        // return Helper(nums, new int?[nums.Length], 0, 0);
        return Greedy1(nums);
    }

    public int Greedy1(int[] nums)
    {
        int steps = 0, farthest = 0, currEnd = 0;

        for (int i = 0; i < nums.Length - 1; i++)
        {
            farthest = Math.Max(farthest, i + nums[i]);

            if (i == currEnd)
            {
                steps++;
                currEnd = farthest;
            }
        }

        return steps;
    }

    public int Greedy2(int[] nums)
    {
        int steps = 0, position = nums.Length - 1;

        while (position > 0)
        {
            for (int leftMost = 0; leftMost < position; leftMost++)
            {
                if (nums[leftMost] >= position - leftMost)
                {
                    position = leftMost;
                    steps++;
                    break;
                }
            }
        }

        return steps;
    }

    public int Helper(int[] nums, int?[] memo, int curIndex, int steps)
    {
        if (curIndex >= nums.Length - 1)
            return 0;

        if (memo[curIndex].HasValue)
            return memo[curIndex].Value;

        int min = Int32.MaxValue, nextPossibleSteps = nums[curIndex];

        for (int next = 1; next <= nextPossibleSteps; next++)
        {
            int ret = Helper(nums, memo, curIndex + next, steps + 1);

            if (ret != Int32.MaxValue)
                min = Math.Min(min, ret + 1);
        }

        memo[curIndex] = min;

        return min;
    }
}