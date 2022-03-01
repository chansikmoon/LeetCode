public class Solution {
    public int[] CountBits(int n) {
        var ret = new int[n + 1];
        
        for (int i = 1; i <= n; i++) {
            ret[i] = ret[i & (i - 1)] + 1;
        }
        
        return ret;
    }
}