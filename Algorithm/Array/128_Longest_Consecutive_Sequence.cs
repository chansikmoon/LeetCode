public class Solution
{
    // TC: O(n)
    public int LongestConsecutive(int[] nums)
    {
        var map = new Dictionary<int, int>();
        int max = 0;

        foreach (int num in nums)
        {
            if (!map.ContainsKey(num))
            {
                int left = map.ContainsKey(num - 1) ? map[num - 1] : 0;
                int right = map.ContainsKey(num + 1) ? map[num + 1] : 0;
                int sum = left + right + 1;

                max = Math.Max(max, sum);

                map.Add(num, sum);

                // Update farthest left or right with new sum
                if (!map.ContainsKey(num - left))
                    map.Add(num - left, 0);

                if (!map.ContainsKey(num + right))
                    map.Add(num + right, 0);

                map[num - left] = sum;
                map[num + right] = sum;
            }
        }

        return max;
    }

    // Really simple way
    // https://leetcode.com/problems/longest-consecutive-sequence/discuss/41057/Simple-O(n)-with-Explanation-Just-walk-each-streak
    public int AnoterSolution(int[] nums)
    {
        // O(1)
        var _set = new SortedSet<int>();

        // O(n)
        foreach (int num in nums)
            _set.Add(num);

        int max = 0;

        // O(nlogn)
        foreach (var num in _set)
        {
            // SortedSet<T>.Contians(T) O(log n)
            if (!_set.Contains(num - 1))
            {
                int next = num + 1;

                // Worst case: iterate all remaining items in the set. O(n)
                // But we only do this while loop if and only if we found a new group starting point.
                // We are not coming into this inner loop unless we find another group.
                // Therefore, we can ignore O(n).
                // SortedSet<T>.Contians(T) O(log n)
                while (_set.Contains(next))
                    next += 1;

                max = Math.Max(max, next - num);
            }
        }

        return max;
    }
}