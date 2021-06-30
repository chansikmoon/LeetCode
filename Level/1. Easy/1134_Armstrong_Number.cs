public class Solution {
    public bool IsArmstrong(int n) {
        int original = n, sum = 0;
        int k = FindK(n);
        
        while (n > 0)
        {
            int digit = n % 10;
            n /= 10;
            
            sum += (int)Math.Pow((double)digit, (double)k);
        }
        
        return sum == original;
    }
    
    private int FindK(int n)
    {
        int ret = 0;
        
        while (n > 0)
        {
            ret++;
            n /= 10;
        }
        
        return ret;
    }
}