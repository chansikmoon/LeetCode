public class Solution {
    public bool IsValid(string s) {
        var st = new Stack<char>();
        
        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                st.Push(c);
                continue;
            }
            
            if (st.Count == 0)
                return false;
            
            var open = st.Pop();
            
            if ((c == ')' && open != '(') ||
               (c == ']' && open != '[') ||
               (c == '}' && open != '{'))
                return false;
        }
        
        return st.Count == 0;
    }
}