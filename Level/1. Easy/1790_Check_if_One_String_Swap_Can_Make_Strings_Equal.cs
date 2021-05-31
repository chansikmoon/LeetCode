public class Solution
{
    public bool AreAlmostEqual(string s1, string s2)
    {
        var sb1 = new StringBuilder();
        var sb2 = new StringBuilder();

        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                sb1.Append(s1[i]);
                sb2.Append(s2[i]);
            }
        }

        return sb1.Length == 0 || (sb1.Length == 2 && sb1.Length == sb2.Length && sb1[0] == sb2[1] && sb1[1] == sb2[0]);
    }
}