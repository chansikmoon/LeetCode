public class Solution {
    public int MinKnightMoves(int x, int y) {
        x = Math.Abs(x);
        y = Math.Abs(y);
        
        return Helper(x, y, new Dictionary<string, int>());
    }
    
    private int Helper(int x, int y, Dictionary<string, int> memo)
    {
        string key = string.Format("{0},{1}", x, y);
        if (memo.ContainsKey(key))
            return memo[key];
        
        if (x + y == 0)
            return 0;
        else if (x + y == 2)
            return 2;
        
        int min = Math.Min(Helper(Math.Abs(x - 1), Math.Abs(y - 2), memo), 
                           Helper(Math.Abs(x - 2), Math.Abs(y - 1), memo)) + 1;
        memo.Add(key, min);
        
        return min;
    }
}