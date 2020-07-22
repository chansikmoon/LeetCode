public class Solution {
    private int[][] dirs = new int[4][]
    {
        new int[] {-1,0},
        new int[] {0,1},
        new int[] {1,0},
        new int[] {0,-1}
    };
    
    // O(N * 4L), N is the r * c (all elements)
    public bool Exist(char[][] board, string word) {
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (Backtracking(board, i, j, word, 0))
                    return true;
            }
        }
        
        return false;
    }
    
    // O(4 * L), where L is the length of word
    private bool Backtracking(char[][] board, int i, int j, string word, int index)
    {
        if (word.Length <= index)
            return true;
        
        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || board[i][j] != word[index])
            return false;
        
        board[i][j] = '#';
        bool result = false;
        
        foreach(int[] dir in dirs)
        {
            result = Backtracking(board, i + dir[0], j + dir[1], word, index + 1);
            
            if (result)
                break;
        }
                   
        board[i][j] = word[index];
        
        return result;
    }
}