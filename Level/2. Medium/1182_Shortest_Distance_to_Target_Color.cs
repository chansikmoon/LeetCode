public class Solution {
    public IList<int> ShortestDistanceColor(int[] colors, int[][] queries) {
        int n = colors.Length;
        var leftMost = new int[4, n];
        var rightMost = new int[4, n];
        
        for (int i = 1; i < 4; i++)
        {
            for (int j = 0; j < n; j++)
            {
                leftMost[i, j] = Int32.MaxValue;
                rightMost[i, j] = Int32.MaxValue;
            }
        }
        
        for (int color = 1; color <= 3; color++)
        {
            for (int i = 0; i < n; i++)
            {
                if (colors[i] == color)
                    leftMost[color, i] = 0;
                else if (i > 0 && leftMost[color, i - 1] != Int32.MaxValue)
                    leftMost[color, i] = leftMost[color, i - 1] + 1;
            }
            
            for (int i = n - 1; i >= 0; i--)
            {
                if (colors[i] == color)
                    rightMost[color, i] = 0;
                else if (i < n - 1 && rightMost[color, i + 1] != Int32.MaxValue)
                    rightMost[color, i] = rightMost[color, i + 1] + 1;
            }
        }
        
        var ret = new List<int>();
        
        foreach (var q in queries)
        {
            int index = q[0], target = q[1];
            
            int val = Math.Min(leftMost[target, index], rightMost[target, index]);
            
            if (val == Int32.MaxValue)
                val = -1;
                
            ret.Add(val);
        }
        
        return ret.ToArray();
    }
}