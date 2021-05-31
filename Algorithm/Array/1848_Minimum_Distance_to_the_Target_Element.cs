public class Solution
{
    public int GetMinDistance(int[] nums, int target, int start)
    {
        int ret = Int32.MaxValue;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
                ret = Math.Min(ret, Math.Abs(start - i));
        }

        return ret;
    }
}