public class TicTacToe {
    private int[] Rows;
    private int[] Cols;
    private int Diagonal;
    private int AntiDiagonal;
    private int size;
    
    /** Initialize your data structure here. */
    public TicTacToe(int n) {
        size = n;
        
        Rows = new int[n];
        Cols = new int[n];
        Diagonal = 0;
        AntiDiagonal = 0;
    }
    
    /** Player {player} makes a move at ({row}, {col}).
        @param row The row of the board.
        @param col The column of the board.
        @param player The player, can be either 1 or 2.
        @return The current winning condition, can be either:
                0: No one wins.
                1: Player 1 wins.
                2: Player 2 wins. */
    public int Move(int row, int col, int player) {
        int val = player;
        if (player == 2)
            val = -1;
        
        Rows[row] += val;
        Cols[col] += val;
        
        if (row == col)
            Diagonal += val;
        
        if (row + col == size - 1)
            AntiDiagonal += val;
        
        return (Math.Abs(Rows[row]) == size || Math.Abs(Cols[col]) == size || Math.Abs(Diagonal) == size || Math.Abs(AntiDiagonal) == size) ? player : 0;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */