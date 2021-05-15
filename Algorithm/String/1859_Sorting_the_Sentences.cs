public class Solution
{
    public string SortSentence(string s)
    {
        var strs = s.Split(" ");
        var ret = new string[strs.Length];

        foreach (var str in strs)
        {
            string word = str.Substring(0, str.Length - 1);
            ret[str[str.Length - 1] - '0' - 1] = word;
        }

        return string.Join(" ", ret);
    }
}