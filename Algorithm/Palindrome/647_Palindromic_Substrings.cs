public class Solution
{
    public int CountSubstrings(string s)
    {
        int count = 0;

        for (int i = 0; i < s.Length; i++)
        {
            count += ExpandPalindrome(s, i, i);
            count += ExpandPalindrome(s, i, i + 1);
        }

        return count;
    }

    private int ExpandPalindrome(string s, int i, int j)
    {
        int count = 0;

        while (i >= 0 && j < s.Length && s[i] == s[j])
        {
            count++;
            i--;
            j++;
        }

        return count;
    }
}