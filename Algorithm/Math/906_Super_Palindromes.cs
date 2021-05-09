public class Solution
{
    public int SuperpalindromesInRange(string L, string R)
    {
        long low = StringToLong(L);
        long high = StringToLong(R);

        int ret = 0;

        var palindromes = new List<long>();
        for (long i = 1; i <= 9; i++)
            palindromes.Add(i);

        for (long i = 1; i < 10000; i++)
        {
            var left = i.ToString();
            var right = Reverse(left);
            palindromes.Add(Convert.ToInt64(left + right));
            for (int m = 0; m < 10; m++)
                palindromes.Add(Convert.ToInt64(left + m + right));
        }

        foreach (var pal in palindromes)
        {
            long square = pal * pal;
            if (!IsPalindrome(square.ToString()))
                continue;

            if (low <= square && square <= high)
                ret++;
        }

        return ret;
    }

    private string Reverse(string s)
    {
        var charArray = s.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private bool IsPalindrome(string str)
    {
        int n = str.Length;

        for (int i = 0; i < n / 2; i++)
        {
            if (str[i] != str[n - i - 1])
                return false;
        }

        return true;
    }

    private long StringToLong(string str)
    {
        long ret = 0;

        for (int i = 0; i < str.Length; i++)
            ret = ret * 10 + str[i] - '0';

        return ret;
    }
}