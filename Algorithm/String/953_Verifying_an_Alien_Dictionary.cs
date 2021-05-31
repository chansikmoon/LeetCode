public class Solution
{
    public bool IsAlienSorted(string[] words, string order)
    {
        var map = new Dictionary<char, char>();
        var newWords = new string[words.Length];

        for (int i = 0; i < 26; i++)
            map.Add(order[i], (char)(i + 'a'));

        for (int i = 0; i < words.Length; i++)
        {
            var sb = new StringBuilder();

            for (int j = 0; j < words[i].Length; j++)
            {
                sb.Append(map[words[i][j]]);
            }

            newWords[i] = sb.ToString();
        }

        for (int i = 1; i < newWords.Length; i++)
        {
            if (String.Compare(newWords[i - 1], newWords[i]) > 0)
                return false;
        }

        return true;
    }
}