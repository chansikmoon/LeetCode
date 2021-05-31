public class Solution
{
    public int ShortestWay(string s, string t)
    {
        int n = s.Length, m = t.Length, ret = 0;

        for (int i = 0; i < m;)
        {
            int prevI = i;

            for (int j = 0; j < n; j++)
            {
                if (i < m && s[j] == t[i])
                    i++;
            }

            if (prevI == i)
                return -1;
            ret++;
        }

        return ret;
    }
}