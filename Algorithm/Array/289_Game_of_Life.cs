public class Solution {
    private int[][] Directions = new int[8][]
    {
        new int[] {-1, -1}, new int[] {-1, 0}, new int[] {-1, 1},
        new int[] {0, -1}, new int[] {0, 1},
        new int[] {1, -1}, new int[] {1, 0}, new int[] {1, 1},
    };

    public void GameOfLife(int[][] board) {
        var copyBoard = board.Select(x => x.ToArray()).ToArray();
        
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                int numOfLiveNeighbors = GetNumberOfLiveNeighbors(copyBoard, i, j);
                
                if (copyBoard[i][j] == 1 &&
                    numOfLiveNeighbors != 2 &&
                    numOfLiveNeighbors != 3)
                {
                    board[i][j] = 0;
                }
                else if (copyBoard[i][j] == 0 &&
                        numOfLiveNeighbors == 3)
                {
                    board[i][j] = 1;
                }
            }
        }
    }
    
    private int GetNumberOfLiveNeighbors(int[][] board, int i, int j)
    {
        int ret = 0;
        
        foreach (var dir in Directions)
        {
            int nextI = i + dir[0], nextJ = j + dir[1];
            
            if (nextI >= 0 && nextI < board.Length &&
               nextJ >= 0 && nextJ < board[0].Length &&
               board[nextI][nextJ] == 1)
                ret++;
        }
        
        return ret;
    }
}