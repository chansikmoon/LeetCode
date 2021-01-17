public class Solution {
    public int CountGoodRectangles(int[][] rec) {
        int maxLen = 0;
        
        foreach (var r in rec)
            maxLen = Math.Max(maxLen, Math.Min(r[0], r[1]));
        
        int ret = 0;
        foreach (var r in rec)
            ret += Math.Min(r[0], r[1]) == maxLen ? 1 : 0;
            
        return ret;
    }
    
    public int BruteForce(int[][] rec) {
        var arr = new int[rec.Length];
        int maxLen = 0;
        for (int i = 0; i < rec.Length; i++)
        {
            arr[i] = Math.Min(rec[i][0], rec[i][1]);
            maxLen = Math.Max(maxLen, arr[i]);
        }
        
        int ret = 0;
        
        foreach (var a in arr)
            ret += a == maxLen ? 1 : 0;
            
        return ret;
    }
}