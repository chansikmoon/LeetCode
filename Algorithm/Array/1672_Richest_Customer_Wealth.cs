public class Solution {
    public int MaximumWealth(int[][] accounts) {
        int ret = 0;
        
        foreach (var account in accounts) {
            ret = Math.Max(ret, account.Sum());
        }
        
        return ret;
    }
}