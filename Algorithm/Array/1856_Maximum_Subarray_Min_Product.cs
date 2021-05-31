public class Solution
{
    public int MaxSumMinProduct(int[] nums)
    {
        int n = nums.Length;
        var st = new Stack<long>();
        var leftMost = new long[n];
        var rightMost = new long[n];

        for (long i = 0; i < n; i++)
        {
            while (st.Count > 0 && nums[st.Peek()] >= nums[i])
                st.Pop();
            if (st.Count > 0)
                leftMost[i] = st.Peek() + 1;
            else
                leftMost[i] = 0;
            st.Push(i);
        }

        st = new Stack<long>();
        for (long i = n - 1; i >= 0; i--)
        {
            while (st.Count > 0 && nums[st.Peek()] >= nums[i])
                st.Pop();
            if (st.Count > 0)
                rightMost[i] = st.Peek() - 1;
            else
                rightMost[i] = n - 1;
            st.Push(i);
        }

        var preSum = new long[n + 1];
        for (int i = 0; i < n; i++)
            preSum[i + 1] = preSum[i] + (long)nums[i];

        long max = 0;
        for (int i = 0; i < n; i++)
            max = Math.Max(max, GetPreSum(preSum, leftMost[i], rightMost[i]) * nums[i]);

        return (int)(max % 1000000007);
    }

    private long GetPreSum(long[] preSum, long left, long right)
    {
        return preSum[right + 1] - preSum[left];
    }
}