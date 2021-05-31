public class Solution
{
    public int LargestUniqueNumber(int[] A)
    {
        var freq = new int[1001];

        for (int i = 0; i < A.Length; i++)
            freq[A[i]]++;

        for (int i = 1000; i >= 0; i--)
            if (freq[i] == 1)
                return i;

        return -1;
    }

    public int Solution2(int[] A)
    {
        var freq = new Dictionary<int, int>();

        for (int i = 0; i < A.Length; i++)
        {
            if (!freq.ContainsKey(A[i]))
                freq.Add(A[i], 0);
            freq[A[i]]++;
        }

        int ret = -1;

        foreach (var kvp in freq)
        {
            if (kvp.Value == 1)
                ret = Math.Max(ret, kvp.Key);
        }

        return ret;
    }
}