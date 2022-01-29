public class Solution {
    public int LargestRectangleArea(int[] heights) {
        var st = new Stack<int>();
        st.Push(-1);
        int ret = 0;
        
        for (int i = 0; i < heights.Length; i++)
        {
            while (st.Peek() >= 0 && heights[st.Peek()] >= heights[i])
            {
                ret = Math.Max(ret, heights[st.Pop()] * (i - st.Peek() - 1));
            }
            
            st.Push(i);
        }
        
        while (st.Peek() > -1)
        {
            ret = Math.Max(ret, heights[st.Pop()] * (heights.Length - st.Peek() - 1));
        }
        
        return ret;
    }
}