public class Solution {
    public int MaxSatisfied(int[] customers, int[] grumpy, int minutes) {
        int sat = 0, maxPossible = 0, currPossible = 0;
        
        for (int i = 0; i < grumpy.Length; i++)
        {
            if (grumpy[i] == 0)
                sat += customers[i];
            
            if (grumpy[i] == 1)
                currPossible += customers[i];
            
            if (i >= minutes && grumpy[i - minutes] == 1)
                currPossible -= customers[i - minutes];
            
            maxPossible = Math.Max(maxPossible, currPossible);
        }
        
        return sat + maxPossible;
    }
}