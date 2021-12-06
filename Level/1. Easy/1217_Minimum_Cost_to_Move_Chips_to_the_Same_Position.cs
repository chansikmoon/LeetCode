public class Solution {
    // Moving + or - 2 positions costs a zero
    // Moving + or - 1 position costs one
    // Thus moving all chips that are in odd positions to position 1 cost nothing.
    // The same for all chips in even positions.
    // Once all chips are in position 0 and 1, we choose minimum number of chips in 0 and 1.
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