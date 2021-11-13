public class Solution {
    public int[] DailyTemperatures(int[] t) {
        var st = new Stack<int>();
        var ret = new int[t.Length];
        
        for (int i = 0; i < t.Length; i++)
        {
            while (st.Count > 0 && t[st.Peek()] < t[i])
            {
                int index = st.Pop();
                ret[index] = i - index;
            }
            
            st.Push(i);
        }
        
        return ret;
    }
}