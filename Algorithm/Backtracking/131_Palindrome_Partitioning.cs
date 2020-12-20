public class Solution {
    public IList<IList<string>> Partition(string s) 
    {
        var ret = new List<IList<string>>();
        Backtracking(ret, new List<string>(), s, 0);
        return ret;
    }

    private void Backtracking(List<IList<string>> ret, List<string> list, string s, int index)
    {
        if (index >= s.Length)
        {
            ret.Add(new List<string>(list));
            return;
        }

        StringBuilder sb = new StringBuilder();

        for (int i = index; i < s.Length; i++)
        {
            sb.Append(s[i]);

            if (!IsValidPalindrome(sb.ToString()))
                continue;

            list.Add(sb.ToString());
            Backtracking(ret, list, s, i + 1);
            list.RemoveAt(list.Count - 1);
        }
    }
    
    private bool IsValidPalindrome(string s)
    {
        for (int i = 0; i < s.Length / 2; i++)
        {
            if (s[i] != s[s.Length - 1 - i])
                return false;
        }
        
        return true;
    }
}