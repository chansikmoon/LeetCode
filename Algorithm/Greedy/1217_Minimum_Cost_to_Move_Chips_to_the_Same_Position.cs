public class Solution {
    public int MinCostToMoveChips(int[] position) {
        int[] count = new int[2];
        
        for (int i = 0; i < position.Length; i++)
            count[position[i] & 1]++;
        
        return Math.Min(count[0], count[1]);
    }
    
    public int BruteForce(int[] position)
    {
        int oddCount = 0, evenCount = 0;
        
        for (int i = 0; i < position.Length; i++)
        {
            if (position[i] % 2 == 0)
                evenCount++;
            else
                oddCount++;
        }
        
        return Math.Min(oddCount, evenCount);
    }
}