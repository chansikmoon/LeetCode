public class Solution {
    public int CountCornerRectangles(int[][] grid) {
        int ret = 0;
        for (int i = 0; i < grid.Length - 1; i++)
        {
            for (int j = i + 1; j < grid.Length; j++)
            {
                int count = 0;
                for (int k = 0; k < grid[0].Length; k++)
                {
                    if (grid[i][k] == 1 && grid[j][k] == 1)
                        count++;
                }
                ret += count * (count - 1) / 2;
            }
        }
        
        return ret;
    }
}