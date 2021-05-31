public class Solution
{
    public string OriginalDigits(string s)
    {
        var count = new int[10];

        // All even numbers have a unique character
        // we can subtract unique characters to figure out all odd numbers.
        for (int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            if (c == 'z')
                count[0]++;
            if (c == 'w')
                count[2]++;
            if (c == 'u')
                count[4]++;
            if (c == 'x')
                count[6]++;
            if (c == 'g')
                count[8]++;
            if (c == 'o')
                count[1]++;
            if (c == 'h')
                count[3]++;
            if (c == 'f')
                count[5]++;
            if (c == 's')
                count[7]++;
            if (c == 'i')
                count[9]++;
        }

        count[7] -= count[6];
        count[5] -= count[4];
        count[3] -= count[8];
        count[1] = count[1] - count[0] - count[2] - count[4];
        count[9] = count[9] - count[5] - count[6] - count[8];

        var sb = new StringBuilder();

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < count[i]; j++)
                sb.Append(i);
        }

        return sb.ToString();
    }
}