public class Solution
{
    public IList<IList<int>> Subsets(int[] nums)
    {
        int n = nums.Length, m = 1 << nums.Length;
        var ret = new List<IList<int>>();
        for (int i = 0; i < m; i++)
            ret.Add(new List<int>());

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (((i >> j) & 1) > 0)
                    ret[i].Add(nums[j]);
            }
        }

        return ret;
    }
}