public class Solution
{
    // TC: O(N^2 + L)
    // SC: O(N)
    public int MaxProduct(string[] words)
    {
        int n = words.Length;
        var arr = new int[n];

        // O(L), the total number of characters.
        for (int i = 0; i < n; i++)
        {
            var w = words[i];
            foreach (var c in w)
                arr[i] |= (1 << (c - 'a'));
        }

        int ret = 0;

        // O(N^2), N is the total number of words.
        for (int i = 0; i < n; i++)
        {
            for (int j = i + 1; j < n; j++)
            {
                if ((arr[i] & arr[j]) == 0)
                    ret = Math.Max(ret, words[i].Length * words[j].Length);
            }
        }

        return ret;
    }
}