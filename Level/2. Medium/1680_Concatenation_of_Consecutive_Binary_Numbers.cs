public class Solution {
    public int ConcatenatedBinary(int n) {
        long ret = 0;
        int MOD = 1000000007;
        
        for (int i = 1; i <= n; i++)
        {
            // int bitLen = (int)(Math.Log(i) / Math.Log(2)) + 1;
            // ret = ((ret << bitLen) + i) % MOD;
            string bitLen = Convert.ToString(i, 2);
            ret = ((ret << bitLen.Length) + i) % MOD;
        }
        
        return (int)ret;
    }
}