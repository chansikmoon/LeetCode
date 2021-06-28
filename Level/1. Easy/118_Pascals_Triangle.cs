public class Solution {
    public IList<IList<int>> Generate(int numRows) {
        var ret = new List<IList<int>>();
        Build(ret, 1, numRows);
        return ret;
    }
    
    private void Build(List<IList<int>> ret, int depth, int numRows)
    {
        if (depth > numRows)
            return;
        
        var arr = new int[depth];
        Array.Fill(arr, 1);
        
        if (ret.Count > 1)
        {
            var last = ret[ret.Count - 1];
            for (int i = 1; i < last.Count; i++)
                arr[i] = last[i - 1] + last[i];    
        }
        
        ret.Add(arr.ToList());
        
        Build(ret, depth + 1, numRows);
    }
}