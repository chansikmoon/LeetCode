public class Solution
{
    public int SubsetXORSum(int[] nums)
    {
        int n = nums.Length, numOfSubsets = 1 << nums.Length;
        int ret = 0;

        for (int i = 0; i < numOfSubsets; i++)
        {
            int tmp = 0;
            for (int j = 0; j < n; j++)
            {
                if (((i >> j) & 1) > 0)
                    tmp ^= nums[j];
            }

            ret += tmp;
        }

        return ret;
    }

    private int BitSolution(int[] nums)
    {
        int n = nums.Length, sum = 0;

        for (int i = 0; i < n; i++)
            sum |= nums[i];

        return sum * 1 << (n - 1);
    }
}