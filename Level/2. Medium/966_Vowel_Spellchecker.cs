public class Solution
{
    public string[] Spellchecker(string[] wordlist, string[] queries)
    {
        var wordsSet = new HashSet<string>();
        var lowerMap = new Dictionary<string, string>();
        var devowelsMap = new Dictionary<string, string>();
        var vowels = new HashSet<char>() {
            'a', 'e', 'i', 'o', 'u'
        };

        foreach (var word in wordlist)
        {
            var lower = word.ToLower();
            var devowel = string.Concat(lower.Select(c => vowels.Contains(c) ? '#' : c));

            wordsSet.Add(word);

            if (!lowerMap.ContainsKey(lower))
                lowerMap.Add(lower, word);

            if (!devowelsMap.ContainsKey(devowel))
                devowelsMap.Add(devowel, word);
        }

        for (int i = 0; i < queries.Length; i++)
        {
            if (wordsSet.Contains(queries[i]))
                continue;
            var lower = queries[i].ToLower();
            var devowel = string.Concat(lower.Select(c => vowels.Contains(c) ? '#' : c));

            if (lowerMap.ContainsKey(lower))
                queries[i] = lowerMap[lower];
            else if (devowelsMap.ContainsKey(devowel))
                queries[i] = devowelsMap[devowel];
            else
                queries[i] = "";
        }

        return queries;
    }
}