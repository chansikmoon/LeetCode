public class Solution
{
    public bool HalvesAreAlike(string s)
    {
        var vowels = new HashSet<char>()
        {
            'a', 'e', 'i', 'o', 'u',
            'A', 'E', 'I', 'O', 'U',
        };

        int ret = 0, half = s.Length / 2;

        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
                ret += i < half ? 1 : -1;
        }

        return ret == 0;
    }
}