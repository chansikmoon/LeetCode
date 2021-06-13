public class Solution {
    public bool IsCovered(int[][] ranges, int left, int right) {
        var arr = new bool[51];
        
        foreach (var range in ranges)
        {
            for (int i = range[0]; i <= range[1]; i++)
                arr[i] = true;
        }
        
        for (int i = left; i <= right; i++)
            if (!arr[i])
                return false;
        
        return true;
    }
}