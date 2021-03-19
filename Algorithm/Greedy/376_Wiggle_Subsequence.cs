public class Solution
{
    public int WiggleMaxLength(int[] nums)
    {
        int n = nums.Length;
        if (n == 1)
            return st.Count + 1;

        int ret = 1, sign = 0;

        for (int i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1] && sign != 1)
            {
                sign = 1;
                ret++;
            }
            else if (nums[i] < nums[i - 1] && sign != -1)
            {
                sign = -1;
                ret++;
            }
        }

        return ret;
    }

    public int BruteForce(int[] nums)
    {
        var st = new Stack<bool>();
        int n = nums.Length;
        if (n == 1)
            return st.Count + 1;

        for (int i = 1; i < n; i++)
        {
            int diff = nums[i] - nums[i - 1];
            if (diff == 0)
                continue;

            bool sign = diff > 0;

            if (st.Count == 0 || st.Peek() ^ sign)
                st.Push(sign);
        }

        return st.Count + 1;
    }
}