public class Solution {
    public int ChalkReplacer(int[] chalk, int k) {
        long sum = 0;
        
        for (int i = 0; i < chalk.Length; i++)
            sum += (long)chalk[i];
        
        long remain = (long) k % sum;
        
        for (int i = 0; i < chalk.Length; i++)
        {
            if (remain - (long)chalk[i] < 0)
                return i;
            
            remain -= (long) chalk[i];
        }
        
        return 0;
    }
}