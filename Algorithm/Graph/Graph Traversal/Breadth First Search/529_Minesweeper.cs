public class Solution {
    private int[] Directions = new int[] { 0, 1, 0, -1, 0 };
    private int Rows = 0;
    private int Cols = 0;
    
    public char[][] UpdateBoard(char[][] board, int[] click) {
        Rows = board.Length;
        Cols = board[0].Length;
        
        var q = new Queue<(int row, int col)>();
        q.Enqueue((click[0], click[1]));
        
        while (q.Count > 0)
        {
            var curr = q.Dequeue();
            var row = curr.row;
            var col = curr.col;
            
            if (board[row][col] == 'M')
            {
                board[row][col] = 'X';
            }
            else
            {
                int mines = 0;
            
                foreach (var next in GetAdjacents(board, row, col))
                {
                    int nextRow = next.Row;
                    int nextCol = next.Col;

                    mines += board[nextRow][nextCol] == 'M' || board[nextRow][nextCol] == 'X' ? 1 : 0;
                }
                
                if (mines > 0)
                {
                    board[row][col] = (char)(mines+'0');
                }
                else
                {
                    board[row][col] = 'B';
                    foreach (var next in GetAdjacents(board, row, col))
                    {
                        int nextRow = next.Row;
                        int nextCol = next.Col;

                        if (board[nextRow][nextCol] == 'E')
                        {
                            q.Enqueue((nextRow, nextCol));
                            board[nextRow][nextCol] = 'B';
                        }
                    }       
                }
            }
        }
        
        return board;
    }
    
    private List<(int Row, int Col)> GetAdjacents(char[][] board, int row, int col)
    {
        var ret = new List<(int, int)>();
        
        for (int i = -1; i <= 1; i++)
        {
            for (int j = -1; j <= 1; j++)
            {
                if (i == 0 && j == 0)
                    continue;
                
                int nextRow = row + i;
                int nextCol = col + j;

                if (InvalidRowAndColumn(nextRow, nextCol))
                    continue;

                ret.Add((nextRow, nextCol));
            }
        }

        return ret;
    }
    
    private bool InvalidRowAndColumn(int row, int col)
    {
        return row < 0 || row >= Rows || col < 0 || col >= Cols;    
    }
}

