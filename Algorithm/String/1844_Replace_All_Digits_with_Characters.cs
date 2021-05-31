public class Solution
{
    public string ReplaceDigits(string s)
    {
        var sb = new StringBuilder();

        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsDigit(s[i]))
                sb.Append((char)((s[i - 1] - 'a') + (s[i] - '0') + 'a'));
            else
                sb.Append(s[i]);
        }

        return sb.ToString();
    }
}