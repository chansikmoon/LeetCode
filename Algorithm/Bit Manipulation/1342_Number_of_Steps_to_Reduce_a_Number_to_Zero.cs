public class Solution {
    public int NumberOfSteps (int num) {
        if (num == 0)
            return 0;
        
        int maxBitPlace = 0, numOfOnes = 0;
        
        for (int i = 0; i < 32; i++)
        {   
            if ((num & (1 << i)) > 0)
            {
                maxBitPlace = Math.Max(maxBitPlace, i);
                numOfOnes++;
            }
        }
        
        return maxBitPlace + numOfOnes;
    }
}