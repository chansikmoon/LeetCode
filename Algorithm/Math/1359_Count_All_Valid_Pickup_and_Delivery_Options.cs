public class Solution {
    public int CountOrders(int n) {
        long ret = 1, mod = 1000000007;
        for (int i = 1; i <= n; i++) {
            ret = (ret * (i * 2 - 1) * i) % mod;
        }
        
        return (int) ret;
    }
}