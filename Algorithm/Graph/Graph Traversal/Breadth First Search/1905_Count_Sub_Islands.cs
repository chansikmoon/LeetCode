public class Solution {
    public int CountSubIslands(int[][] g1, int[][] g2) {
        int m = g1.Length, n = g1[0].Length, ret = 0;
        var dir = new int[] { 0, 1, 0, -1, 0 };
        
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (g2[i][j] == 1)
                {
                    bool flag = true;
                    var q = new Queue<(int row, int col)>();
                    
                    q.Enqueue((i, j));
                    g2[i][j] = 0;
                    
                    if (g1[i][j] != 1)
                        flag = false;
                    
                    while (q.Count > 0)
                    {
                        var coor = q.Dequeue();
                        int currI = coor.row;
                        int currJ = coor.col;
                            
                        for (int d = 1; d < 5; d++)
                        {
                            int nextI = currI + dir[d - 1];
                            int nextJ = currJ + dir[d];
                            
                            if (nextI < 0 || nextI >= m || nextJ < 0 || nextJ >= n || g2[nextI][nextJ] != 1)
                                continue;
                            
                            if (g1[nextI][nextJ] != 1)
                                flag = false;
                            
                            q.Enqueue((nextI, nextJ));
                            g2[nextI][nextJ] = 0;
                        }
                    }
                    
                    if (flag) ret++;
                }
            }
        }
        
        return ret;
    }
}