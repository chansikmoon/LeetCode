public class Solution {
    public int SmallestRepunitDivByK(int K) {
        if ((K & 1) == 0 || (K % 5) == 0)
            return -1;
        
        int num = 0;
        for (int i = 1; i <= K; i++)
        {
            num = (num * 10 + 1) % K;
            if (num == 0)
                return i;
        }
        
        return -1;
    }
}