public class Solution {
    public int SmallestRepunitDivByK(int k) {
       if ((k & 1) == 0 || (k % 5) == 0)
           return -1;
        
        int num = 0;
        for (int i = 1; i <= k; i++)
        {
            num = (num * 10 + 1) % k;
            if (num == 0)
                return i;
        }
        
        return -1;
    }
}