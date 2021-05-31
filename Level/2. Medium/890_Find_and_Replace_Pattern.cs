public class Solution
{
    public IList<string> FindAndReplacePattern(string[] words, string pattern)
    {
        var p = Normalize(pattern);
        return words.Where(x => Normalize(x) == p).ToList();
    }

    private string Normalize(string w)
    {
        var arr = new char[26];
        char cur = 'a';
        var sb = new StringBuilder();
        foreach (char c in w)
        {
            int i = c - 'a';
            if (arr[i] == 0)
                arr[i] = cur++;
            sb.Append(arr[i]);
        }

        return sb.ToString();
    }
}