public class Solution
{
    public int MaxResult(int[] nums, int k)
    {
        var dp = new int[nums.Length];
        // Ascending val order
        var pq = new SortedSet<(int val, int idx)>();

        // Descending val order then descending idx order.
        // var pq = new SortedSet<(int val, int idx)>(
        //     Comparer<(int val, int idx)>.Create((a, b) =>
        //     {
        //         var ret = b.val.CompareTo(a.val);
        //         return ret != 0 ? ret : b.idx.CompareTo(a.idx);
        //     }));

        Array.Fill(dp, Int32.MinValue);

        dp[0] = nums[0];
        pq.Add((nums[0], 0));

        for (int i = 1; i < nums.Length; i++)
        {
            // Ascending val order
            while (pq.Max.idx < i - k)
                pq.Remove(pq.Max);

            dp[i] = Math.Max(dp[i], pq.Max.val + nums[i]);
            pq.Add((dp[i], i));

            // If pq is in descending order
            // while (pq.Min.idx < i - k)
            //     pq.Remove(pq.Min);

            // dp[i] = Math.Max(dp[i], pq.Min.val + nums[i]);
            // pq.Add((dp[i], i));
        }

        return dp[nums.Length - 1];
    }
}