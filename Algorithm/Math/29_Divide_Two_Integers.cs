public class Solution {
    public int Divide(int dividend, int divisor) {
        if (dividend == Int32.MinValue && divisor == -1)
            return Int32.MaxValue;
        
        int sign = dividend > 0 ^ divisor > 0 ? -1 : 1;
        long dvd = Math.Abs((long)dividend), dvs = Math.Abs((long)divisor), ans = 0;
        while (dvd >= dvs)
        {
            long tmp = dvs, m = 1;
            while (tmp << 1 <= dvd)
            {
                tmp <<= 1;
                m <<= 1;
            }
            
            dvd -= tmp;
            ans += m;
        }
        
        return (int)(sign * ans);
    }
}