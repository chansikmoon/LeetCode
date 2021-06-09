public class Solution {
    public IList<string> RemoveComments(string[] source) {
        var ret = new List<string>();
        var sb = new StringBuilder();
        bool flag = false;
        
        foreach (var s in source)
        {
            for (int i = 0; i < s.Length; i++)
            {
                // check // 
                if (!flag && s[i] == '/' && i + 1 < s.Length && s[i + 1] == '/')
                    break;
                // check /*
                else if (!flag && s[i] == '/' && i + 1 < s.Length && s[i + 1] == '*')
                {
                    flag = true;
                    i++;
                }
                // check */
                else if (flag && s[i] == '*' && i + 1 < s.Length && s[i + 1] == '/')
                {
                    flag = false;
                    i++;
                }
                else if (!flag)
                    sb.Append(s[i]);
            }
            
            if (sb.Length > 0 && !flag)
            {
                ret.Add(sb.ToString());
                sb = new StringBuilder();
            }
        }
        
        return ret;
    }
}