public class Solution
{
    public int MaxBuilding(int n, int[][] restrictions)
    {
        var list = new List<int[]>();
        list.Add(new int[] { 1, 0 });
        list.Add(new int[] { n, n - 1 });
        foreach (var r in restrictions)
            list.Add(new int[] { r[0], r[1] });
        var sorted = list.OrderBy(x => x[0]).ToList();

        for (int i = 1; i < sorted.Count; i++)
            sorted[i][1] = Math.Min(sorted[i][1], sorted[i - 1][1] + sorted[i][0] - sorted[i - 1][0]);

        for (int i = sorted.Count - 2; i >= 0; i--)
            sorted[i][1] = Math.Min(sorted[i][1], sorted[i + 1][1] + sorted[i + 1][0] - sorted[i][0]);

        int ret = 0;
        for (int i = 1; i < sorted.Count; i++)
        {
            int left = sorted[i - 1][0], right = sorted[i][0];
            int left_restriction = sorted[i - 1][1], right_restriction = sorted[i][1];

            // right - left => range
            // Abs(rr - lr) => available heights to increase to make the lower height location to the same height as a higher height location.
            // left + abs(rr - lr) => new lower height location when it is the same as the higher height location
            // right - (left + abs(rr - lr)) == right - left - abs(rr - lr)
            // right - left - Abs(lr - rr) => remaining heights to increase after making both locations the same height
            // (right - left - Abs(lr - rr)) / 2 => heights to increase from the both side to meet at the middle
            ret = Math.Max(ret,
                           Math.Max(left_restriction, right_restriction) +
                           (right - left - Math.Abs(left_restriction - right_restriction)) / 2);
        }

        return ret;
    }
}


// 4    10
// x    y

// 10 - 4 = 6
// x + 6 = new location
// y - x - 6 == remaining heights to increase
// (y - x - (10 - 4)) / 2
// (20 - 10 - 6) / 2 = 2

// 4    5    6   7   8  9   10  11  12  11  10
// 10   11  12  13  14  15  16  17  18  19  20