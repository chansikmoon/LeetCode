public class Solution
{
    public bool IsNumber(string s)
    {
        bool seenSign = false;
        bool seenE = false;
        bool seenDot = false;
        bool number = false;
        bool numberAfterE = false;

        s = s.Trim().ToLower();

        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];

            if (Char.IsDigit(c))
            {
                number = true;
                numberAfterE = true;
            }
            else if (c == '-' || c == '+')
            {
                // we only allowed sign either very first character or 
                // right after e
                if (i > 0 && s[i - 1] != 'e')
                    return false;

                seenSign = true;
            }
            else if (c == '.')
            {
                if (seenE || seenDot)
                    return false;
                seenDot = true;
            }
            else if (c == 'e')
            {
                if (seenE || !number)
                    return false;
                seenE = true;
                numberAfterE = false;
            }
            else
                return false;

        }

        return number && numberAfterE;
    }
}