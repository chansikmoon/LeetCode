public class Solution {
    public int RemoveCoveredIntervals(int[][] arr) {
        int ret = 0, left = -1, right = -1;
        Array.Sort(arr, (a, b) => a[0] - b[0]);

        foreach (int[] a in arr)
        {
            if (a[0] > left && a[1] > right)
            {
                left = a[0];
                ret++;
            }

            right = Math.Max(right, a[1]);
        }

        return ret;
    }
}