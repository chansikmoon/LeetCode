public class Solution
{
    public bool CheckIfPangram(string s)
    {
        var arr = new int[26];

        for (int i = 0; i < s.Length; i++)
            arr[s[i] - 'a']++;

        return arr.Min() != 0;
    }
}