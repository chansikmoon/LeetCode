public class Solution
{
    public IList<int> MinAvailableDuration(int[][] slots1, int[][] slots2, int duration)
    {
        var arr1 = slots1.OrderBy(x => x[0]).ToArray();
        var arr2 = slots2.OrderBy(x => x[0]).ToArray();

        var ret = new List<int>();
        int i = 0, j = 0;

        while (i < arr1.Length && j < arr2.Length)
        {
            int start = Math.Max(arr1[i][0], arr2[j][0]);
            int end = Math.Min(arr1[i][1], arr2[j][1]);

            if (end - start >= duration)
                return new List<int>() { start, start + duration };

            if (arr1[i][1] < arr2[j][1])
                i++;
            else
                j++;
        }

        return new List<int>();
    }

    public IList<int> BruteForce(int[][] slots1, int[][] slots2, int duration)
    {
        var arr1 = slots1.OrderBy(x => x[0]).ToArray();
        var arr2 = slots2.OrderBy(x => x[0]).ToArray();

        var ret = new List<int>();

        for (int i = 0, j = 0; i < arr1.Length && j < arr2.Length;)
        {
            if (arr1[i][0] < arr2[j][1] && arr2[j][0] < arr1[i][1])
            {
                int start = Math.Max(arr1[i][0], arr2[j][0]);
                int end = Math.Min(arr1[i][1], arr2[j][1]);

                if (end - start >= duration)
                {
                    ret.Add(start);
                    ret.Add(start + duration);

                    return ret;
                }
            }

            if (arr1[i][1] < arr2[j][1])
                i++;
            else
                j++;
        }

        return ret;
    }
}
