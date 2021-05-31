public class Solution
{
    public int MinSwaps(string s)
    {
        int ones = 0, zeros = 0;

        foreach (char c in s)
        {
            if (c == '0')
                zeros++;
            else
                ones++;
        }

        if (Math.Abs(ones - zeros) > 1)
            return -1;

        if (ones > zeros)
            return Helper(s, '1');

        if (ones < zeros)
            return Helper(s, '0');

        return Math.Min(Helper(s, '1'), Helper(s, '0'));
    }

    private int Helper(string s, char c)
    {
        var arr = s.ToCharArray();
        int swap = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] != c)
                swap++;
            c = c == '1' ? '0' : '1';
        }

        return swap / 2;
    }
}