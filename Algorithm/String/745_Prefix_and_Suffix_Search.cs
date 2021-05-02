public class WordFilter
{
    private Dictionary<string, int> map;
    public WordFilter(string[] words)
    {
        map = new Dictionary<string, int>();
        int index = 0;

        foreach (var word in words)
        {
            int n = word.Length;

            for (int len = 1; len <= n; len++)
            {
                string pre = word.Substring(0, len);
                for (int k = 0; k < n; k++)
                {
                    string suf = word.Substring(k, n - k);
                    string key = pre + "|" + suf;
                    if (!map.ContainsKey(key))
                        map.Add(key, index);

                    map[key] = index;
                }
            }

            index++;
        }
    }

    public int F(string prefix, string suffix)
    {
        string key = prefix + "|" + suffix;

        return !map.ContainsKey(key) ? -1 : map[key];
    }
}

/**
 * Your WordFilter object will be instantiated and called as such:
 * WordFilter obj = new WordFilter(words);
 * int param_1 = obj.F(prefix,suffix);
 */