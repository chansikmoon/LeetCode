public class Solution {
    public int[] FindDiagonalOrder(int[][] matrix) {
        if (matrix.Length == 0) return new int[0];

        int x = 0, y = 0, m = matrix.Length, n = matrix[0].Length;
        int[] ret = new int[m * n];

        for (int i = 0; i < ret.Length; i++)
        {
            ret[i] = matrix[x][y];

            // Going up
            if ((x + y) % 2 == 0)
            {
                // hit the right wall
                if (y == n - 1)
                    x++;

                // hit the top wall
                else if (x == 0)
                    y++;
                else
                {
                    x--;
                    y++;
                }
            }
            else
            {
                // hit the bottom wall
                if (x == m - 1)
                    y++;
                // hit the left wall
                else if (y == 0)
                    x++;
                else
                {
                    x++;
                    y--;
                }
            }
        }

        return ret;
    }

    public int[] BruteForce(int[][] matrix)
    {
        List<int> ret = new List<int>();
        if (matrix.Length == 0) return ret.ToArray();
        int i = 0, j = 0, m = matrix.Length, n = matrix[0].Length;
        
        while (i != m - 1 || j != n - 1)
        {
            // let's go up first
            while (i >= 0 && j < n)
                ret.Add(matrix[i--][j++]);
            
            // bring x and y back
            i++;
            j--;
            
            // Try to go right first and then go down
            if (j + 1 < n)
                j++;
            else if (i + 1 < m)
                i++;
            
            if (i == m - 1 && j == n - 1)
                break;
            
            // let's go down now
            while (i < m && j >= 0)
                ret.Add(matrix[i++][j--]);
            
            // bring x and y back
            i--;
            j++;
            
            // Try to go down first and then go right
            if (i + 1 < m)
                i++;
            else if (j + 1 < n)
                j++;
            
            if (i == m - 1 && j == n - 1)
                break;
        }
        
        ret.Add(matrix[m-1][n-1]);
        
        return ret.ToArray();
    }
}