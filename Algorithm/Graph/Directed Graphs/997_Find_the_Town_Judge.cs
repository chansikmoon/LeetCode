public class Solution {
    public int FindJudge(int n, int[][] trust) {
        var degree = new int[n + 1];
        
        foreach (var t in trust)
        {
            degree[t[0]]--;
            degree[t[1]]++;
        }
        
        for (int i = 1; i < degree.Length; i++)
        {
            if (degree[i] == n - 1)
                return i;
        }
        
        return -1;
    }
}