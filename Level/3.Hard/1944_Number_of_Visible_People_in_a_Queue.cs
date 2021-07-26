public class Solution {
    public int[] CanSeePersonsCount(int[] heights) {
        int n = heights.Length;
        var ret = new int[n];
        var st = new Stack<int>();
        
        for (int i = 0; i < n; i++)
        {
            while (st.Count > 0 && heights[st.Peek()] <= heights[i])
                ret[st.Pop()]++;
            if (st.Count > 0)
                ret[st.Peek()]++;
            st.Push(i);
        }
        
        return ret;
    }
}