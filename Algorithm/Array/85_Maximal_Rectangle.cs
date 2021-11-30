public class Solution {
    public int MaximalRectangle(char[][] matrix) {
        if (matrix.Length == 0)
            return 0;
        int n = matrix.Length, m = matrix[0].Length, ret = 0;
        var heights = new int[m];
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                heights[j] = matrix[i][j] == '1' ? heights[j] + 1 : 0;
            }
            
            ret = Math.Max(ret, GetMaxArea(heights));
        }
        
        return ret;
    }
    
    private int GetMaxArea(int[] heights)
    {
        int max = 0;
        var st = new Stack<int>();
        st.Push(-1);
        
        for (int i = 0; i < heights.Length; i++)
        {
            while (st.Peek() != -1 && heights[st.Peek()] >= heights[i])
                max = Math.Max(max, heights[st.Pop()] * (i - st.Peek() - 1));
        
            st.Push(i);
        }
        
        while (st.Peek() != -1)
            max = Math.Max(max, heights[st.Pop()] * (heights.Length - st.Peek() - 1));
        
        return max;
    }
}