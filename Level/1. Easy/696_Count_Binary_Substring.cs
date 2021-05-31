public class Solution
{
    public int CountBinarySubstrings(string s)
    {
        int preGroup = 0, currGroup = 1, ret = 0;

        for (int i = 1; i < s.Length; i++)
        {
            if (s[i] == s[i - 1])
                currGroup++;
            else
            {
                ret += Math.Min(preGroup, currGroup);
                preGroup = currGroup;
                currGroup = 1;
            }
        }

        return ret + Math.Min(preGroup, currGroup);
    }

    public int BruteForce(string s)
    {
        int ret = 0;

        for (int i = 1; i < s.Length; i++)
            ret += Expand(s, i - 1, i);

        return ret;
    }

    public int Expand(string s, int l, int r)
    {
        int ret = 0;
        int left = s[l] - '0';
        int right = s[r] - '0';

        if (left == right)
            return ret;

        for (; l >= 0 && r < s.Length; l--, r++)
        {
            if (s[l] - '0' != left || s[r] - '0' != right)
                break;

            ret++;
        }

        return ret;
    }
}