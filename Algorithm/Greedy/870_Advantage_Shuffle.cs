public class Solution
{
    public int[] AdvantageCount(int[] A, int[] B)
    {
        int n = A.Length;
        var index = new int[n];
        var ret = new int[n];

        for (int i = 0; i < n; i++)
            index[i] = i;

        Array.Sort(A);
        Array.Sort(B, index);

        int l = 0, r = n - 1;

        for (int i = n - 1; i >= 0; i--)
        {
            if (B[i] >= A[r])
                ret[index[i]] = A[l++];
            else
                ret[index[i]] = A[r--];
        }

        return ret;
    }

    // Passed all 67 test cases but took too long (TLE)
    public int[] BruteForce(int[] A, int[] B)
    {
        var sortedList = new SortedList<int, int>();

        foreach (int a in A)
        {
            if (!sortedList.ContainsKey(a))
                sortedList.Add(a, 0);
            sortedList[a]++;
        }

        var ret = new int[A.Length];

        for (int i = 0; i < A.Length; i++)
        {
            int nextKey = -1;
            foreach (var kvp in sortedList)
            {
                if (kvp.Key > B[i])
                {
                    nextKey = kvp.Key;
                    break;
                }
            }

            if (nextKey == -1)
                nextKey = sortedList.First().Key;

            ret[i] = nextKey;

            sortedList[nextKey]--;
            if (sortedList[nextKey] == 0)
                sortedList.Remove(nextKey);
        }

        return ret;
    }
}