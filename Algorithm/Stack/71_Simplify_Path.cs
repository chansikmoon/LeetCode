public class Solution {
    public string SimplifyPath(string path) {
        var st = new Stack<string>();
        var dirs = path.Split('/');
        
        foreach (var dir in dirs)
        {
            if (string.IsNullOrWhiteSpace(dir) || dir == ".")
                continue;
            
            if (dir == "..")
            {
                if (st.Count > 0)
                    st.Pop();
                
                continue;
            }
            
            st.Push(dir);
        }
        
        var sb = new StringBuilder();
        var arr = st.ToArray();
        Array.Reverse(arr);
        
        foreach (var str in arr)
        {
            sb.Append('/');
            sb.Append(str);
        }
        
        return sb.Length == 0 ? "/" : sb.ToString();
    }
}
