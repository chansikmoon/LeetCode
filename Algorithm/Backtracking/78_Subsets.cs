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

    public IList<IList<int>> BacktrackingSubsets(int[] nums)
    {
        var ret = new List<IList<int>>();
        Array.Sort(nums);
        Backtracking(ret, new List<int>(), nums, 0);
        return ret;
    }

    private void Backtracking(List<IList<int>> ret, List<int> list, int[] nums, int i)
    {
        ret.Add(new List<int>(list));
        for (; i < nums.Length; i++)
        {
            list.Add(nums[i]);
            Backtracking(ret, list, nums, i + 1);
            list.RemoveAt(list.Count - 1);
        }
    }
}