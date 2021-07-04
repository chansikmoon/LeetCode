public class Solution {
    private const long MOD = 1000000007;
    
    public int CountGoodNumbers(long n) {
        long numOfFours = n / 2;
        long numOfFives = n - numOfFours;
        
        long evenGoodNumber = GetGoodNumber(4, numOfFours) % MOD;
        long oddGoodNumber = GetGoodNumber(5, numOfFives) % MOD;
        
        return  (int)((evenGoodNumber * oddGoodNumber) % MOD);
    }
    
    private long GetGoodNumber(long num, long count)
    {
        long ret = 1;
        
        while (count > 0)
        {
            if ((count & 1) > 0)
                ret = (ret * num) % MOD;
            
            count >>= 1;
            num = (num * num) % MOD;
        }
        
        return ret;
    }
}