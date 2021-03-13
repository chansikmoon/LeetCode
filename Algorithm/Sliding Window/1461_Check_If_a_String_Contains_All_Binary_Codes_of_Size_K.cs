public class Solution
{
    public bool HasAllCodes(string s, int k)
    {
        var _set = new HashSet<string>();

        for (int i = 0; i <= s.Length - k; i++)
            _set.Add(s.Substring(i, k));

        return _set.Count == (int)Math.Pow(2, k);
    }
}