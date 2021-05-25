public class Solution
{
    public string ToLowerCase(string s)
    {
        var arr = s.ToCharArray();

        for (int i = 0; i < s.Length; i++)
        {
            if (arr[i] >= 'A' && arr[i] <= 'Z')
                arr[i] = (char)(arr[i] + 32);
        }

        return new string(arr);
    }
}