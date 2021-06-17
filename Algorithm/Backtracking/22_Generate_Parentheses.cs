public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var ret = new List<string>();
        Backtracking(ret, "", n, n);
        
        return ret;
    }
    
    private void Backtracking(List<string> list, string str, int open, int close)
    {        
        if (open == 0 && close == 0)
        {
            list.Add(str);
            return;
        }
        
        if (open > 0)
            Backtracking(list, str + "(", open - 1, close);
        
        if (close > open)
            Backtracking(list, str + ")", open, close - 1);
    }
}
