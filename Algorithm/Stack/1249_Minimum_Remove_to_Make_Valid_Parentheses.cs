public class Solution {
    // Revisited on 03/15/2022 
    public string MinRemoveToMakeValid(string s) {
        var setOfIndexToRemove = new HashSet<int>();
        var st = new Stack<int>();
        
        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] == '(')
            {
                st.Push(i);
            }
            else if (s[i] == ')')
            {
                if (st.Count == 0)
                {
                    setOfIndexToRemove.Add(i);
                    continue;
                }
                
                st.Pop();
            }
        }
        
        while (st.Count > 0)
            setOfIndexToRemove.Add(st.Pop());
        
        var sb = new StringBuilder();
        for (int i = 0; i < s.Length; i++)
        {
            if (setOfIndexToRemove.Contains(i))
                continue;
            
            sb.Append(s[i]);
        }
        
        return sb.ToString();
    }
}