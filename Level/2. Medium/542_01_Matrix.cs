public class Solution {
    public int[][] UpdateMatrix(int[][] mat) {
        int n = mat.Length, m = mat[0].Length;
        
        var q = new Queue<int>();
        
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (mat[i][j] == 0)
                    q.Enqueue(i * m + j);
                else
                    mat[i][j] = Int32.MaxValue;
            }
        }
        
        var dirs = new int[] { 0 , 1, 0, -1, 0 };
        
        while (q.Count > 0)
        {
            int curr = q.Dequeue();
            int row = curr / m;
            int col = curr % m;
            
            for (int d = 1; d < 5; d++)
            {
                int nextRow = row + dirs[d - 1];
                int nextCol = col + dirs[d];
                
                if (nextRow < 0 || nextRow >= n || nextCol < 0 || nextCol >= m)
                    continue;
                
                if (mat[row][col] + 1 < mat[nextRow][nextCol])
                {
                    mat[nextRow][nextCol] = mat[row][col] + 1;
                    q.Enqueue(nextRow * m + nextCol);
                }
            }
        }
        
        return mat;
    }
}