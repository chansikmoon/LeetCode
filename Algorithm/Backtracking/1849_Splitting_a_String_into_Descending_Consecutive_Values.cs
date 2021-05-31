public class Solution
{
    public bool SplitString(string s)
    {
        long currVal = 0;
        for (int i = 0; i < s.Length - 1; i++)
        {
            currVal = currVal * 10 + (long)(s[i] - '0');

            if (currVal == 0)
                continue;

            if (Helper(s, i + 1, currVal))
                return true;
        }

        return false;
    }

    private bool Helper(string s, int index, long prevVal)
    {
        if (index >= s.Length)
            return true;

        long currVal = 0;

        for (int i = index; i < s.Length; i++)
        {
            currVal = currVal * 10 + (long)(s[i] - '0');
            if (currVal < prevVal - 1)
                continue;

            if (prevVal <= currVal || prevVal - 1 != currVal)
                return false;

            if (Helper(s, i + 1, currVal))
                return true;
        }

        return false;
    }
}