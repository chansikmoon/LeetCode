public class Solution {
    public int[] FindPermutation(string s) {
        int[] retval = new int[s.Length + 1];
        Stack<int> st = new Stack<int>();
        int j = 0;
        
        for (int i = 1; i <= s.Length; i++)
        {
            if (s[i-1] == 'I')
            {
                st.Push(i);
                while (st.Count > 0)
                    retval[j++] = st.Pop();
            }
            else
                st.Push(i);
        }
        
        st.Push(s.Length + 1);
        
        while (st.Count > 0)
            retval[j++] = st.Pop();
        
        return retval;
    }
}